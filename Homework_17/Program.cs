
using System.Collections.Generic;

class Country
{
    public Country()
    {
        capital = "";
        currency = "";
        language = "";
        name = "";
    }

    public int population;
    public int area;
    public string capital;
    public string name;
    public string language;
    public string currency;

    public override string ToString()
    {
        return $"Name: {name}\nPopulation: {population}\nArea: {area}\nCapital: {capital}" +
            $"\nLanguage: {language}\nCurrency: {currency}";
    }
}

class Program
{
    static void Add(List<Country> list)
    {
        Country country = new Country();

        Console.Write("Enter population: ");
        while (true)
        {
            try
            {
                country.population = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect type!");
            }
        }


        Console.Write("Enter area: ");
        while (true)
        {
            try
            {
                country.area = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect type!");
            }
        }

        Console.Write("Enter capital: ");
        country.capital = Console.ReadLine();

        Console.Write("Enter country name: ");
        country.name = Console.ReadLine();

        Console.Write("Enter language: ");
        country.language = Console.ReadLine();

        Console.Write("Enter currency: ");
        country.currency = Console.ReadLine();

        list.Add(country);
        Console.Clear();
    }

    static void Show(List<Country> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }

    static void NonRepeatableCurrencies(List<Country> list)
    {
        Console.WriteLine("--------------Non-repeatable currencies-------------------");
        var temp = list.GroupBy(x => x.currency).Where(y => y.Count() == 1).Select(y => y.Key).Distinct();

        foreach (var item in temp)
        {
            Console.WriteLine("Value: " + item);
        }
    }

    static void EnglishCountry(List<Country> list)
    {
        List<Country> temp = list.Where(x => x.language == "english").ToList();

        Console.WriteLine("--------------Non-english countries-------------------");
        foreach (var item in temp)
        {
            Console.WriteLine(item.ToString());
        }
    }

    static void Main(string[] args)
    {
        List<Country> countries = new List<Country>();

        while (true)
        {
            string tmp;
            Console.WriteLine("1. Add country.");
            Console.WriteLine("2. Show all countries.");
            Console.WriteLine("3. Non-repeatable currencies");
            Console.WriteLine("4. Non-english countries");
            Console.WriteLine("5. First country");
            Console.WriteLine("6. Average");
            Console.WriteLine("7. Max population");
            Console.WriteLine("8. Sort by capital");
            Console.WriteLine("9. All exept rupee");
            Console.WriteLine("10. List of all country names");
            Console.WriteLine("x. Exit.");
            Console.Write("Enter: ");
            while (true)
            {
                try
                {
                    tmp = Console.ReadLine();
                    break;
                }
                catch (Exception) { Console.WriteLine("Try again."); }

            }
            switch (tmp)
            {
                case "1":
                    Add(countries);
                    break;
                case "2":
                    Show(countries);
                    break;
                case "3":
                    NonRepeatableCurrencies(countries);
                    break;
                case "4":
                    EnglishCountry(countries);
                    break;
                case "5":
                    Console.WriteLine(countries.First());
                    break;
                case "6":
                    Console.WriteLine(countries.Average(x => x.area));
                    break;
                case "7":
                    string s8 = (from c in countries
                                 where c.population == countries.Max(x => x.population)
                                 select c).First().ToString();
                    Console.WriteLine(s8);
                    break;
                case "8":
                    countries = countries.OrderBy(x => x.capital).ToList();
                    break;
                case "9":
                    List<Country> list9 = countries.Where(x => x.currency != "rupee").ToList();
                    foreach (var item in list9)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "10":
                    var tmp10 = countries.Select(x => x.name).Distinct();
                    foreach (var item in tmp10)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Wrong type. Please try again");
                    break;
            }
        }
    }
}