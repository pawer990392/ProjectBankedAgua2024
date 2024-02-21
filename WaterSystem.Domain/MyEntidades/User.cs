using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRol { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastNameP { get; set; } = null!;

    public string LastNameM { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public bool? StatusUsers { get; set; }

    public string Email { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
