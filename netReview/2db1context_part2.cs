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
        using (dbContextA)
        using (dbContextB)
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
}
