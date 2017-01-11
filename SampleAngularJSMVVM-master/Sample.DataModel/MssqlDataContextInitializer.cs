using System.Data.Entity;

namespace Sample.DataModel
{
    public class MssqlDataContextInitializer : DropCreateDatabaseIfModelChanges<MssqlDataContext>
    {
    }
}
