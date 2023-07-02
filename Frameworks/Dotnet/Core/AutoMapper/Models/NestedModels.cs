using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models;

public class OuterSource
{
    public int Value { get; set; }
    public InnerSource Inner { get; set; }
}

public class InnerSource
{
    public int OtherValue { get; set; }
}

public class OuterDest
{
    public int Value { get; set; }
    public InnerDest Inner { get; set; }
}

public class InnerDest
{
    public int OtherValue { get; set; }
}