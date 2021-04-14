using Microsoft.EntityFrameworkCore;
using RecipeStorage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeStorage.Tests.UnitTests.Helpers
{
    public class DbContextHelper
    {
        public static RecipeStorageDbContext GetInMemoryDbContext(string dbName)
        {
            var dbContextOptions = new DbContextOptionsBuilder<RecipeStorageDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            return new RecipeStorageDbContext(dbContextOptions);
        }
    }
}
