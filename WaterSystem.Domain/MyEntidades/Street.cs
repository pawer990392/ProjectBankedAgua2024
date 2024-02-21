using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Street
{
    public int Idstreet { get; set; }

    public int IdSettlement { get; set; }

    public string NameStreet { get; set; } = null!;

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<Consumer> Consumers { get; set; } = new List<Consumer>();

    public virtual Settlement IdSettlementNavigation { get; set; } = null!;

    public virtual ICollection<Toma> Tomas { get; set; } = new List<Toma>();
}
