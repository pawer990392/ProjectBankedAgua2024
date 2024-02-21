using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class AdditionalToma
{
    public int IdAdditionalToma { get; set; }

    public int IdToma { get; set; }

    public int IdConsumer { get; set; }

    public int IdTarifa { get; set; }

    public int IdStatusToma { get; set; }

    public string? DescriptionToma { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual Consumer IdConsumerNavigation { get; set; } = null!;

    public virtual StatusToma IdStatusTomaNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;

    public virtual Toma IdTomaNavigation { get; set; } = null!;
}
