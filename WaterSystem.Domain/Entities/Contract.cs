using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Contract
{
    public int IdContract { get; set; }

    public int IdConsumer { get; set; }

    public int Idservices { get; set; }

    public int IdTarifa { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual Consumer IdConsumerNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;

    public virtual Service IdservicesNavigation { get; set; } = null!;

    public virtual ICollection<Toma> Tomas { get; set; } = new List<Toma>();
}
