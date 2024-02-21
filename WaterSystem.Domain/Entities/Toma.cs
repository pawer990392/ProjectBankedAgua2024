using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Toma
{
    public int IdToma { get; set; }

    public int IdContract { get; set; }

    public int IdSettlement { get; set; }

    public int Idstreet { get; set; }

    public int IdTarifa { get; set; }

    public int IdStatusToma { get; set; }

    public string? DescripcionToma { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<AdditionalToma> AdditionalTomas { get; set; } = new List<AdditionalToma>();

    public virtual ICollection<Debt> Debts { get; set; } = new List<Debt>();

    public virtual Contract IdContractNavigation { get; set; } = null!;

    public virtual Settlement IdSettlementNavigation { get; set; } = null!;

    public virtual StatusToma IdStatusTomaNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;

    public virtual Street IdstreetNavigation { get; set; } = null!;

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
