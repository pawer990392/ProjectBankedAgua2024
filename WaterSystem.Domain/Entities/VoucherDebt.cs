using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class VoucherDebt
{
    public int IdVoucher { get; set; }

    public int IdDebts { get; set; }

    public DateTime DebtsPaidDate { get; set; }

    public virtual Debt IdDebtsNavigation { get; set; } = null!;

    public virtual Voucher IdVoucherNavigation { get; set; } = null!;
}
