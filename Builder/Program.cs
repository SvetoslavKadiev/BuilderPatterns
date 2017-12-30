using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BuilderPatterns.Builder
{
    public class Demo
    {
        static void Main(string[] args)
        {
            // ordinary non-fluent builder
            var i = 1;
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Svetoslav");
            builder.AddChild("li", "Viliyana");
            builder.AddChild("li", "Evgenia");
            builder.AddChild("li", "Peter");
            WriteLine($"{i}. Non-fluent builder");
            WriteLine(builder.ToString());
            
            // fluent builder
            builder.Clear(); // disengage builder from the object it's building, then...
            builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");

            i++;
            WriteLine($"{i}. Fluent builder");
            WriteLine(builder);

            ReadLine();

        }
    }

}
