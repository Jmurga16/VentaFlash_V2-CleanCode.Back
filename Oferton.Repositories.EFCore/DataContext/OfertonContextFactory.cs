using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Repositories.EFCore.DataContext
{
    public class OfertonContextFactory : IDesignTimeDbContextFactory<OfertonContext>
    {
        public OfertonContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                new DbContextOptionsBuilder<OfertonContext>();

            OptionBuilder.UseSqlServer("server=.;database=DB_Oferton_V2;Trusted_Connection=True;");
            //OptionBuilder.UseSqlServer("Server=db-oferton.database.windows.net, 1433;Initial Catalog=DB_Oferton_V2;User ID=master;Password=password");


            return new OfertonContext(OptionBuilder.Options);
        }
    }
}
