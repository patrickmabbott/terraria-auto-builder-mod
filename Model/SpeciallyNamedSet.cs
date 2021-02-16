using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilder.Items
{
    /**
     * Maps out sets known to not follow standard naming conventions for walls vs brick/block vs furniture item.
     * For example, Ice/Frozen and Sunplate/Skyware
     * In general, this will only cover vanilla sets.
     */
    public class SpeciallyNamedSet
    {
        public String WallName;
        public String BlockName;
        public String FurniturePrefix;
    }
}
