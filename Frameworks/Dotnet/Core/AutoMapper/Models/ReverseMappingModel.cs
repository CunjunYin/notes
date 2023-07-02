using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models;

public class ReverseMappingModelOrder
{
    public decimal Total { get; set; }
    public ReverseMappingModelCustomer Customer { get; set; }
}

public class ReverseMappingModelCustomer
{
    public string Name { get; set; }
}
