using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public bool? StatusTarifa { get; set; }

    public virtual ICollection<AdditionalToma> AdditionalTomas { get; set; } = new List<AdditionalToma>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Toma> Tomas { get; set; } = new List<Toma>();
}
