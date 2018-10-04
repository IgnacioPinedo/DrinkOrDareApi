using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class DareContext : DbContext
{
    public DareContext() : base("name=DrinkOrDareDB")
    {
    }

    public DbSet<Dare> Dare { get; set; }

    public Dare GetDare()
    {
        int max = Dare.Count();
        Random random = new Random();
        int dareId = random.Next(max);

        Dare dare = Dare.Where(w => w.Id == dareId).FirstOrDefault();

        return dare;
    }
}