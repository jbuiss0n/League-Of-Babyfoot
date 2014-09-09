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
    public class Player
	{
		public string Name { get; set; }

		public double Score { get; set; }

		public int Played { get; set; }

		public int Diff { get; set; }

		public int Win { get; set; }

		public int Loose { get; set; }

		public int Scored { get; set; }

		public int Conceded { get; set; }
    }
}
