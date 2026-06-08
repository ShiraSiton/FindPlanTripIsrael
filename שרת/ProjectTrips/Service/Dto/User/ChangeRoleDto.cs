using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.User
{
    public class ChangeRoleDto
    {
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
    }
}
