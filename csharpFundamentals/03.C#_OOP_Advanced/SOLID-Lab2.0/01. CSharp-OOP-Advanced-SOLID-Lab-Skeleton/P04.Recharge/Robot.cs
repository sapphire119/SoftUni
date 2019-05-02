using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;

        public Robot(string id, int capacity) 
            : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity => this.capacity;

        public int CurrentPower { get; private set; }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }

        public override void Work(int hours)
        {
            if (hours > this.Capacity)
            {
                hours = this.Capacity;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }
    }
}