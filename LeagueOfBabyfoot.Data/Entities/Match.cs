using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LeagueOfBabyfoot.Data.Entities
{
	[BsonIgnoreExtraElements]
    public class Match
	{
		[BsonId(IdGenerator = typeof(CombGuidGenerator))]
		public Guid id_Match { get; set; }

		public IEnumerable<string> FirstTeamMembers { get; set; }

		public IEnumerable<string> SecondTeamMembers { get; set; }

		public byte FirstTeamScore { get; set; }

		public byte SecondTeamScore { get; set; }
		
		public DateTime DateCreation { get; set; }

		public DateTime? DateUpdate { get; set; }

		public Match()
		{
			DateCreation = DateTime.Now;
		}
    }
}
