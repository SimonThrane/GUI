using System.Collections.Generic;

namespace Model
{
    public class FoodClub
    {
        public int Id { get; set; }
        public List<Member> Members { get; set; }
        public List<Day> Days { get; set; }
    }
}