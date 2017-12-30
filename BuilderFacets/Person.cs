using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatterns.BuilderFacets
{
    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}:\t {StreetAddress}\n" +
                   $"{nameof(Postcode)}: \t {Postcode}\n" +
                   $"{nameof(City)}:\t\t {City}\n" +
                   $"{nameof(CompanyName)}:\t {CompanyName}\n" +
                   $"{nameof(Position)}:\t {Position}\n" +
                   $"{nameof(AnnualIncome)}:\t {AnnualIncome}";
        }
    }
}
