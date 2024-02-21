using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Debt
{
    public int IdDebts { get; set; }

    public int IdToma { get; set; }

    public int IdSanction { get; set; }

    public int IdexpiredMonth { get; set; }

    public int ExpiredYear { get; set; }

    public DateTime CreateDebts { get; set; }

    public bool StatusPay { get; set; }

    public virtual Sanction IdSanctionNavigation { get; set; } = null!;

    public virtual Toma IdTomaNavigation { get; set; } = null!;

    public virtual Month IdexpiredMonthNavigation { get; set; } = null!;

    public virtual ICollection<VoucherDebt> VoucherDebts { get; set; } = new List<VoucherDebt>();
}
