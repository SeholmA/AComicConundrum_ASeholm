using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AComicConundrum_ASeholm.Models;

namespace AComicConundrum_ASeholm.DAL
{
    public class ComicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ComicContext>
    {
        /// <summary>
        /// Takes the database context object as an input parameter, and the code in the method uses that object to add new
        /// entities to the database. For each entity type (i.e. Comic), the code creates a collection of new entities, adds
        /// them to the appropriate DbSet property, and then saves the changes to the databse.
        /// </summary>
        /// <param name="context">Database context object</param>
        protected override void Seed(ComicContext context)
        {
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