using LeagueOfBabyfoot.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data.Repositories
{
	internal class PlayerRepository : MongoRepository<Match>, IPlayerRepository
	{
		public Player Find(string name)
		{
			return GetAll().First(player => player.Name == name);
		}

		public IList<Player> GetAll(int? skip = null, int? take = null)
		{
			var reduceArgs = new MapReduceArgs
			{
				MapFunction = MapPlayers,
				ReduceFunction = ReducePlayers,
				FinalizeFunction = FinalizePlayers,
			};

			var players = m_collection
				.MapReduce(reduceArgs)
				.GetResultsAs<ReducedResult<Player>>()
				.Select(doc => doc.value)
				.OrderByDescending(player => player.Score)
				.AsEnumerable();

			if (skip.HasValue)
			{
				players = players.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				players = players.Take(take.Value);
			}

			return players.ToList();
		}
	}
}
