using Data.Models;
using System.Data.Entity;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("onion")
        {
            
        }

        private DbSet<Person> Persons { get; set; }

       
    }
}
