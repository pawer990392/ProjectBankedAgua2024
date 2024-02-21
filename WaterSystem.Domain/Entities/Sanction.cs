using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Sanction
{
    public int IdSanction { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public bool? StatusSancion { get; set; }

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();
}
