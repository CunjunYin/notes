using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Furniture.Modern;

public class ModernDesk: Desk
{
    public string color()
    {
        return "White";
    }
}
