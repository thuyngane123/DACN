﻿using System;
using System.Collections.Generic;

namespace DACN.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public DateTime? DateofBirth { get; set; }

    public string? Address { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseImage { get; set; }

    public string? Idcard { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AccountNumber { get; set; }

    public string? Bank { get; set; }

    public string? CompanyName { get; set; }

    public string? Avartar { get; set; }

    public virtual ICollection<CarRentalOrder> CarRentalOrders { get; set; } = new List<CarRentalOrder>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
