using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S3
{
    struct Ingredient
    {
        public string Amount { get; set; }
        public string Measure { get; set; }
        public string Name { get; set; }

        //Överlagring av ToString som returnerar en formaterad sträng med Amount, Measure och Name.
        public override string ToString()
        {
            string returnString = null;
            if (Amount.Length > 0)
            {
                returnString = Amount;
            }
            if (Measure.Length > 0)
            {
                returnString = returnString + " " + Measure;
            }
            if (returnString == null)
            {
                returnString = Name;
            }
            else
            {
                returnString = returnString + " " + Name;
            }
            return returnString;
        }
    }
}
