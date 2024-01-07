using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.MemberDtos
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int ProfessionId { get; set; }
        
        public string MediaUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
