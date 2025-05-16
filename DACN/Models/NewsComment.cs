﻿using System;
using System.Collections.Generic;

namespace DACN.Models;

public partial class NewsComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? NewsId { get; set; }

    public bool? IsActive { get; set; }

    public virtual News? News { get; set; }
}
