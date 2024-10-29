using System;


public class StringWithExclamation
{
    protected string value;


    public StringWithExclamation(string str)
    {
        value = str;
    }


    public StringWithExclamation(StringWithExclamation obj)
    {
        value = obj.value;
    }


    public void AddExclamations()
    {
        value = "!!! " + value;
    }


    public override string ToString()
    {
        return $"{value}";
    }
}


public class ImportantString : StringWithExclamation
{
    private int priority;


    public ImportantString(string str) : base(str)
    {
        priority = 0;
    }


    public ImportantString(ImportantString obj) : base(obj)
    {
        priority = obj.priority;
    }


    public void RemoveExclamations()
    {
        value = value.TrimStart('!', '!', '!', ' ');
    }


    public void PriorityIncrease()
    {
        priority++;
        AddExclamations();
    }

    public void PriorityDecrease()
    {
        if (priority == 0) return;
        priority--;
        RemoveExclamations();
    }


    public override string ToString()
    {
        return $"{value} (важность: {priority})";
    }
}


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("какая хотите строка:");
        string a = Console.ReadLine();
        var str1 = new StringWithExclamation(a);
        Console.WriteLine($"конструктор по умолчанию - {str1.ToString()}");

        var str2 = new StringWithExclamation(str1);
        Console.WriteLine($"конструктор копий - {str2.ToString()}");
        str2.AddExclamations();
        Console.WriteLine($"метод для добавления восклицательных знаков - {str2.ToString()}");


        Console.WriteLine("какая хотите строка:");
        a = Console.ReadLine();
        var extStr1 = new ImportantString(a);
        Console.WriteLine($"конструктор по умолчанию и метод уменьшения важности - {extStr1.ToString()}");
        
        extStr1.PriorityIncrease();
        extStr1.PriorityDecrease();
        Console.WriteLine(extStr1.ToString());

        var extStr2 = new ImportantString(extStr1);
        Console.WriteLine($"конструктор копий и метод увеличения важности - {extStr1.ToString()}");
        extStr2.PriorityIncrease();
        extStr2.PriorityIncrease();
        extStr2.PriorityIncrease();
        Console.WriteLine(extStr2.ToString());

        Console.WriteLine("какая хотите строка:");
        a = Console.ReadLine();
        var str3 = new ImportantString(a);
        Console.WriteLine("+/-/exit:");
        a = Console.ReadLine();
        while (a != "exit")
        {
            if (a == "+") str3.PriorityIncrease();
            if (a == "-") str3.PriorityDecrease();

            Console.WriteLine(str3.ToString());

            Console.WriteLine("+/-/exit:");
            a = Console.ReadLine();
        }
    }
}
