﻿using System;
using System.Collections.Generic;

namespace WaterSystem.Domain.MyEntidades;

public partial class Settlement
{
    public int IdSettlement { get; set; }

    public string Name { get; set; } = null!;

    public int CreateUser { get; set; }

    public DateTime CreateDate { get; set; }

    public int EditUser { get; set; }

    public DateTime EditDate { get; set; }

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();

    public virtual ICollection<Toma> Tomas { get; set; } = new List<Toma>();
}