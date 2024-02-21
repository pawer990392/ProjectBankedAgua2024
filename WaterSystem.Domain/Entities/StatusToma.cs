using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class StatusToma
{
    public int IdStatusToma { get; set; }

    public string Description { get; set; } = null!;

    public bool? StatusToma1 { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<AdditionalToma> AdditionalTomas { get; set; } = new List<AdditionalToma>();

    public virtual ICollection<Toma> Tomas { get; set; } = new List<Toma>();
}
