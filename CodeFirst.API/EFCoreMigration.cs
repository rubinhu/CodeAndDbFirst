using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.API
{
    public class EFCoreMigration
    {
        public async Task ExecAsync(EFCoreContext context)
        {
            // Get undo migrations.
            var migrations = await context.Database.GetPendingMigrationsAsync();
            if (migrations.Count() > 0)
            {
                // Migration
                await context.Database.MigrateAsync();
            }
        }
    }
}
