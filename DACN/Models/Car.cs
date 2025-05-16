﻿using System;
using System.Collections.Generic;

namespace DACN.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? CarName { get; set; }

    public int? Seat { get; set; }

    public string? LicensePlate { get; set; }

    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public int? Model { get; set; }

    public double? Rate { get; set; }

    public string? CarBrand { get; set; }

    public string? Image { get; set; }

    public decimal? SalePrice { get; set; }

    public string? Alias { get; set; }

    public bool IsSale { get; set; }

    public bool IsActive { get; set; }

    public string? Details { get; set; }

    public string? Descriptions { get; set; }

    public int? TypeId { get; set; }

    public virtual ICollection<CarReview> CarReviews { get; set; } = new List<CarReview>();

    public virtual CarType? Type { get; set; }
}
