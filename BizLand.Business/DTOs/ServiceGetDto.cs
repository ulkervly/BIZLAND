using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ServiceDtos
{
    public class ServiceGetDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
