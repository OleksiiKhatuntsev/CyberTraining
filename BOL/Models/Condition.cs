using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BOL.Models
{
    public class Condition
    {
        public int ConditionId { get; set; }

        [DisplayName("Temperature")]
        public double Temperature { get; set; }

        [DisplayName("Pulse")]
        public int Pulse { get; set; }

        [DisplayName("Room Temperature")]
        public double RoomTemperature { get; set; }

        [DisplayName("Conditions time")]
        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
