using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Furniture.Modern;

internal class ModernDesk: Desk
{
    public override string color()
    {
        return "White";
    }
}
