using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S3
{
    class RecipeRepository
    {
        public enum RecipeReadStatus { Indefinate, New, Ingredient, Direction };

        private string _path;

        public RecipeRepository(string path)
        {
            Path = path;
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Felaktigt värde");
                }
                else
                {
                    _path = value;
                }
            }
        }
        //Läser igenom en textfil. Textfilens sökväg är fältet "_path". För varje rad sätts statusen till antingen "Indefinate", "Ingredient", "Direction" eller "New" beroende på vad raden innehåller.
        //Om statusen är "New" skapas ett nytt Recipe-objekt. Om statusen är "Ingredient" läggs raden till ingredienslistan. Om statusen är "Direction" läggs raden till instruktionslistan. 
        //Om statusen är "Indefinate" händer ingen och nästa rad läses in. När statusen ändras till new eller om textfilen är slut läggs receptet till listan över recept. 
        //När textfilen lästs klart sorteras receptlistan och returneras.
        public List<Recipe> Load()
        {
            List<Recipe> recipeList = new List<Recipe>();
            try
            {
                Recipe recipe = null;
                int rowCount = 0;
                RecipeReadStatus status = RecipeReadStatus.Indefinate;
                using (StreamReader sr = new StreamReader(this.Path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        rowCount++;
                        try
                        {
                            if (line == String.Empty)
                            {
                                status = RecipeReadStatus.Indefinate;
                            }
                            else if (line == "[Recept]")
                            {
                                status = RecipeReadStatus.New;
                            }
                            else if (line == "[Ingredienser]")
                            {
                                status = RecipeReadStatus.Ingredient;
                            }
                            else if (line == "[Instruktioner]")
                            {
                                status = RecipeReadStatus.Direction;
                            }
                            else
                            {
                                if (status == RecipeReadStatus.New)
                                {
                                    recipe = new Recipe(line);
                                    status = RecipeReadStatus.Indefinate;
                                }
                                else if (status == RecipeReadStatus.Ingredient)
                                {
                                    string[] ingredientsContainer = line.Split(';');
                                    try
                                    {
                                        Ingredient ingredient = new Ingredient();
                                        ingredient.Amount = ingredientsContainer[0];
                                        ingredient.Measure = ingredientsContainer[1];
                                        ingredient.Name = ingredientsContainer[2];
                                        recipe.Add(ingredient);
                                    }
                                    catch
                                    {
                                        throw new ArgumentException("Någonting blev fel");
                                    }
                                }
                                else if (status == RecipeReadStatus.Direction)
                                {
                                    recipe.Add(line);
                                }
                            }
                            if ((status == RecipeReadStatus.New && rowCount != 1) || sr.Peek() < 0)
                            {
                                recipeList.Add(recipe);
                            }
                        }
                        catch
                        {
                            throw new ArgumentException("Någonting blev fel");
                        }
                    }
                }
                recipeList.Sort();
                return recipeList;
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return null;

        }
        //Skriver till en textfil vars sökväg är fältet "_path". För varje recept i listan skapas en rubrik för "Recept", "Ingredienser" och "Instruktioner".
        //Ingrediensernas "Namn", "Mängd" och "Enhet" skiljs med ett semikolon.
        public void Save(List<Recipe> recipes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.Path, false))
                {

                    foreach (Recipe recipe in recipes)
                    {
                        sw.WriteLine("[Recept]");
                        sw.WriteLine(recipe.Name);
                        sw.WriteLine("[Ingredienser]");
                        foreach (Ingredient ingredient in recipe.Ingredients)
                        {
                            sw.WriteLine(ingredient.Amount + ";" + ingredient.Measure + ";" + ingredient.Name);
                        }
                        sw.WriteLine("[Instruktioner]");
                        foreach (string direction in recipe.Directions)
                        {
                            sw.WriteLine(direction);
                        }

                    }

                }
            }
            catch
            {
                throw new ApplicationException("Filen kunde inte sparas");
            }
        }

    }
}
