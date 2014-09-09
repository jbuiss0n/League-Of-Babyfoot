using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfBabyfoot.Data.Entities
{
	[BsonIgnoreExtraElements]
	internal class ReducedResult<T>
		where T : class
	{
		public T value { get; set; }
	}
}
