using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S3
{
    class RecipeView
    {
        public void Render(List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe != null)
                {
                    Render(recipe);
                }
            }
        }
        //Tar emot ett receptobjekt och skriver ut det.
        public void Render(Recipe recipe)
        {
            RenderHeader(recipe.Name);
            Console.WriteLine();
            Console.WriteLine("Ingredienser");
            Console.WriteLine("============");
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.WriteLine(ingredient.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Instruktioner");
            Console.WriteLine("=============");
            foreach (string direction in recipe.Directions)
            {
                Console.WriteLine(direction);
            }
            Console.WriteLine();
        }
        //Tar emot en sträng och skriver ut den som en rubrik.
        public void RenderHeader(string name)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(name);
            Console.WriteLine("-------------------------------------");
            Console.ResetColor();
        }
    }
}
