namespace FootballBettingStartUp
{
    using System;

    using P03_FootballBetting.Data;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
