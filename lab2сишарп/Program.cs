using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Figures
{

    /// <summary>
    /// Класс фигура
    /// </summary>
    abstract class Figure
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; protected set; }
        /// <summary>
        /// Вычисление площади
        /// </summary>
        public abstract double Area();
        /// <summary>
        /// Приведение к строке, переопределение метода Object
        /// </summary>
        public override string ToString()
        {
            return this.Type + " площадью " +
           this.Area().ToString();
        }
    }



    interface IPrint
    {
        void Print();
    }


    class Rectangle : Figure, IPrint
    {
        /// <summary>
        /// Высота
        /// </summary>
        double height;
        /// <summary>
        /// Ширина
        /// </summary>
        double width;
        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="ph">Высота<д/param>
        /// <param name="pw">Ширина</param>
        public Rectangle(double ph, double pw)
        {
            this.height = ph;
            this.width = pw;
            this.Type = "Прямоугольник";
        }
        /// <summary>
        /// Вычисление площади

        /// </summary>
        public override double Area()
        {
            double Result = this.width * this.height;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }



    class Square : Rectangle, IPrint
    {
        public Square(double size)
        : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }



    class Circle : Figure, IPrint
    {
        /// <summary>
        /// Ширина
        /// </summary>
        double radius;
        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="ph">Высота</param>
        /// <param name="pw">Ширина</param>
        public Circle(double pr)
        {
            this.radius = pr;
            this.Type = "Круг";
        }
        public override double Area()
        {
            double Result = Math.PI * this.radius * this.radius;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            Rectangle rect = new Rectangle(5, 4);
            Square square = new Square(5);
            Circle circle = new Circle(5);
            rect.Print();
            Console.WriteLine(rect.ToString());
            square.Print();
            Console.WriteLine(square.ToString());
            circle.Print();
            Console.WriteLine(circle.ToString());
            Console.ReadLine();
            
        }
    }

}

