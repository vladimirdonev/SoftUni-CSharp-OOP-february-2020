using Logger.Models.Contracts;
using System.Linq;
using System.Text;

namespace Logger.Models.Layouts
{
    public class XMLLayout : ILayout
    {
        public string Format => this.GetDataFormat();

        private string GetDataFormat()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<log>");
                builder.AppendLine("<date>{0}</date>");
                builder.AppendLine("<level>{1}</level>");
                builder.AppendLine("<message>{2}</message>");
            builder.AppendLine("</log>");
            return builder.ToString().TrimEnd();
        }
    }
}
