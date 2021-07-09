using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI5.Models
{
    public class BeerContext : DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
            builder.Entity<Beers>().Property(nameof(Beers.taste)).HasConversion(splitStringConverter);

            var splitStringConverter2 = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
            builder.Entity<Beers>().Property(nameof(Beers.type)).HasConversion(splitStringConverter2);
                
            var splitStringConverter3 = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
            builder.Entity<Beers>().Property(nameof(Beers.acquisition)).HasConversion(splitStringConverter3);
        }


        public DbSet<Beers> BeerItems { get; set; }
    }
}
