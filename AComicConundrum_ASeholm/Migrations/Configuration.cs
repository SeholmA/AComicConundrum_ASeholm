using AComicConundrum_ASeholm.Models;
using System.Collections.Generic;

namespace AComicConundrum_ASeholm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AComicConundrum_ASeholm.DAL.ComicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AComicConundrum_ASeholm.DAL.ComicContext";
        }

        protected override void Seed(AComicConundrum_ASeholm.DAL.ComicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Comic> comics = new List<Comic>
            {
                new Comic { strTitle= "Alyssa: First Adventure",    iIssueNumber=  001, strSeries= "Created by Seed()", strAuthor= "A. Seholm", strArtist= "A-Dog", strPublisher= "Comical Comics", iYearPublished = 1990 },
                new Comic { strTitle= "Alyssa: Second Adventure",   iIssueNumber=  002, strSeries= "Created by Seed()", strAuthor= "A. Seholm", strArtist= "A-Dog", strPublisher= "Comical Comics", iYearPublished = 1990 },
                new Comic { strTitle= "Alyssa: Third Adventure",    iIssueNumber=  003, strSeries= "Created by Seed()", strAuthor= "A. Seholm", strArtist= "A-Dog", strPublisher= "Comical Comics", iYearPublished = 1990 },
                new Comic { strTitle= "Alyssa: Skipped Adventures", iIssueNumber=  097, strSeries= "Created by Seed()", strAuthor= "A. Seholm", strArtist= "A-Dog", strPublisher= "Comical Comics", iYearPublished = 1990 }
            };
            comics.ForEach(c => context.Comics.Add(c));
            context.SaveChanges();   ///base.Seed(context);
        }
    }
}
