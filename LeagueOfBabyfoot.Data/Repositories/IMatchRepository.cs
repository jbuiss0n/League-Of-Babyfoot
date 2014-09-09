using LeagueOfBabyfoot.Data.Entities;
using System;
using System.Collections.Generic;

namespace LeagueOfBabyfoot.Data.Repositories
{
	public interface IMatchRepository
	{
		Match Find(Guid guid);

		bool Add(Match entity);

		bool Remove(Match entity);

		bool Update(Match entity);

		IList<Match> GetAll(int? skip = null, int? take = null);
	}
}
