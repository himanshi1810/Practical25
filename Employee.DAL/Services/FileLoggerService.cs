namespace Employee.DAL.Services
{
    public class FileLoggerService : ILoggerService
    {
        private readonly string logFile = "log.txt";

        public FileLoggerService()
        {
            if (!File.Exists(logFile))
                File.Create(logFile).Close();
        }

        public void Log(string message)
        {
            File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
