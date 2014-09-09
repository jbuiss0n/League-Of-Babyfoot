using JEB.BootStrap;
using LeagueOfBabyfoot.Data.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data
{
	public class DataBootstrapper : IBootstrapperTask
	{
		public void Execute()
		{
			ObjectFactory.Configure(x =>
			{
				Map(x);
			});
		}

		private void Map(ConfigurationExpression x)
		{
			x.For<IMatchRepository>().Use<MatchRepository>();
			x.For<IPlayerRepository>().Use<PlayerRepository>();
		}
	}
}