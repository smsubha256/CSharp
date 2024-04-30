// See https://aka.ms/new-console-template for more information
/*class Listfunctions
{
    private List<string> fruits = new List<string>();
    public List<string> Fruits
    {
        get => this.fruits; 
        set => this.fruits = value;
    }
}*/
using System.Globalization;

interface IFruitList
{
    List<string> AddFruits();
    List<string> RemoveFruits();    
}
class FruitList : IFruitList
{
    List<string> fruits = new List<string>();
    public List<string> AddFruits()
    {
        Console.WriteLine("Do you want to add fruits to the list? (y/n)");
        string a = Console.ReadLine();
        if (a == "y")
        {
            Console.WriteLine("enter a fruit to add:");
            string addfruit = Console.ReadLine();
            if (string.IsNullOrEmpty(addfruit))
            {
                Console.WriteLine("Enter a valid fruit name:");
                this.AddFruits();

            }
            fruits.Add(addfruit);
            //fruits.Add(addfruit);
            //fruits.Add(addfruit);
            this.AddFruits();
            
        }
        return fruits;
    }
    public List<string> RemoveFruits() {
        Console.WriteLine("Do you want to remove any fruit? (y/n)");
        string a = Console.ReadLine();
        if (a == "y")
        {
            Console.WriteLine("enter fruit to remove:");
            string removefruit = Console.ReadLine();
            if (!fruits.Contains(removefruit) || string.IsNullOrEmpty(removefruit))
            {
                Console.WriteLine("Enter a valid fruit name");
                this.RemoveFruits();
            }

            fruits.Remove(removefruit);
        }
        return fruits; 
    }
}
class Program
{
    static void Main(string[] args)
    {
      FruitList f = new FruitList();
        List<string> newfruitlist = f.AddFruits();
        foreach(string fruit in newfruitlist) { Console.WriteLine(fruit); }
        newfruitlist = f.RemoveFruits();
        foreach (string fruit in newfruitlist) { Console.WriteLine(fruit); }
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);
        numbers.Add(7);
        numbers.Add(8);
        numbers.Add(9);
        numbers.Add(10);
        int b = numbers.Where(n => n % 2 == 0).FirstOrDefault();
        Console.WriteLine("first or default value:"+b);
        int c = numbers.Where(n => n % 2 == 0).LastOrDefault();
        Console.WriteLine("Last or default:{0}", c);
        int last = numbers.Last();
        Console.WriteLine("last nunber:"+ last);
        var num = numbers.Select(n=>n*n);
        Console.WriteLine("Squares of the numbers:");
        foreach (var n in num)
        {
            Console.WriteLine(n);
        }
        List<List<string>> nestedlist = new List<List<string>> { new List<string> { "a", "b" } ,
        new List<string>{"c", "d" },
        new List<string>{"e", "f"} };
        var flatlist = nestedlist.SelectMany(list => list);
        Console.WriteLine("flat list:");
        foreach (var value in flatlist)
        {
            Console.WriteLine(value);
        }

    }
    
    
}
