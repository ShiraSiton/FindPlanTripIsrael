using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Region
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int? ParentRegionId { get; set; }
    }
}
