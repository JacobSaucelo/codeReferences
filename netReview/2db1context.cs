public class DbContextA : DbContext
{
    public DbSet<EntityA> EntitiesA { get; set; }
}

public class DbContextB : DbContext
{
    public DbSet<EntityB> EntitiesB { get; set; }
}

public class CombinedDataService
{
    private readonly DbContextA dbContextA;
    private readonly DbContextB dbContextB;

    public CombinedDataService(DbContextA dbContextA, DbContextB dbContextB)
    {
        this.dbContextA = dbContextA;
        this.dbContextB = dbContextB;
    }

    public CombinedData GetCombinedData()
    {
        var dataA = dbContextA.EntitiesA.ToList();
        var dataB = dbContextB.EntitiesB.ToList();

        var combinedData = new CombinedData
        {
            DataFromA = dataA,
            DataFromB = dataB
        };

        return combinedData;
    }
}
