using System;

public class ConfigurationManager
{
    private static ConfigurationManager instance = null;
    private static readonly object padlock = new object();

    public string LoggingMode { get; set; }
    public string DatabaseConnectionSettings { get; set; }

    private ConfigurationManager()
    {
        // Приватний конструктор, щоб запобігти створенню екземплярів ззовні класу
    }

    public static ConfigurationManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
                return instance;
            }
        }
    }

    public void ChangeSettings(string loggingMode, string databaseConnectionSettings)
    {
        LoggingMode = loggingMode;
        DatabaseConnectionSettings = databaseConnectionSettings;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        Console.WriteLine("Enter logging mode:");
        string loggingMode = Console.ReadLine();

        Console.WriteLine("Enter database connection settings:");
        string databaseConnectionSettings = Console.ReadLine();

        configManager.ChangeSettings(loggingMode, databaseConnectionSettings);

        Console.WriteLine("Logging mode: " + configManager.LoggingMode);
        Console.WriteLine("Database connection settings: " + configManager.DatabaseConnectionSettings);

        Console.ReadKey();
    }
}