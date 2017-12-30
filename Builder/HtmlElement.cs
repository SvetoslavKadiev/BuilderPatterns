using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int IndentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var offset = new string(' ', IndentSize * indent);

            sb.AppendLine($"{offset}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.AppendLine($"{offset}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
