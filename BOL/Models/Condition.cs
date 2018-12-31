using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Models
{
    public class Condition
    {
        public int ConditionId { get; set; }

        public double Temperature { get; set; }

        public int Pulse { get; set; }

        public double RoomTemperature { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
