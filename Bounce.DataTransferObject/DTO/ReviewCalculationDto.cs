using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO
{
    public class ReviewCalculationDto
    {
        public object Reviews { get; set; }
        public int TotalRating { get; set; }
        public int OneStarPercent { get; set; }
        public int TwoStarPercent { get; set; }
        public int ThreeStarPercent { get; set; }
        public int FourStarPercent { get; set; }
        public int FiveStarPercent { get; set; }
        public decimal Ratio { get; set; }

    }
}
