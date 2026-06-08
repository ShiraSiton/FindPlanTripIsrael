using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Type
{
    public class TypeCreateUpdateDto
    {
        public ContentType ContentType { get; set; }
        public string TypeName { get; set; }
    }
}
