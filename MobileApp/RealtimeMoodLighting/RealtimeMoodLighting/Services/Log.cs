using System.Diagnostics;
using System.Text;

namespace RealtimeMoodLighting.Services
{
    public class Log
    {
        private StringBuilder sb = new StringBuilder();

        public Log()
        {
        }

        public void Write(string text)
        {
            var logLine = "RTML: " + text;
            sb.AppendLine(logLine);
            Debug.WriteLine(logLine);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
