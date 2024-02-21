using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Voucher
{
    public int IdVoucher { get; set; }

    public int IdToma { get; set; }

    public decimal AmountPay { get; set; }

    public int YearPagado { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual Toma IdTomaNavigation { get; set; } = null!;

    public virtual ICollection<VoucherDebt> VoucherDebts { get; set; } = new List<VoucherDebt>();

    public virtual ICollection<Month> IdMonths { get; set; } = new List<Month>();
}
