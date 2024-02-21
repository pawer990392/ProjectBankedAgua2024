using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Month
{
    public int IdMonth { get; set; }

    public string NameMonth { get; set; } = null!;

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();

    public virtual ICollection<Voucher> Idvouchers { get; set; } = new List<Voucher>();
}
