using LeagueOfBabyfoot.Data.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data.Repositories
{
	internal class MatchRepository : MongoRepository<Match>, IMatchRepository
	{
		public Match Find(Guid guid)
		{
			return m_collection.FindOneById(guid);
		}

		public bool Add(Match entity)
		{
			return m_collection.Insert(entity).Ok;
		}

		public bool Remove(Match entity)
		{
			return m_collection.Remove(Query<Match>.EQ(match => match.id_Match, entity.id_Match)).Ok;
		}

		public bool Update(Match entity)
		{
			return m_collection.Save(entity).Ok;
		}

		public IList<Match> GetAll(int? skip, int? take = null)
		{
			var collection = m_collection.FindAll();

			if (skip.HasValue)
			{
				collection = collection.SetSkip(skip.Value);
			}

			if (take.HasValue)
			{
				collection = collection.SetLimit(take.Value);
			}

			return collection.ToList();
		}
	}
}