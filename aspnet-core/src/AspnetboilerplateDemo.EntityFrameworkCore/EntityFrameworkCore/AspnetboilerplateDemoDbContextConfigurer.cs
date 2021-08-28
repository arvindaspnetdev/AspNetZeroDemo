using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspnetboilerplateDemo.EntityFrameworkCore
{
    public static class AspnetboilerplateDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspnetboilerplateDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspnetboilerplateDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
