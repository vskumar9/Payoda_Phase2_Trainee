using System;
using System.Collections.Generic;

namespace MVCEFDBFirst.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string ProductName { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;
}
