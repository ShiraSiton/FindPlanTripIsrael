using Service.Dto.Region;
using Service.Dto.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class LookupsDto
    {
        public List<RegionDto> Regions { get; set; }
        public List<EnumValueDto> Difficulties { get; set; }
        public List<EnumValueDto> Accessibilities { get; set; }
        public List<TypeDto> TripTypes { get; set; }
    }
}
