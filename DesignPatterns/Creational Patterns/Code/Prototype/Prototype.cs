using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Prototype;

public class Prototype
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public Prototype ShallowClone()
    {
        return (Prototype)this.MemberwiseClone();
    }

    public Prototype DeepClone()
    {
        Prototype clone = (Prototype)this.MemberwiseClone();
        clone.Date = DateTime.Parse(Date.ToString());
        return clone;
    }
}
