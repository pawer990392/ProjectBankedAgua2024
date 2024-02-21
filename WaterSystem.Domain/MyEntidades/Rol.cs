using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Description { get; set; } = null!;

    public bool? StatusRol { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateModifity { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
