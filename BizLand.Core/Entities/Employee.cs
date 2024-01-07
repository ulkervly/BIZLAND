using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public string MediaUrl { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
