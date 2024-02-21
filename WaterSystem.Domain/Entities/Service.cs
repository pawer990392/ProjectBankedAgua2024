using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.Entities;

public partial class Service
{
    public int Idservices { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public bool? StatusServices { get; set; }

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
