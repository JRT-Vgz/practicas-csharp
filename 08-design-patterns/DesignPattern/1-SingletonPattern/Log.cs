
namespace DesignPattern._1_Singleton
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private string _path = "log.txt";
        public static Log Instance
        {
            get { return _instance; }
        }

        private Log() { }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
