using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Type
{
    public class TypeDto
    {
        public int Id { get; set; }
        public ContentType ContentType { get; set; }
        public string TypeName { get; set; }
    }
}
