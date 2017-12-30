using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HtmlElement
    {

        private List<HtmlElement> elements;
        private const int IndentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            this.Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        public string Name { get; set; }
        public string Text { get; set; }

        public List<HtmlElement> Elements
        {
            get
            {
                if (elements == null)
                {
                    this.elements = new List<HtmlElement>();
                }

                return elements;
            }
            
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var offset = new string(' ', IndentSize * indent);

            // Opening tag
            sb.AppendLine($"{offset}<{this.Name}>");
            if (!string.IsNullOrWhiteSpace(this.Text))
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.AppendLine(this.Text);
            }


            foreach (var e in this.Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            // Closing tag
            sb.AppendLine($"{offset}</{this.Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
