using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Consumer
{
    public int IdConsumer { get; set; }

    public int Idstreet { get; set; }

    public int NumberExt { get; set; }

    public string? NumberInt { get; set; }

    public string Name { get; set; } = null!;

    public string LastNameP { get; set; } = null!;

    public string LastNameM { get; set; } = null!;

    public string TypeGender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<AdditionalToma> AdditionalTomas { get; set; } = new List<AdditionalToma>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Street IdstreetNavigation { get; set; } = null!;
}
