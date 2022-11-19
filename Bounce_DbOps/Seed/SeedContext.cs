using Bounce_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    public static class SeedContext 
    {
        public static void SeedData(this ModelBuilder? modelBuilder)
        {

            if (modelBuilder != null)
            {
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 1, Name = "Bronze", FreeTrialCount = 7, DailyMeditationCount = 100, TherapistCount = 100, Cost = 50000 });
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 2, Name = "Silver", FreeTrialCount = 7, DailyMeditationCount = 200, TherapistCount = 200, Cost = 100000 });
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 3, Name = "Gold", FreeTrialCount = 7, DailyMeditationCount = 500, TherapistCount = 500, Cost = 200000 });

                ///////FeedGroup
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 1, Name = "Relationship" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 2, Name = "Self Care" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 3, Name = "Work Ethics" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 4, Name = "Family" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 5, Name = "Self Care" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 6, Name = "Sexuality" });
                modelBuilder.Entity<FeedGroup>().HasData(new FeedGroup { Id = 7, Name = "Parenting" });
            }

        }
    }
}
