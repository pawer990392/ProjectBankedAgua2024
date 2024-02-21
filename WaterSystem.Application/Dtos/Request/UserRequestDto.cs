using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSystem.Application.Dtos.Request
{
    public class UserRequestDto
    {
        public int IdRol { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastNameP { get; set; } = null!;
        public string LastNameM { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool? StatusUsers { get; set; }
        public string Email { get; set; } = null!;
    }
}
