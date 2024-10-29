using System;
using System.Linq.Expressions;


public class Money
{
    private uint rubles;
    private byte kopeks;

    public Money(uint a, byte b)
    {
        rubles = (uint)(a + Convert.ToInt32(b) / 100);
        kopeks = (byte)(Convert.ToInt32(b) % 100);

    }

    public static Money operator +(Money m1, uint m2)
    {
        uint totalRubles = m1.rubles + m2 / 100;
        byte totalKopeks = (byte)(m1.kopeks + m2 % 100);

        return new Money(totalRubles, totalKopeks);
    }

    public static Money operator +(uint m2, Money m1)
    {
        uint totalRubles = m1.rubles + m2 / 100;
        byte totalKopeks = (byte)(m1.kopeks + m2 % 100);

        return new Money(totalRubles, totalKopeks);
    }

    public static Money operator -(uint m2, Money m1)
    {
        long totalRubles = m2 / 100 - Convert.ToInt32(m1.rubles) ;
        byte totalKopeks = (byte)(m2 % 100 - m1.kopeks);
        if (totalRubles < 0) return new Money(0, 0);

        return new Money((uint)totalRubles, totalKopeks);
    }

    public static Money operator -(Money m1, uint m2)
    {
        long totalRubles = Convert.ToInt32(m1.rubles) - m2 / 100;
        byte totalKopeks = (byte)(m1.kopeks - m2 % 100);
        if (totalRubles < 0)  return new Money(0,0); 

        return new Money((uint)totalRubles, totalKopeks);
    }


    public static explicit operator uint(Money money)
    {
        return money.rubles;
    }

    public static implicit operator double(Money money)
    {

            return (double)((double)money.kopeks/100);
    }

    public static Money operator ++(Money m)
    {
        if (m.kopeks == 99)
        {
            m.rubles++;
            m.kopeks = 0;
        }
        else
        {
            m.kopeks++;
        }
        return m;
    }

    public static Money operator --(Money m)
    {
        if (m.kopeks == 0)
        {
            m.rubles--;
            m.kopeks = 99;
        }
        else
        {
            m.kopeks--;
        }
        return m;
    }

    public override string ToString()
    {
        return $"{rubles}.{kopeks:D2} руб.";
    }

}


public class Program
{
    static void Main(string[] args)
    {
        try
        {
            int c, d;
            uint a;
            byte b;
            Console.WriteLine("введите два числа - рубли и копейки:");
            c = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine());
            if (c < 0 || d < 0)
            {
                Console.WriteLine("некорректный ввод");
                return;
            }
            a = (uint)c;
            b = (byte)d;

            Money money1 = new Money(a, b);

            Console.WriteLine($"итого - {((uint)money1).ToString()} рублей {((double)money1).ToString()} рублей");

            Console.WriteLine($"плюс копейка - {(money1++).ToString()}");
            Console.WriteLine($"обратно минус копейка - {(money1--).ToString()}");

            Console.WriteLine("введите копейки для добавления к текущей сумме:");

            int a2 = Convert.ToInt32(Console.ReadLine());

            if (a2 < 0)
            {
                Console.WriteLine("введите неотрицательное число");
                return;
            }

            uint a1 = (uint)a2;

            Console.WriteLine($"итого - {(money1 + a1).ToString()} = {(a1 + money1).ToString()}");
            Console.WriteLine("вычитание того же числа копеек от текущей суммы:");



            Console.WriteLine($"итого - {(money1 - a1).ToString()} или {(uint)(a1-money1)} (где-то здесь должен быть ноль, так как это проверка на отрицательные деньги так работает)");
        }
        catch (System.FormatException)
        {
            Console.WriteLine("некорректный ввод");
        }
        catch (System.OverflowException)
        {
            Console.WriteLine("слишком большое значение");
        }
    }
}
