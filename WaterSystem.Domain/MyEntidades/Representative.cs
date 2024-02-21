using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Representative
{
    public int IdRepresentative { get; set; }

    public int IdCargo { get; set; }

    public string Name { get; set; } = null!;

    public string LastNameP { get; set; } = null!;

    public string LastNameM { get; set; } = null!;

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public bool? StatusRepresentative { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;
}
