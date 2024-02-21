using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string Description { get; set; } = null!;

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public bool? StatusCargos { get; set; }

    public virtual ICollection<Representative> Representatives { get; set; } = new List<Representative>();
}
