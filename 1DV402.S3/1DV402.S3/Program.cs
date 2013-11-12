using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S3
{
    class Program
    {
        //Tar emot en sträng och en konsollfärg och presenterar strängen i den färgen.
        public static void ChangeConsoleColor(string message, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        //Tar emot en instruktionslista och byter plats på två instruktioner utifrån användarens val och returnerar sedan den nya listan.
        public static List<string> ChangeDirectionPosition(List<string> directions)
        {
            while (true)
            {
                string[] stringForMenu = new string[directions.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < directions.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + directions[i];
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Ange numret på den instruktion du vill byta plats på");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return directions;
                }
                else
                {
                    bool success = false;
                    while (success == false)
                    {
                        Console.WriteLine();
                        int menuChoice2 = GetMenuChoice(stringForMenu, "Ange vilken position du vill flytta '" + directions[menuChoice - 1] + "' till");
                        if (menuChoice2 == 0)
                        {
                            Console.Clear();
                            return directions;
                        }
                        else
                        {
                            string temp = directions[menuChoice - 1];
                            directions.RemoveAt(menuChoice - 1);
                            directions.Insert(menuChoice2 - 1, temp);
                            Console.Clear();
                            ChangeConsoleColor("Instruktionen har bytt plats", ConsoleColor.DarkGreen);
                            return directions;
                        }
                    }
                }
            }
        }
        //Tar emot en ingredienslista och byter plats på två ingredienser utifrån användarens val och returnerar sedan den nya listan.
        public static List<Ingredient> ChangeIngredientPosition(List<Ingredient> ingredients)
        {
            while (true)
            {
                string[] stringForMenu = new string[ingredients.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < ingredients.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + ingredients[i].ToString();
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Ange numret på den ingrediens du vill byta plats på");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return ingredients;
                }
                else
                {
                    bool success = false;
                    while (success == false)
                    {
                        int menuChoice2 = GetMenuChoice(stringForMenu, "Ange vilken position du vill flytta '" + ingredients[menuChoice - 1].ToString() + "' till. ");
                        if (menuChoice2 == 0)
                        {
                            Console.Clear();
                            return ingredients;
                        }
                        else
                        {
                            Ingredient temp = ingredients[menuChoice - 1];
                            ingredients.RemoveAt(menuChoice - 1);
                            ingredients.Insert(menuChoice2 - 1, temp);
                            Console.Clear();
                            ChangeConsoleColor("Ingrediensen har bytt plats", ConsoleColor.DarkGreen);
                            return ingredients;
                        }
                    }
                }
            }
        }
        //Tar emot en lista med instruktioner, tar bort en instruktion från listan utifrån användaren val och returnerar sedan den nya listan.
        public static List<string> RemoveDirection(List<string> directions)
        {
            while (true)
            {
                string[] stringForMenu = new string[directions.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < directions.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + directions[i];
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Ta bort instruktion");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return directions;
                }
                else
                {
                    bool success = false;
                    while (success == false)
                    {
                        Console.Write("Vill du ta bort {0}? J/N ", directions[menuChoice - 1]);
                        string input = Console.ReadLine();
                        if (input == "j")
                        {
                            directions.RemoveAt(menuChoice - 1);
                            success = true;
                            Console.Clear();
                            ChangeConsoleColor("Instruktionen har tagits bort", ConsoleColor.DarkGreen);
                            return directions;
                        }
                        else if (input == "n")
                        {
                            success = true;
                            Console.Clear();
                            return directions;
                        }
                    }
                }
            }
        }
        //Tar emot en lista med ingredienser, tar bort en ingrediens från listan utifrån användaren val och returnerar sedan den nya listan.
        public static List<Ingredient> RemoveIngredient(List<Ingredient> ingredients)
        {
            while (true)
            {
                string[] stringForMenu = new string[ingredients.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < ingredients.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + ingredients[i].ToString();
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Ta bort ingrediens");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return ingredients;
                }
                else
                {
                    bool success = false;
                    while (success == false)
                    {
                        Console.Write("Vill du ta bort {0}? J/N ", ingredients[menuChoice - 1].ToString());
                        string input = Console.ReadLine();
                        if (input == "j")
                        {
                            ingredients.RemoveAt(menuChoice - 1);
                            success = true;
                            Console.Clear();
                            ChangeConsoleColor("Ingrediensen har tagits bort", ConsoleColor.DarkGreen);
                            return ingredients;
                        }
                        else if (input == "n")
                        {
                            success = true;
                            Console.Clear();
                            return ingredients;
                        }
                    }
                }
            }
        }
        //Tar emot en lista med instruktioner, låter användaren lägga till en instruktion till listan och returnerar sedan den nya listan.
        public static List<string> AddDirection(List<string> directions)
        {
            Console.Write("Vilken instruktion vill du lägga till? Tom instruktion avslutar. ");
            string direction = Console.ReadLine();
            if (string.IsNullOrEmpty(direction) || string.IsNullOrWhiteSpace(direction))
            {
                Console.Clear();
                return directions;
            }
            else
            {
                directions.Add(direction);
                Console.Clear();
                ChangeConsoleColor("Instruktionen har lagts till", ConsoleColor.DarkGreen);
                return directions;
            }
        }
        //Tar emot en lista med ingredienser, låter användaren lägga till en ingrediens till listan och returnerar sedan den nya listan.
        public static List<Ingredient> AddIngredient(List<Ingredient> ingredients)
        {
            Console.Write("Vad heter ingrediensen du vill lägga till? Tomt namn avslutar. ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                return ingredients;
            }
            else
            {
                Console.Write("Hur mycket av {0}? ", name);
                string amount = Console.ReadLine();
                Console.Write("Vilken enhet av mängden? (Exempel dl, l, st). ", name);
                string measure = Console.ReadLine();
                Ingredient ingredient = new Ingredient();
                ingredient.Name = name;
                ingredient.Amount = amount;
                ingredient.Measure = measure;
                ingredients.Add(ingredient);
                Console.Clear();
                ChangeConsoleColor("Ingrediensen har lagts till", ConsoleColor.DarkGreen);
                return ingredients;
            }
        }
        //Tar emot en lista med instruktioner och låter användaren ändra ett visst index i den och returnerar sedan den nya listan.
        public static List<string> EditDirections(List<string> directions)
        {
            while (true)
            {
                string[] stringForMenu = new string[directions.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < directions.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + directions[i].ToString();
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Redigera instruktioner");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return directions;
                }
                else
                {
                    Console.WriteLine("Ny instruktion för rad {0}: ", menuChoice);
                    string newString = Console.ReadLine();
                    if (!(string.IsNullOrEmpty(newString) || string.IsNullOrWhiteSpace(newString)))
                    {
                        directions[menuChoice - 1] = newString;
                    }
                    Console.Clear();
                }
            }
        }
        //Tar emot en lista med ingredienser och låter användaren ändra ett visst index i den och returnerar sedan den nya listan.
        public static List<Ingredient> EditIngredient(List<Ingredient> ingredients)
        {
            while (true)
            {
                string[] stringForMenu = new string[ingredients.Count + 1];
                stringForMenu[0] = "0. Tillbaka";
                for (int i = 0; i < ingredients.Count; i++)
                {
                    stringForMenu[i + 1] = (i + 1) + ". " + ingredients[i].ToString();
                }

                int menuChoice = GetMenuChoice(stringForMenu, "Redigera ingredienser");
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return ingredients;
                }
                else
                {
                    string[] typeMenu = new string[4] { "0. Tillbaka", "1. Mängd: " + ingredients[menuChoice - 1].Amount, "2. Mått: " + ingredients[menuChoice - 1].Measure, "3. Ingrediensnamn: " + ingredients[menuChoice - 1].Name };

                    int menuChoice2 = GetMenuChoice(typeMenu, "Redigera " + ingredients[menuChoice - 1].Name);
                    if (menuChoice2 == 0)
                    {
                        Console.Clear();
                    }
                    if (menuChoice2 == 1)
                    {
                        Console.Write("Ny mängd: ");
                        string newAmount = Console.ReadLine();
                        if (!(string.IsNullOrEmpty(newAmount) || string.IsNullOrWhiteSpace(newAmount)))
                        {
                            Ingredient temp = ingredients[menuChoice - 1];
                            temp.Amount = newAmount;
                            ingredients[menuChoice - 1] = temp;
                        }
                    }
                    if (menuChoice2 == 2)
                    {
                        Console.Write("Nytt mått: ");
                        string newMeasure = Console.ReadLine();
                        if (!(string.IsNullOrEmpty(newMeasure) || string.IsNullOrWhiteSpace(newMeasure)))
                        {
                            Ingredient temp = ingredients[menuChoice - 1];
                            temp.Measure = newMeasure;
                            ingredients[menuChoice - 1] = temp;
                        }
                    }
                    if (menuChoice2 == 3)
                    {
                        Console.Write("Nytt ingrediensnamn: ");
                        string newName = Console.ReadLine();
                        if (!(string.IsNullOrEmpty(newName) || string.IsNullOrWhiteSpace(newName)))
                        {
                            Ingredient temp = ingredients[menuChoice - 1];
                            temp.Name = newName;
                            ingredients[menuChoice - 1] = temp;
                        }
                    }
                    Console.Clear();

                }
            }
        }
        //Tar emot ett receptobjekt och en receptlista. Tar reda på vilket index i listan receptet finns. Frågar sedan användaren på vilket sätt den vill redigera receptet.
        //Sedan anropas respektive metod utifrån vilket val användaren gjort. Det nya receptet placeras i samma index och när användaren är klar returneras listan.
        public static List<Recipe> EditRecipe(Recipe recipe, List<Recipe> recipes)
        {
            int index = recipes.IndexOf(recipe);

            while (true)
            {
                string[] editMenu = new string[] { "0. Tillbaka", "1. Redigera ingredienser", "2. Redigera instruktioner", "3. Lägg till ingredienser", "4. Lägg till instruktioner", "5. Ta bort ingredienser", "6. Ta bort instruktioner", "7. Ändra ordning på ingredienser", "8. Ändra ordning på instruktioner" };
                int menuChoice = GetMenuChoice(editMenu, "Redigera " + recipe.Name);
                if (menuChoice == 0)
                {
                    Console.Clear();
                    return recipes;
                }


                List<Ingredient> ingredientsToEdit = new List<Ingredient>(recipes[index].Ingredients);
                List<string> directionsCopy = new List<string>(recipe.Directions);

                List<string> directionsToEdit = new List<string>(recipes[index].Directions);
                List<Ingredient> ingredientCopy = new List<Ingredient>(recipe.Ingredients);


                if (menuChoice == 1)
                {
                    ingredientsToEdit = EditIngredient(ingredientsToEdit);
                    Recipe newRecipeForIngredient = new Recipe(recipe.Name, ingredientsToEdit, directionsCopy);
                    recipes[index] = newRecipeForIngredient;
                }
                if (menuChoice == 2)
                {
                    directionsToEdit = EditDirections(directionsToEdit);
                    Recipe newRecipeForDirections = new Recipe(recipe.Name, ingredientCopy, directionsToEdit);
                    recipes[index] = newRecipeForDirections;
                }
                if (menuChoice == 3)
                {
                    ingredientsToEdit = AddIngredient(ingredientsToEdit);
                    Recipe newRecipeForIngredient = new Recipe(recipe.Name, ingredientsToEdit, directionsCopy);
                    recipes[index] = newRecipeForIngredient;
                }
                if (menuChoice == 4)
                {
                    directionsToEdit = AddDirection(directionsToEdit);
                    Recipe newRecipeForDirections = new Recipe(recipe.Name, ingredientCopy, directionsToEdit);
                    recipes[index] = newRecipeForDirections;
                }
                if (menuChoice == 5)
                {
                    ingredientsToEdit = RemoveIngredient(ingredientsToEdit);
                    Recipe newRecipeForIngredient = new Recipe(recipe.Name, ingredientsToEdit, directionsCopy);
                    recipes[index] = newRecipeForIngredient;
                }
                if (menuChoice == 6)
                {
                    directionsToEdit = RemoveDirection(directionsToEdit);
                    Recipe newRecipeForDirections = new Recipe(recipe.Name, ingredientCopy, directionsToEdit);
                    recipes[index] = newRecipeForDirections;
                }
                if (menuChoice == 7)
                {
                    ingredientsToEdit = ChangeIngredientPosition(ingredientsToEdit);
                    Recipe newRecipeForIngredient = new Recipe(recipe.Name, ingredientsToEdit, directionsCopy);
                    recipes[index] = newRecipeForIngredient;
                }
                if (menuChoice == 8)
                {
                    directionsToEdit = ChangeDirectionPosition(directionsToEdit);
                    Recipe newRecipeForDirections = new Recipe(recipe.Name, ingredientCopy, directionsToEdit);
                    recipes[index] = newRecipeForDirections;
                }


            }

        }
        //Tar emot en lista av recept som ska sökas i och en söksträng. Strängen splittas på mellanslagen och för varje delsträng söks det efter ingredienser i listan som matchar.
        //Hittas sökordet i ingredienserna läggs det resultatet till till resultatlistan. För att receptet ska läggas till måste alla delsträngar matcha just det receptet.
        //Resulatatlistan returneras sedan.
        public static List<Recipe> FindRecipes(List<Recipe> recipes, string input)
        {
            List<Recipe> resultList = new List<Recipe>();
            string[] splitted = input.Split(' ');
            int searchwords = splitted.Length;
            foreach (Recipe recipe in recipes)
            {
                List<bool> contains = new List<bool>();
                List<Ingredient> ingredients = new List<Ingredient>(recipe.Ingredients);
                for (int i = 0; i < splitted.Length; i++)
                {
                    int index = ingredients.FindIndex(
                    delegate(Ingredient ingredient)
                    {
                        return ingredient.Name == splitted[i];
                    }
                    );
                    if (index >= 0)
                    {
                        contains.Add(true);
                    }
                    else
                    {
                        contains.Add(false);
                    }
                }
                if (!contains.Contains(false))
                {
                    resultList.Add(recipe);
                }
            }
            return resultList;
        }
        //Metoden anropar först ReadRecipeName för att få ett receptnamn, sedan ReadIngreadents för att få en ingredienslista, sedan ReadDirections för att få en instruktionslista.
        //Vid varje steg avslutas metoden om någon av metoderna som anropas returnerar "null". Gör de inte det skapas ett nytt receptobjekt som returneras.
        public static Recipe CreateRecipe()
        {
            string name = ReadRecipeName();
            if (name == null)
            {
                Console.Clear();
                return null;
            }
            else
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                ingredients = ReadIngredients();
                if (ingredients == null)
                {
                    Console.Clear();
                    return null;
                }
                else
                {
                    List<string> directions = new List<string>();
                    directions = ReadDirections();
                    if (directions == null)
                    {
                        Console.Clear();
                        return null;
                    }
                    else
                    {
                        Recipe recipe = null;
                        try
                        {
                            recipe = new Recipe(name, ingredients, directions);
                        }
                        catch (ApplicationException ae)
                        {
                            ChangeConsoleColor(ae.Message, ConsoleColor.Red);
                        }
                        Console.Clear();
                        return recipe;
                    }
                }
            }
        }

        //Lägger till instruktioner i form av strängar till en lista. Inmatningen avslutas när en tom rad kommer som input och listan returneras.
        //Anges inte några instruktioner frågas användaren om den vill avsluta och kan göra det genom att trycka ESC.
        public static List<string> ReadDirections()
        {
            List<string> directions = new List<string>();
            int iterator = 0;
            Console.WriteLine("Ange receptets instruktioner: ");
            while (true)
            {
                iterator++;
                bool success = false;
                string direction = null;
                while (success == false)
                {
                    Console.Write("Instruktion ({0}): ", iterator);
                    direction = Console.ReadLine();

                    if (String.IsNullOrEmpty(direction) || string.IsNullOrWhiteSpace(direction))
                    {
                        Console.WriteLine("Är du säker på att du vill avsluta? J/N?");
                        string input = Console.ReadLine();
                        if (input == "j" && directions.Count > 0)
                        {
                            return directions;
                        }
                        else if (input == "j" && directions.Count <= 0)
                        {
                            ConsoleKeyInfo cki;
                            Console.WriteLine("Du måste ange minst en instruktion");
                            Console.WriteLine("Tryck en tangent för att fortsätta skiva in instruktioner? ESC avbryter inläsningen av hela receptet");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Escape)
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        success = true;
                    }
                }

                directions.Add(direction);
            }

        }
        //Lägger till ingedienser till en lista. Inmatningen avslutas när en tom rad kommer som input och listan returneras. För varje ingrediens frågas det om namn, mått och mängd.
        //Varje ingrediens nåste minst ha ett namn. Anges inte några ingredienser frågas användaren om den vill avsluta och kan göra det genom att trycka ESC.
        public static List<Ingredient> ReadIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            int iterator = 0;
            Console.WriteLine("Ange receptets ingredienser: ");
            while (true)
            {
                iterator++;
                Ingredient ingredient = new Ingredient();
                bool success = false;
                Console.WriteLine("(" + iterator + ")");
                while (success == false)
                {
                    Console.Write("Ingrediens: ");
                    ingredient.Name = Console.ReadLine();

                    if (String.IsNullOrEmpty(ingredient.Name))
                    {
                        Console.WriteLine("Är du säker på att du vill avsluta? J/N?");
                        string input = Console.ReadLine();
                        if (input == "j" && ingredients.Count > 0)
                        {
                            return ingredients;
                        }
                        else if (input == "j" && ingredients.Count <= 0)
                        {
                            ConsoleKeyInfo cki;
                            Console.WriteLine("Du måste ange minst en ingrediens");
                            Console.WriteLine("Tryck en tangent för att fortsätta skiva in ingredienser? ESC avbryter inläsningen av hela receptet");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Escape)
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        success = true;
                    }
                }
                Console.Write("Mängd: ");
                ingredient.Amount = Console.ReadLine();

                Console.Write("Mått: ");
                ingredient.Measure = Console.ReadLine();

                ingredients.Add(ingredient);
            }

        }
        //Läser in ett receptnamn. Matas en tom rad in frågas användaren om den vill avsluta och kan gör det genom att trycka ESC.
        public static string ReadRecipeName()
        {
            bool success = false;
            string input = null;
            while (success == false)
            {
                ConsoleKeyInfo cki;
                Console.Write("Ange receptnamn. Tom rad avslutar: ");
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    ChangeConsoleColor("Du måste ange ett namn", ConsoleColor.Red);
                    ChangeConsoleColor("Tryck tangent för att fortsätta lägga till recept. ESC avbryter", ConsoleColor.Blue);
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        return null;
                    }
                }
                else
                {
                    success = true;
                }

            }
            return input;

        }
        //Tar emot en lista med recept och frågar användaren vilken fil den vill spara till. Om top rad matas in blir det recipes.txt som används. 
        //Om filen finns frågas användaren om den vill skriva över den befintliga filen. Sedan skapas ett RecipeRepository-objekt där metoden "Save" anropas och receptlistan skickas med.
        public static void SaveRecipes(List<Recipe> recipes)
        {
            bool success = false;
            string saveFileName = null;
            while (success == false)
            {
                Console.Write("Ange filnamnet på den fil du vill spara till. Tom rad sparar till 'recipes.txt': ");
                saveFileName = Console.ReadLine();

                if (string.IsNullOrEmpty(saveFileName) || string.IsNullOrWhiteSpace(saveFileName))
                {
                    saveFileName = "recipes.txt";
                }

                if (File.Exists("../../Resources/" + saveFileName))
                {
                    bool success2 = false;
                    while (success2 == false)
                    {
                        Console.Write("Vill du skriva över {0}? J/N: ", saveFileName);
                        string verification = Console.ReadLine();
                        if (verification == "n")
                        {
                            success = false;
                            success2 = true;
                        }
                        else if (verification == "j")
                        {
                            success = true;
                            success2 = true;
                        }
                    }
                }
                else
                {
                    success = true;
                }
            }
            RecipeRepository rr = new RecipeRepository("../../Resources/" + saveFileName);
            if (recipes != null && recipes.Count > 0)
            {
                try
                {
                    rr.Save(recipes);
                    ChangeConsoleColor("Receptet har sparats", ConsoleColor.DarkGreen);
                }
                catch (ApplicationException ae)
                {
                    ChangeConsoleColor(ae.Message, ConsoleColor.Red);
                }
            }
            else
            {
                ChangeConsoleColor("Det finns inga recept att spara", ConsoleColor.Red);
            }
            ContinueOnKeyPressed();

        }

        //Metoden tar emot en lista med recept och en valfri boolean(viewAll) som är satt till "false" från början. Ett RecipeView-objekt skapas. 
        //Om "viewAll" är false anropas "GetRecipe" som returnerar ett receptobjekt som sedan skickas till RecipeView.Render som tar hand om visningen av receptet. 
        //Om viewAll är true skickas hela listan till RecipeView.Render som visar alla recept.
        public static void ViewRecipe(List<Recipe> recipes, bool viewAll = false)
        {
            if (recipes != null && recipes.Count > 0)
            {
                RecipeView recipeView = new RecipeView();
                if (viewAll == false)
                {
                    while (true)
                    {
                        Recipe recipe = GetRecipe("Visa recept", recipes);
                        if (recipe == null)
                        {
                            return;
                        }
                        else
                        {
                            recipeView.Render(recipe);
                            ContinueOnKeyPressed();
                        }
                    }
                }
                if (viewAll == true)
                {
                    recipeView.Render(recipes);
                    ContinueOnKeyPressed();
                }
            }
            else
            {
                Console.WriteLine("Det finns inga recept att visa");
                ContinueOnKeyPressed();
            }
        }

        //Tar emot en receptlista. Användaren väljer vilket index som ska tas bort och får bekräfta med "j" eller "n" om det ska tas bort. Om användaren väljer "j" tags receptet bort och den nya listan returneras.
        public static List<Recipe> DeleteRecipe(List<Recipe> recipes)
        {
            if (recipes != null && recipes.Count > 0)
            {
                bool success = false;


                while (success == false)
                {
                    Recipe recipe = GetRecipe("Ta bort recept", recipes);
                    if (recipe == null)
                    {
                        return recipes;
                    }
                    else
                    {
                        bool success2 = false;
                        while (success2 == false)
                        {
                            Console.Write("Vill du ta bort {0}? J/N ", recipe.Name);
                            string input = Console.ReadLine();
                            if (input == "j")
                            {
                                success = true;
                                success2 = true;
                                recipes.Remove(recipe);
                                ChangeConsoleColor("Receptet har tagits bort", ConsoleColor.DarkGreen);
                                ContinueOnKeyPressed();
                                return recipes;
                            }
                            else if (input == "n")
                            {
                                success = false;
                                success2 = true;
                                Console.Clear();
                            }
                        }
                    }
                }
            }
            else
            {
                ChangeConsoleColor("Det finns inga recept att ta bort", ConsoleColor.Red);
                ContinueOnKeyPressed();
            }
            return recipes;

        }
        //Tar emot en sträng och en lista med recept. Strängen används som rubrik. Sedan listas listans innehåll upp med nummer intill sig. Användaren får sedan välja ett tal mellan 0 och listans längd. 
        //Är talet utanför intervallet presenteras ett felmeddelande och användaren får en ny chans. Om "0" matas in returneras "null" annars returneras det recept som finns på den plats som motsvarar användarens val.
        public static Recipe GetRecipe(string header, List<Recipe> recipes)
        {
            bool success = false;
            int input = 0;
            string inputString;
            while (!success)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(header);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("0. Tillbaka");
                for (int i = 0; i < recipes.Count(); i++)
                {
                    Console.WriteLine((i + 1) + ". " + recipes[i].Name);
                }
                Console.Write("Ange menyval [0-{0}]: ", recipes.Count);
                inputString = Console.ReadLine();
                try
                {
                    input = int.Parse(inputString);
                    if (input > 0 && input <= recipes.Count())
                    {
                        success = true;
                    }
                    else if (input == 0)
                    {
                        Console.Clear();
                        return null;
                    }
                    else
                    {
                        Console.Clear();
                        ChangeConsoleColor("Felaktigt val", ConsoleColor.Red);
                    }
                }
                catch
                {
                    Console.Clear();
                    ChangeConsoleColor("Felaktigt val", ConsoleColor.Red);
                }
            }
            Console.Clear();
            return recipes[input - 1];
        }

        //Frågar användaren efter vilken fil som ska laddas. Om tom rad anges laddas "recipes.txt". Ett nytt RecipeRepository-objekt skapas med filnamnet som parameter. 
        //RecipeRepository-objektets "Load"-metod används. Om inte filen finns meddelas användaren om det. Om filen finns laddas den med Load-metoden och sparas i en receptlista som returneras.
        public static List<Recipe> LoadRecipes()
        {
            Console.Write("Ange filnamnet på den fil du vill öppna. Tom rad öppnar 'recipes.txt': ");
            string fileName = Console.ReadLine();

            if (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName))
            {
                fileName = "recipes.txt";
            }
            List<Recipe> recipeList = new List<Recipe>();
            try
            {
                RecipeRepository rr = new RecipeRepository("../../Resources/" + fileName);
                recipeList = rr.Load();
                if (recipeList != null)
                {
                    ChangeConsoleColor("Laddningen lyckades", ConsoleColor.DarkGreen);
                }
            }
            catch (ApplicationException ae)
            {
                Console.WriteLine(ae.Message);
            }
            ContinueOnKeyPressed();
            return recipeList;
        }

        //Metoden uppmanar användaren att trycka på en tangent för att fortsätta. När den gör det rensas konsollfönstret.
        public static void ContinueOnKeyPressed()
        {
            ChangeConsoleColor("Tryck tangent för att fortsätta", ConsoleColor.Blue);
            Console.ReadKey();
            Console.Clear();
        }

        //Här har jag lagt till egna parametrar till metoden. Detta för att jag så ofta mehöver kunna skapa en meny som kontrollerar att användaren gör ett val som ligger innanför intervallet.
        //Patrametrarna är en strängarray, valfri menynamnsträng och en boolean för om det är huvudmenyn eller inte.
        //Metoden presenterar menyn och användaren får välja ett tal mellan 0 och strängarrayens längd. Görs inte det får den ett nytt försök. Om det är huvudmenyn som presenteras gör menyvalet 0 att programmet avslutas, annars returneras 0.
        //Om menyvalet är innanför intervallet returneras det menyvalet.
        public static int GetMenuChoice(string[] menuChoices, string menuName = "Meny", bool mainMenu = false)
        {
            bool success = false;
            int input = 0;

            while (success == false)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(menuName);
                Console.WriteLine("---------------------------------");
                for (int i = 0; i < menuChoices.Length; i++)
                {
                    Console.WriteLine(menuChoices[i]);
                }
                Console.WriteLine();
                Console.Write("Ange menyval [0-{0}]: ", menuChoices.Length - 1);
                string inputString = Console.ReadLine();
                try
                {
                    input = int.Parse(inputString);
                    if (input == 0)
                    {
                        if (mainMenu)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (input < 0 || input >= menuChoices.Length)
                    {
                        Console.Clear();
                        ChangeConsoleColor("Felaktigt val", ConsoleColor.Red);
                    }
                    else
                    {
                        success = true;
                    }
                }
                catch
                {
                    Console.Clear();
                    ChangeConsoleColor("Felaktigt val", ConsoleColor.Red);
                }
            }
            Console.Clear();
            return input;
        }
        static void Main(string[] args)
        {
            List<Recipe> recipeList = new List<Recipe>();
            int menuChoice;
            string[] menuChoices = new string[9] { "0. Avsluta", "1. Öppna textfil med recept", "2. Spara recept på textfil", "3. Ta bort recept", "4. Visa recept", "5. Visa alla recept", "6. Lägg till recept", "7. Hitta recept med ingredienser", "8. Redigera recept" };
            while (true)
            {
                menuChoice = GetMenuChoice(menuChoices, "Huvudmeny", true);

                if (menuChoice == 1)
                {
                    recipeList = LoadRecipes();
                }
                if (menuChoice == 2)
                {
                    SaveRecipes(recipeList);
                }
                if (menuChoice == 3)
                {
                    recipeList = DeleteRecipe(recipeList);
                }
                if (menuChoice == 4)
                {
                    ViewRecipe(recipeList);
                }
                if (menuChoice == 5)
                {
                    ViewRecipe(recipeList, true);
                }
                if (menuChoice == 6)
                {
                    Recipe recipe = CreateRecipe();
                    if (recipe != null)
                    {
                        recipeList.Add(recipe);
                        ChangeConsoleColor("Receptet har lagts till", ConsoleColor.DarkGreen);
                        ContinueOnKeyPressed();
                    }
                }
                if (menuChoice == 7)
                {
                    if (recipeList == null || recipeList.Count <= 0)
                    {
                        ChangeConsoleColor("Felaktigt val", ConsoleColor.Red);
                        ContinueOnKeyPressed();
                    }
                    else
                    {
                        List<Recipe> resultList = new List<Recipe>();
                        Console.Write("Vilken ingrediens vill du söka efter? Använd mellanslag för att söka på flera ingredienser. ");
                        string input = Console.ReadLine();
                        resultList = FindRecipes(recipeList, input);
                        if (resultList != null && resultList.Count > 0)
                        {
                            Console.WriteLine("Din sökning på {0} gav {1} träffar", input, resultList.Count());
                        }
                        ViewRecipe(resultList);
                    }
                }
                if (menuChoice == 8)
                {
                    if (recipeList == null || recipeList.Count <= 0)
                    {
                        Console.WriteLine("Det finns inga recept att redigera.");
                        ContinueOnKeyPressed();
                    }
                    else
                    {
                        bool goBack = false;
                        Recipe recipe = null;
                        while (goBack == false)
                        {
                            recipe = GetRecipe("Redigera recept", recipeList);
                            if (recipe == null)
                            {
                                goBack = true;
                            }
                            else
                            {
                                recipeList = EditRecipe(recipe, recipeList);
                            }
                        }
                    }
                }
            }

        }
    }
}
