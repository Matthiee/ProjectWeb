using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eva.Models.DAL
{
    public class EvaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EvaContext>
    {
        protected override void Seed(EvaContext context)
        {
            var evaluaties = new List<Evaluatie>
            {
                new Evaluatie { naam = "Goed" },
                new Evaluatie { naam = "Slecht" }
            };

            evaluaties.ForEach(e => context.Evaluaties.Add(e));
            context.SaveChanges();
        }

    }
}