namespace Fornspar.Core;

public interface IDbMigrationRunner
{
    Task RunMigrationsAsync(CancellationToken cancellationToken);
}
