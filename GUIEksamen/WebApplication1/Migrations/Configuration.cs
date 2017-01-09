using System.Collections.Generic;
using System.IO;
using Model;

namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DataAcces.FoodClubDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private byte[] Readpicture(string filename)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filename);

            return bytes;
        }

        protected override void Seed(WebApplication1.DataAcces.FoodClubDB context)
        {
            List<Member> memberList = new List<Member>
            {
                new Member
                {
                    Days = new List<Day>
                    {
                        new Day
                        {
                            Time="Mandag"
                        }
                    },
                    Name = "Simon"
                },
                new Member
                {
                    Days = new List<Day>
                    {
                        new Day
                        {
                            Time="Mandag"
                        }
                    },
                    Name = "Lars"
                },
                new Member
                {
                    Days = new List<Day>
                    {
                        new Day
                        {
                            Time="Onsdag"
                        }
                    },
                    Name = "Rasmus"
                }
            };

            List<Day> daysList = new List<Day>
            {
                new Day
                {
                    Price=300,
                    Menu = "Karryret",
                    Time = "Fredag",
                    Members = memberList
                   

                },
                new Day
                {
                    Price=240,
                    Menu = "Pizza",
                    Time = "Onsdag",
                    Members = memberList
                },
                new Day
                {
                    Price=130,
                    Menu = "Grill",
                    Time = "Mandag",
                    Members = memberList
                }
            };

            foreach (var member in memberList)
            {
                member.Days = daysList;
            }

            context.FoodClubs.Add(
                new FoodClub
                {
                    Members = memberList,
                    Days = daysList
                });
        }
    }
}
