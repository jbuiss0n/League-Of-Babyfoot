using LeagueOfBabyfoot.Data.Entities;
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
	public class MatchsController : ApiController
	{
		private IMatchRepository m_matchRepository;

		public MatchsController()
		{
			m_matchRepository = ObjectFactory.GetInstance<IMatchRepository>();
		}

		public IHttpActionResult Get(int? limit = null)
		{
			var matchs = m_matchRepository.GetAll(take: limit);

			return Ok(matchs);
		}

		public IHttpActionResult Get(Guid id)
		{
			var match = m_matchRepository.Find(id);

			if (match == null)
				return NotFound();

			return Ok(match);
		}

		public IHttpActionResult Post([FromBody]Match value)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			if (!m_matchRepository.Add(value))
				return InternalServerError();

			return Created(Url.Link("DefaultApi", new { controller = "Match", id = value.id_Match }), value);
		}

		public IHttpActionResult Put(Guid id, [FromBody]Match value)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var match = m_matchRepository.Find(id);

			if (match == null)
				return NotFound();

			if (!m_matchRepository.Update(value))
				return InternalServerError();

			return Created(Url.Link("DefaultApi", new { controller = "Match", id = value.id_Match }), value);
		}
	}
}
