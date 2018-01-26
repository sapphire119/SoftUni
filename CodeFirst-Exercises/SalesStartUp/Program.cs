namespace SalesStartUp
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                db.Database.EnsureDeleted();

                db.Database.Migrate();

            }
        }
    }
}
