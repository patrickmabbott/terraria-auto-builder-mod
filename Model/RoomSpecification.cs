using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilder.Items
{
    public class RoomSpecification
    {
        /**
         * TileName of the room.
         */
        public String Name { get; set; }
        /**
         * Which tags are allowed for non-CSLD items. (i.e. the required CSLD can fail to have these tags.
         * But, preference will be given to CSLD items which DO have one of these tags)
         */
        public String[] AllowedTags { get; set; } = { };
        /**
         * Tags that will not be allowed, even if they are the only choice for a CSLD item.
         * For example, you really don't want a toilet in your trophy room. Probably. I mean, you do you.
         */
        public String[] DisallowedTags { get; set; } = { };
        /**
         * Specific items that are required to make complete a room spec. For example, it's not a library without at least one bookcase.
         */
        public String[] RequiredTags { get; set; } = { };

        /**
         * How many amongst the required items are needed. If requiredItems.length == RequiredTagsCount, all are needed.
         * If less, you only need some number amongst those possible alternatives.
         */
        public int RequiredTagsCount { get; set; } = 0;

        public int Width { get; set; } = 20;

        public int Height { get; set; } = 10;
    }
}
