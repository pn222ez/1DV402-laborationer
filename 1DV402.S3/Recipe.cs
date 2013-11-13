using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S3
{
    class Recipe : IComparable, IComparable<Recipe>
    {
        public List<string> _directions = new List<string>();
        public List<Ingredient> _ingredients = new List<Ingredient>();
        public string _name;

        public Recipe(string name)
        {
           Name = name;
        }

        public Recipe(string name, List<Ingredient> ingredients, List<string>
directions)
        {
            Name = name;  
            _ingredients = new List<Ingredient>(ingredients);
            _directions = new List<string>(directions);
            
        }
        //Lägger till en ingrediens till ingredienslistan.
        public void Add(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }
        //Lägger till en instruktion till instruktionslistan.
        public void Add(string direction)
        {
            _directions.Add(direction);
        }

        public ReadOnlyCollection <string> Directions
        {
            get
            {
                return _directions.AsReadOnly();
            }
        }

        public ReadOnlyCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients.AsReadOnly();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null && value != "")
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Felaktigt värde");
                }
            }
        }
        //Överlagring av CompareTo där ett objekt jämförs med ett annat.
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Recipe otherRecipe = obj as Recipe;
            if (otherRecipe != null)
                return this.Name.CompareTo(otherRecipe.Name);
            else
                throw new ArgumentException("Objectet är inte giltigt");
        }
        //Överlagring av CompareTo där ett Recipe-objekt jämförs med ett annat.
        public int CompareTo(Recipe other)
        {
            if (other == null) return 1;

            if (other != null)
                return this.Name.CompareTo(other.Name);
            else
                throw new ArgumentException("Objectet är inte giltigt");
        }
    }
}
