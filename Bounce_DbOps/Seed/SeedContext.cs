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
                ////Plan
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 1, Name = "Bronze", FreeTrialCount = 7, DailyMeditationCount = 100, TherapistCount = 100, Cost = 50000 });
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 2, Name = "Silver", FreeTrialCount = 7, DailyMeditationCount = 200, TherapistCount = 200, Cost = 100000 });
                modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 3, Name = "Gold", FreeTrialCount = 7, DailyMeditationCount = 500, TherapistCount = 500, Cost = 200000 });

                //modelBuilder.Entity<SubPlan>().HasData(
                //new SubPlan
                //{
                //    Title = "Annual",
                //    PLanId = 3,
                //    NumberOfMeditation = 100,
                //    Cost = 100000,
                //    TherapistCount = 50,
                //    FreeTrialCount = 50,

                //});
                //modelBuilder.Entity<SubPlan>().HasData(
                //  new SubPlan
                //  {
                //      Title = "Quarter",
                //      PLanId = 3,
                //      NumberOfMeditation = 50,
                //      Cost = 80000,
                //      TherapistCount = 36,
                //      FreeTrialCount = 30,

                //  });


                #region [SubPlans]
            var subplans = new List<SubPlan>
            {
                new SubPlan
                {
                    Title = "Annual",
                    PLanId = 3,
                    NumberOfMeditation = 100,
                    Cost = 100000,
                    TherapistCount = 50,
                    FreeTrialCount = 50,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 3,
                    NumberOfMeditation = 50,
                    Cost = 80000,
                    TherapistCount = 36,
                    FreeTrialCount = 30,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 3,
                    NumberOfMeditation = 30,
                    Cost = 500000,
                    TherapistCount = 30,
                    FreeTrialCount = 20,

                },////////////////

                 new SubPlan
                {
                    Title = "Annual",
                    PLanId = 2,
                    NumberOfMeditation = 50,
                    Cost = 50000,
                    TherapistCount = 30,
                    FreeTrialCount = 20,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 2,
                    NumberOfMeditation = 40,
                    Cost = 420000,
                    TherapistCount = 30,
                    FreeTrialCount = 30,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 2,
                    NumberOfMeditation = 30,
                    Cost = 350000,
                    TherapistCount = 29,
                    FreeTrialCount = 18,

                },////////
                 new SubPlan
                {
                    Title = "Annual",
                    PLanId = 1,
                    NumberOfMeditation = 30,
                    Cost = 20000,
                    TherapistCount = 20,
                    FreeTrialCount = 10,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 1,
                    NumberOfMeditation = 20,
                    Cost = 10000,
                    TherapistCount = 15,
                    FreeTrialCount = 5,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 2,
                    NumberOfMeditation = 10,
                    Cost = 5000,
                    TherapistCount = 10,
                    FreeTrialCount = 2,

                },
            };
                #endregion
                var i = 0 ;
                foreach (var entity in subplans)
                {
                    i++;
                    modelBuilder.Entity<SubPlan>().HasData(new SubPlan
                    {
                        Id = i,
                        Title = entity.Title,
                        PLanId = entity.PLanId,
                        NumberOfMeditation = entity.NumberOfMeditation,
                        Cost = entity.Cost,
                        TherapistCount = entity.TherapistCount,
                        FreeTrialCount = entity.FreeTrialCount,

                    });
                }
                ////SubPlan


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
