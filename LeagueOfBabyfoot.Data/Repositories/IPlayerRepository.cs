using LeagueOfBabyfoot.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data.Repositories
{
	public interface IPlayerRepository
	{
		Player Find(string name);

		IList<Player> GetAll(int? skip = null, int? take = null);
	}
}
