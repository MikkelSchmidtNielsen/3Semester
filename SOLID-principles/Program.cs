namespace SOLID_principles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    /*------------------------------------------------------------------------ Opgave 1 ------------------------------------------------------------------------*/
    /*                                                                  Single Responsibility                                                                   */
    /*                                                                        Open Close                                                                        */
    /*                                                                   Dependency Inversion                                                                   */
    class Report
    {
        public string? Content { get; set; }

        public void GenerateReport()
        {
            Console.WriteLine("Generating Report...");
        }

        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, Content);
        }
    }

    /*                                                                         Solution                                                                         */
    interface IGenerator
    {
        string GenerateReport();
    }

    interface ISaver
    {
        void SaveToFile(string filename);
    }

    class ReportGenerator : IGenerator
    {
        public string GenerateReport()
        {
            Console.WriteLine("Generating Report...");
            return "Report";
        }
    }

    class ReportSaver : ISaver
    {
        IGenerator _generator;

        public ReportSaver(IGenerator generator)
        {
            _generator = generator;
        }

        public void SaveToFile(string filename)
        {
            var content = _generator.GenerateReport();
            File.WriteAllText(filename, content);
        }
    }


    /*------------------------------------------------------------------------ Opgave 2 ------------------------------------------------------------------------*/
    /*                                                                        Open Close                                                                        */
    class DiscountCalculator
    {
        public double GetDiscount(string customerType)
        {
            if (customerType == "Regular")
                return 10;
            else if (customerType == "Premium")
                return 20;
            else
                return 0;
        }
    }

    /*                                                                         Solution                                                                         */
    interface IDiscountCalculator
    {
        double GetDiscount();
    }

    class RegularDiscount : IDiscountCalculator
    {
        public double GetDiscount()
        {
            return 10;
        }
    }

    class PremiumDiscount : IDiscountCalculator
    {
        public double GetDiscount()
        {
            return 30;
        }
    }


    /*------------------------------------------------------------------------ Opgave 3 ------------------------------------------------------------------------*/
    /*                                                                          Liskov                                                                          */
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying...");
        }
    }

    class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }

    class Penguin : Bird
    {
        public override void Fly()
        {
            throw new NotImplementedException("Penguins cannot fly!");
        }
    }

    /*                                                                         Solution                                                                         */
    interface FlyableBird
    {
        void Fly();
    }

    class SparrowUpdated : FlyableBird
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }

    class PenguinUpdated
    {

    }

    /*------------------------------------------------------------------------ Opgave 4 ------------------------------------------------------------------------*/
    /*                                                                   Interface Segregation                                                                  */
    interface IMachine
    {
        void Print();
        void Scan();
        void Fax();
    }

    class BasicPrinter : IMachine
    {
        public void Print() => Console.WriteLine("Printing...");
        public void Scan() => throw new NotImplementedException();
        public void Fax() => throw new NotImplementedException();
    }

    /*                                                                         Solution                                                                         */
    interface IPrintablePrinter
    {
        void Print();
    }

    interface IScanablePrinter
    {
        void Scan();
    }

    interface IFaxablePrinter
    {
        void Fax();
    }

    class BasicPrinterUpdated : IPrintablePrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    /*------------------------------------------------------------------------ Opgave 5 ------------------------------------------------------------------------*/
    /*                                                                   Dependency Inversion                                                                   */
    class LightBulb
    {
        public void TurnOn() => Console.WriteLine("LightBulb On");
        public void TurnOff() => Console.WriteLine("LightBulb Off");
    }

    class Switch
    {
        private LightBulb bulb = new LightBulb();

        public void Operate(bool on)
        {
            if (on) bulb.TurnOn();
            else bulb.TurnOff();
        }
    }

    /*                                                                         Solution                                                                         */
    interface ILightBulb
    {
        void TurnOn();
        void TurnOff();
    }

    class LightBulbUpdated : ILightBulb
    {
        public void TurnOn()
        {
            Console.WriteLine("LightBulb On");
        }

        public void TurnOff()
        {
            Console.WriteLine("LightBulb Off");
        }
    }

    class SwitchUpdated
    {
        ILightBulb _lightBulb;

        public SwitchUpdated(ILightBulb lightBulb)
        {
            _lightBulb = lightBulb;
        }

        public void Operate(bool on)
        {
            if (on)
            {
                _lightBulb.TurnOn();
            }
            else
            {
                _lightBulb.TurnOff();
            }
        }
    }
}
