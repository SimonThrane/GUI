using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model;

namespace WebApplication1.DataAcces
{
    public class FoodClubDB: DbContext
    {
        public DbSet<FoodClub> FoodClubs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Day> Days { get; set; }

        public FoodClubDB()
            : base("DefaultConnection")
        {
            
        }
    }
}