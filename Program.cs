using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using RecipeCatalogApplicationConsole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCatalogApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
            //ТОДО естетика, редове
            //Проверка на всички функции, с правилни и грешни променливи
        }

        private static void MainMenu()
        {
            Console.WriteLine("Каталог за рецепти");
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("-->Създай рецепта");
            Console.WriteLine("-->Намери рецепта");
            Console.WriteLine("-->Изход");

            while (true)
            {
                var n = Console.ReadLine().ToLower();

                if (n == "създай рецепта")
                {
                    Console.Clear();
                    CreateRecipe();
                    break;
                }
                else if (n == "намери рецепта")
                {
                    Console.Clear();
                    FindRecipe();
                    break;
                }
                else if (n == "изход")
                {
                    Environment.Exit(0);
                }
                else{Console.WriteLine("Невалидна команда!");}
            }            
        }
        private static void FindRecipe(string name)
        {
            Console.WriteLine("---Намиране на рецепта---");
            Console.Write("Ето списък на всички записани рецепти:");
            Console.WriteLine();
            PrintAllRecipes();

            Console.WriteLine("Напишете името на рецептата, която " +
                "искате да разгледате или напишете " +
                "команда 'назад', за да се върнете:");

            while (true)
            {
                var InputName = name;

                    Console.WriteLine();
                    PrintRecipe(InputName); 
                    Console.WriteLine();
                    Console.WriteLine("За да промените дадената рецепта използвайте команда:");
                    Console.WriteLine("-->Промени");
                    Console.WriteLine("За да изтриете дадената рецепта използвайте команда:");
                    Console.WriteLine("-->Изтрий");
                    Console.WriteLine("За да се върнете назад използвайте команда:");
                    Console.WriteLine("-->Назад");
                    Console.WriteLine("За да намерите нова рецепта използвайте команда:");
                    Console.WriteLine("-->Нова рецепта");

                    Console.WriteLine();

                    while (true)
                    {
                        var Input1 = Console.ReadLine();
                        if (Input1 == "изтрий")
                        {
                            DeleteRecipe(InputName);
                            Console.WriteLine("За да се върнете към главното меню използвайте команда:");
                            Console.WriteLine("-->Назад");
                            while (true)
                            {
                                var Input2 = Console.ReadLine().ToLower();
                                if (Input2 == "назад")
                                {
                                    Console.Clear();
                                    MainMenu();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Невалидна команда!");
                                }
                            }
                        break;
                        }
                        else if (Input1.ToLower() == "промени")
                        {
                            Console.WriteLine();
                            UpdateRecipe(InputName);
                            break;
                        }
                        else if (Input1.ToLower() == "назад")
                        {
                            Console.Clear();
                            MainMenu();
                            break;
                        }
                        else if (Input1.ToLower() == "нова рецепта")
                        {
                            Console.Clear();
                            FindRecipe();
                            break;
                        }
                        else { Console.WriteLine("Невалидна команда!"); }
                    break;
                    }    
            }
        }

        private static void FindRecipe()
        {
            Console.WriteLine("---Намиране на рецепта---");
            Console.Write("Ето списък на всички записани рецепти:");
            Console.WriteLine();
            PrintAllRecipes();

            Console.WriteLine("Напишете името на рецептата, която " +
                "искате да разгледате или напишете " +
                "команда 'назад', за да се върнете:");

            while (true)
            {
                var InputName = Console.ReadLine();
                if (RecipeExist(InputName)&& InputName.ToLower() !="назад")
                {
                    Console.WriteLine();
                    //if (InputName.ToLower() == "назад")
                    //{
                    //    Console.Clear();
                    //    MainMenu();
                    //}
                    /*else { */PrintRecipe(InputName); /*}*/

                    Console.WriteLine();
                    Console.WriteLine("За да промените дадената рецепта използвайте команда:");
                    Console.WriteLine("-->Промени");
                    Console.WriteLine("За да изтриете дадената рецепта използвайте команда:");
                    Console.WriteLine("-->Изтрий");
                    Console.WriteLine("За да се върнете назад използвайте команда:");
                    Console.WriteLine("-->Назад");
                    Console.WriteLine("За да намерите нова рецепта използвайте команда:");
                    Console.WriteLine("-->Нова рецепта");

                    Console.WriteLine();

                    while (true)
                    {
                        var Input1 = Console.ReadLine();
                        if (Input1.ToLower() == "изтрий")
                        {
                            DeleteRecipe(InputName);
                            Console.WriteLine("За да се върнете към главното меню използвайте команда:");
                            Console.WriteLine("-->Назад");
                            while (true)
                            {
                                var Input2 = Console.ReadLine().ToLower();
                                if (Input2 == "назад")
                                {
                                    Console.Clear();
                                    MainMenu();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Невалидна команда!");
                                }
                                break;
                            }

                        }
                        else if (Input1.ToLower() == "промени")
                        {
                            Console.WriteLine();
                            UpdateRecipe(InputName);
                            break;
                        }
                        else if (Input1.ToLower() == "назад")
                        {
                            Console.Clear();
                            MainMenu();
                            break;
                        }
                        else if (Input1.ToLower() == "нова рецепта")
                        {
                            Console.Clear();
                            FindRecipe();
                            break;
                        }
                        else { Console.WriteLine("Невалидна команда!"); }
                    }
                    break;
                }
                else if (InputName.ToLower() == "назад")
                {
                    Console.Clear();
                    MainMenu();
                    break;
                }
                else
                { Console.WriteLine("Рецептата не съществува! Моля, въведете съществуваща рецепта!"); }
            }
        }

        private static void CreateRecipe()
        {
            Console.WriteLine("---Създай рецепта---");
            Console.WriteLine("За да се върнете назад използвайте команда:");
            Console.WriteLine("-->Назад");
            Console.WriteLine("Или...");

            Console.WriteLine();

            Console.Write("Въведете име на рецептата:");

            while (true)
            {
                var InputRecipeName = Console.ReadLine(); Console.WriteLine();

                if (InputRecipeName.ToLower() == "назад")
                {
                    Console.Clear();
                    MainMenu();
                    break;
                }

                if (RecipeExist(InputRecipeName))
                { Console.WriteLine("Рецепта с такова име съществува, моля въведете друго:"); }
                else
                {
                    var InputTime = 0;
                    Console.Write("Колко минути са нужни за приготвянето:");
                    while (true)
                    {
                        try { InputTime = int.Parse(Console.ReadLine()); break; }
                        catch { Console.WriteLine("Въведената стойност трябва да е цяло число!"); }
                    }
                    Console.WriteLine();

                    Console.Write("За колко порции е дадената рецепта:");
                    var InputPortion = 0;
                    while (true)
                    {
                        try { InputPortion = int.Parse(Console.ReadLine()); break; }
                        catch { Console.WriteLine("Въведената стойност трябва да е цяло число!"); }
                    }
                    Console.WriteLine();

                    Console.WriteLine("Въведете продуктите:");
                    Console.WriteLine("За да прекратите въвеждането на продуктите, използвайте команда:");
                    Console.WriteLine("-->Изход");

                    int timer = 0;

                    List<string> InputProductsNameList = new List<string>();
                    List<double> InputProductsAmountList = new List<double>();
                    List<string> InputProductsAmountTypeList = new List<string>();

                    string InputProduct;
                    double InputAmount;
                    string InputAmountType;

                    while (true)
                    {
                        Console.Write("Продукт {0}:", timer + 1);

                        InputProduct = Console.ReadLine();
                        if (InputProduct.ToLower() == "изход")
                        { break; }
                        else
                        {
                            timer++;
                            InputProductsNameList.Add(InputProduct);

                            Console.Write("Количество:");
                            while (true)
                            {
                                try { InputAmount = double.Parse(Console.ReadLine()); break; }
                                catch { Console.WriteLine("Въведената стойност трябва да е число!"); }
                            }
                            InputProductsAmountList.Add(InputAmount);

                            Console.Write("Мерна единица:");
                            InputAmountType = Console.ReadLine();
                            InputProductsAmountTypeList.Add(InputAmountType);

                            Console.WriteLine();
                        }

                    }

                    Console.Write("Опишете на кратко начинът на приготвяне:");
                    var InputInstruction = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("За да запазите промените използвайте команда:");
                    Console.WriteLine("-->Запази");
                    Console.WriteLine("За да се върнете, без да запазите промените използвайте команда:");
                    Console.WriteLine("-->Назад");
                  
                    while (true)
                    { 
                    var InputSave = Console.ReadLine().ToLower();
                    if (InputSave == "запази")
                    {
                        SaveRecipe(InputRecipeName, InputInstruction, InputTime, InputPortion, timer, InputProductsNameList,
                            InputProductsAmountList, InputProductsAmountTypeList);

                        Console.WriteLine("Искате ли да се съдадете нова рецепта или да се върнете към менюто?");
                        Console.WriteLine("-->Нова рецепта");
                        Console.WriteLine("-->Меню");

                            while (true)
                            {
                                var NewInput = Console.ReadLine();
                                if (NewInput.ToLower() == "нова рецепта")
                                {
                                    Console.Clear();
                                    CreateRecipe();
                                    break;
                                }
                                if (NewInput.ToLower() == "меню")
                                {
                                    Console.Clear();
                                    MainMenu();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Невалидна команда!");
                                }
                            }                       
                        break;
                    }
                    else if (InputSave == "назад")
                    {
                        Console.Clear();
                        MainMenu();
                        break;
                    }
                    else
                    { 
                            Console.WriteLine("Невалидна команда!"); }
                    }                    
                }
                break;
            }

        }

        private static void SaveRecipe(string title, 
                                       string instruction, 
                                       int time, 
                                       int portion, 
                                       int timer,
                                       List<string> listName,
                                       List<double> listAmount,
                                       List<string> listAmountType)
        {
            using (var context = new RecipeCatalogContext())
            {
                var r = new Recipe();
                r.RecipeTitle = title;
                r.RecipeTime = time;
                r.RecipePortions = portion;
                r.RecipeInstruction = instruction;

                for (int i=0; i<timer; i++)
                {
                    var p = new Product();

                    p.ProductTitle = listName[i];
                    p.ProductAmount = listAmount[i];
                    p.ProductAmontType = listAmountType[i];

                    r.Product.Add(p);
                }

                context.Recipe.Add(r);
                context.SaveChanges();

                Console.WriteLine();
                Console.WriteLine("Промените бяха запазени!");
            }
        }

        private static void PrintRecipe(string name)
        {
            using (var context = new RecipeCatalogContext())
            {
                var Recipes = context.Recipe
                    .Where(x=> x.RecipeTitle==name)
                    .OrderBy(f=> f.RecipeId);
                
                foreach (var x in Recipes)
                {
                    int index = x.RecipeId;
                    var Products = context.Product
                        .Where(f => f.FkrecipeId == index);
                    Console.WriteLine("**{0}**", x.RecipeTitle);
                    Console.WriteLine("Порции: {0}", x.RecipePortions);
                    Console.WriteLine("Нужно време: {0} минути", x.RecipeTime);
                    Console.WriteLine();

                    Console.WriteLine("**Нужни продукти**");
                    foreach (var p in Products)
                    {
                        Console.Write("{0}", p.ProductTitle);
                        Console.Write(" {0}", p.ProductAmount);
                        Console.Write(" {0}", p.ProductAmontType);
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine("**Начин на приготвяне**");
                    Console.WriteLine("{0}", x.RecipeInstruction);
                }

            }
        }

        private static void PrintAllRecipes()
        {
            using (var context = new RecipeCatalogContext())
            {
                var Recipes = context.Recipe.OrderBy(x=> x.RecipeId);

                foreach (var x in Recipes)
                {
                    Console.WriteLine("-->{0}", x.RecipeTitle);
                }
            }
        }

        private static void DeleteRecipe(string name)
        {
            var context = new RecipeCatalogContext();
            var  recipes = context.Recipe.Where(x=> x.RecipeTitle==name);

            foreach (var x in recipes)
            {
                int index = x.RecipeId;
                var products = context.Product.Where(x => x.FkrecipeId == index);
                foreach (var p in products)
                {
                    context.Product.Remove(p);
                }
                context.Recipe.Remove(x);
            }  
            
            context.SaveChanges();
            Console.WriteLine("Успешно изтрихте рецепта: {0}", name);
        }

        private static void UpdateRecipe(string name)
        {
            while (true)
            {
                Console.WriteLine("Какво искате да промените:");
                Console.WriteLine("-->Порции");
                Console.WriteLine("-->Време");
                Console.WriteLine("-->Иструкции");
                Console.WriteLine("-->Продукти");
                Console.WriteLine("-->Нищо");

                while (true)
                {
                    var Input1 = Console.ReadLine().ToLower();
                    if (Input1 == "порции")
                    {
                        Console.Write("Въведете нова стойност:");
                        var NewPortion=0;
                        while (true)
                        {
                            try { NewPortion = int.Parse(Console.ReadLine()); break; }
                            catch { Console.WriteLine("Въведената стойност трябва да е цяло число!"); }
                        }                       
                        var context = new RecipeCatalogContext();
                        var recipes = context.Recipe.Where(x => x.RecipeTitle == name);

                        foreach (var r in recipes)
                        {
                            r.RecipePortions = NewPortion;                            
                        }
                        context.SaveChanges();
                        Console.WriteLine("Успешно променихте стойността!");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        FindRecipe(name);
                        break;
                    }
                    else if (Input1 == "време")
                    {
                        Console.Write("Въведете нова стойност:");
                        var NewTime =0;
                        while (true)
                        {
                            try { NewTime = int.Parse(Console.ReadLine()); break; }
                            catch { Console.WriteLine("Въведената стойност трябва да е цяло число!"); }
                        }
                        var context = new RecipeCatalogContext();
                        var recipes = context.Recipe.Where(x => x.RecipeTitle == name);

                        foreach (var r in recipes)
                        {
                            r.RecipeTime = NewTime;
                        }
                        context.SaveChanges();
                        Console.WriteLine("Успешно променихте стойността!");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        FindRecipe(name);
                        break;
                    }
                    else if (Input1 == "инструкции")
                    {
                        Console.Write("Въведете нова стойност:");
                        var NewInstruction = Console.ReadLine();
                        var context = new RecipeCatalogContext();
                        var recipes = context.Recipe.Where(x => x.RecipeTitle == name);

                        foreach (var r in recipes)
                        {
                            r.RecipeInstruction = NewInstruction;
                        }
                        context.SaveChanges();
                        Console.WriteLine("Успешно променихте стойността!");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        FindRecipe(name);
                        break;
                    }
                    else if (Input1 == "продукти")
                    {
                        Console.WriteLine();
                        UpdateProducts(name);
                    }
                    else if (Input1 == "нищо")
                    {
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        FindRecipe(name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невалидна команда!");
                    }
                }
                break;
            }
            
        }

        private static void UpdateProducts(string name)
        { 
            Console.Write("Името на продукта, който искате да промените:");
            var OldProduct = Console.ReadLine();

            Console.Write("Ново име:");
            var NewProductName = Console.ReadLine();

            Console.Write("Ново количество:");
            double NewProductAmount = 0;
            while (true)
            {
                try { NewProductAmount = double.Parse(Console.ReadLine()); break; }
                catch { Console.WriteLine("Въведената стойност трябва да е  число!"); }
            }        

            Console.Write("Нова мерна единица:");
            var NewProductAmountType = Console.ReadLine();

            var context = new RecipeCatalogContext();
            var recipes = context.Recipe.Where(x=> x.RecipeTitle ==name);

            foreach (var x in recipes)
            {
                var products = context.Product.Where(p => p.FkrecipeId == x.RecipeId)
                                              .Where(y=> y.ProductTitle == OldProduct) ;
                foreach (var y in products)
                {
                    y.ProductTitle = NewProductName;
                    y.ProductAmount = NewProductAmount;
                    y.ProductAmontType = NewProductAmountType;
                }
                context.SaveChanges();
            }
            Console.WriteLine();
            Console.WriteLine("Продукта бе запаметен!");
            System.Threading.Thread.Sleep(5000);
            FindRecipe(name);
        }

        private static bool RecipeExist(string name)
        {
            var context = new RecipeCatalogContext();
            var recipes = context.Recipe;
            bool n=false;

            foreach (var x in recipes)
            {
                if (x.RecipeTitle == name)
                { n = true; }
            }
            return n;
        }
    }
}
