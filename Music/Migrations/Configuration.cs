namespace Music.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Music.Models.MusicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Music.Models.MusicContext";
        }

        protected override void Seed(Music.Models.MusicContext context)
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
            context.Genres.AddOrUpdate(
                g => g.Name,
                new Genre { Name = "Disco" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Rock" },
                new Genre { Name = "Hip-Hop" },
                new Genre { Name = "R&B" },
                new Genre { Name = "Classic Rock" }
                );

            context.Artists.AddOrUpdate(
                a => a.Name,
                new Artist { Name = "Bee Gees" },
                new Artist { Name = "The Beach Boys" },
                new Artist { Name = "Bob Dylan" },
                new Artist { Name = "Marvin Gaye" },
                new Artist { Name = "Elvis Presley" },
                new Artist { Name = "Nirvana" },
                new Artist { Name = "Michael Jackson" },
                new Artist { Name = "Drake" },
                new Artist { Name = "Usher" },
                new Artist { Name = "Trey Songz" }
                );
        }
    }
}
