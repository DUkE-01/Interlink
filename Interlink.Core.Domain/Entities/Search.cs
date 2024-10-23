using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interlink.Core.Domain.Entities
{
    public class Search
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string SearchQuery { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
