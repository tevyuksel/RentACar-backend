using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string CarId { get; set; }
        public string BrandId { get; set; }
        public string ColorId { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
