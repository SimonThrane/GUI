using System;
using System.Collections.Generic;

namespace Model
{
    public class Day
    {
        public int DayId { get; set; }
        public string Menu { get; set; }
        public List<Member> Members { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public byte[] Picture { get; set; }

    }
}