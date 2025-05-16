﻿using System;
using System.Collections.Generic;

namespace DACN.Models;

public partial class CarType
{
    public int TypeId { get; set; }

    public string? CarTypeName { get; set; }

    public int? Seats { get; set; }

    public string? Manufacturer { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
}
