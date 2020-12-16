namespace Bussines.DAO
{
    public static class ConnectionString
    {
        private static string conString =
            @"Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=vjacheslavovich;";

        public static string Get()
        {
            return conString;
        }

        public static void Update(string server, string port, string database, string userId, string password)
        {
            conString = $"Server={server};Port={port};Database={database};User Id={userId};Password={password};";
        }
    }
}