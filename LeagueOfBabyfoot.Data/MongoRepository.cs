using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data
{
	public abstract class MongoRepository<T>
		where T : class
	{
		protected MongoCollection<T> m_collection;

		public MongoRepository()
		{
			m_collection = new MongoClient(ConfigurationManager.AppSettings["MongoHost"])
				.GetServer()
				.GetDatabase("babyboard")
				.GetCollection<T>("match");
		}

		protected string MapPlayers = @"function() {
			var match = this;
			for (var i = 0; i < match.FirstTeamMembers.length; ++i) {
				emit(match.FirstTeamMembers[i], { Played: 1, Scored: match.FirstTeamScore, Conceded: match.SecondTeamScore });
			}
			for (var i = 0; i < match.SecondTeamMembers.length; ++i) {
				emit(match.SecondTeamMembers[i], { Played: 1, Scored: match.SecondTeamScore, Conceded: match.FirstTeamScore });
			}
		}";

		protected string ReducePlayers = @"function(key, values) {
			var result = { Played: 0, Diff: 0, Win: 0, Loose: 0, Scored: 0, Conceded: 0 };

			values.forEach(function(value) {               
				result.Played += value.Played;
				result.Scored += value.Scored;
				result.Conceded += value.Conceded;
				result.Diff += value.Scored - value.Conceded;
				result.Win += value.Scored > value.Conceded ? 1 : 0;
				result.Loose += value.Scored < value.Conceded ? 1 : 0;
			});

			return result;
		}";

		protected string FinalizePlayers = @"function(key, value){
			value.Name = key;
			value.Score = value.Diff / value.Played * 10;
			return value;
		}";
	}
}
