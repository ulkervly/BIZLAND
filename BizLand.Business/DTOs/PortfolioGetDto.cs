using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.PortfolioDtos
{
    public class PortfolioGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
