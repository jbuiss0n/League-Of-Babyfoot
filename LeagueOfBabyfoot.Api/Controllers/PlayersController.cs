using LeagueOfBabyfoot.Data.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LeagueOfBabyfoot.Api.Controllers
{
	[EnableCors("*", "*", "GET,POST,PUT")]
	public class PlayersController : ApiController
	{
		private IPlayerRepository m_playerRepository;

		public PlayersController()
		{
			m_playerRepository = ObjectFactory.GetInstance<IPlayerRepository>();
		}

		public IHttpActionResult Get()
		{
			var players = m_playerRepository.GetAll();

			return Ok(players);
		}

		public IHttpActionResult Get(string id)
		{
			var player = m_playerRepository.Find(id);

			return Ok(player);
		}
	}
}
