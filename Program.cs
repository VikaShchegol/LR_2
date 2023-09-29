using System;

public class Triangle
{
    private double a, b, c;

    public double A
    {
        set
        {
            if (value > 0) a = value;
            else Console.WriteLine("1 сторона має бути додатньою.");
        }
        get { return a; }
    }

    public double B
    {
        set
        {
            if (value > 0) b = value;
            else Console.WriteLine("2 сторона має бути додатньою.");
        }
        get { return b; }
    }

    public double C
    {
        set
        {
            if (value > 0) c = value;
            else Console.WriteLine("3 сторона має бути додатньою.");
        }
        get { return c; }
    }

    public bool Correct()
    {
        return (a < b + c && b < a + c && c < a + b);
    }

    public double[] Corners()
    {
        double[] angles = new double[3];
        if (Correct())
        {
            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double cosB = (a * a + c * c - b * b) / (2 * a * c);
            double cosC = (a * a + b * b - c * c) / (2 * a * b);

            angles[0] = Math.Acos(cosA) * (180 / Math.PI);
            angles[1] = Math.Acos(cosB) * (180 / Math.PI);
            angles[2] = Math.Acos(cosC) * (180 / Math.PI);
        }
        else
        {
            Console.WriteLine("Такий трикутник не iснує");
        }
        return angles;
    }

    public double Perimeter()
    {
        return a + b + c;
    }

    public void Print()
    {
        Console.WriteLine("a={0} b={1} c={2}", a, b, c);
    }
}

class Program
{
    static void Main(string[] args)
    {
        double x, y, z;
        try
        {
            Console.Write("x="); x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y="); y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z="); z = Convert.ToDouble(Console.ReadLine());

            Triangle t = new Triangle();
            t.A = x; t.B = y; t.C = z;
            t.Print();

            if (t.Correct())
            {
                double[] angles = t.Corners();
                double perimeter = t.Perimeter();

                Console.WriteLine("Периметр: {0}", perimeter);
                Console.WriteLine("Кути: A={0}, B={1}, C={2}", angles[0], angles[1], angles[2]);
            }
            else
            {
                Console.WriteLine("Такий трикутник не iснує");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Помилка введення");
        }

        Console.ReadKey();
    }
}