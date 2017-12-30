using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatterns.FluentBuilderInheritance
{
    public class Person
    {
        public string Name;

        public string Position;

        public class Builder : PersonInfoBuilder<Builder> { /* degenerate */ }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder<SELF>
        where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class BuilderInheritanceDemo
    {
        static void Main(string[] args)
        {
            //var builder = new Person.Builder();
            //var person = builder.WorksAsA("d").
            //    Console.WriteLine(person);
        }
    }
}
