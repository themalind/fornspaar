using Fornspar.Core;
using Fornspar.Data.Db;

using Microsoft.EntityFrameworkCore;

namespace Fornspar.Data;

internal class DbMigrationRunner(IDbContextFactory<FornsparDbContext> dbContextFactory) : IDbMigrationRunner
{
    private readonly IDbContextFactory<FornsparDbContext> dbContextFactory = dbContextFactory;

    public async Task RunMigrationsAsync(CancellationToken cancellationToken)
    {
        var dbContext = await this.dbContextFactory.CreateDbContextAsync(cancellationToken);
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}