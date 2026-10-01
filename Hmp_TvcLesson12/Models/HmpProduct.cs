using System;
using System.Collections.Generic;

namespace Hmp_TvcLesson12.Models;

public partial class HmpProduct
{
    public int HmpId { get; set; }

    public string? HmpName { get; set; }

    public string? HmpImage { get; set; }

    public decimal? HmpPrice { get; set; }

    public decimal? HmpSalePrice { get; set; }

    public int? HmpStatus { get; set; }

    public string? HmpDescriptions { get; set; }

    public DateTime? HmpCreatedDate { get; set; }

    public int? HmpCategoryId { get; set; }
}
