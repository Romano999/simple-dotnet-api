namespace SimpleDotnetApi.Core.Settings
{
	public class DatabaseSettings
	{
		public string Server { get; set; }
		public string Port { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Database { get; set; }

		public DatabaseSettings()
		{
		}

		public DatabaseSettings(string server, string port, string user, string password, string database)
		{
			Server = server;
			Port = port;
			User = user;
			Password = password;
			Database = database;
		}
	}
}
