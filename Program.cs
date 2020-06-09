using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab6
{
    //абстрактный класс "самолет", который задает интерфейс конкретным самолетам. (Задает интерфейс - это значит, какие должны быть там поля, методы, свойства и тд)
    abstract class Plane : IComparable<Plane>
    {
        protected int countPlace;
        protected int carryingCapacity;
        protected int rangeOfFlight;
        protected double gasolinePerKilometer;
        protected string model;
        public abstract int CountPlace { set; get; }
        public abstract int CarryingCapacity { set; get; }
        public abstract int RangeOfFlight { set; get; }
        public abstract double GasolinePerKilometer { set; get; }
        public abstract string Model { set; get; }
        public abstract void Fly();
        public abstract void Land();
        //реализация интерфейса для сортировки
        int IComparable<Plane>.CompareTo(Plane other)
        {
            int compare = this.RangeOfFlight.CompareTo(other.RangeOfFlight);
            return compare;
        }
    }
    //авиокомпания(там все понятно)
    class SobolAirline
    {
        private List<Plane> planes;
        private List<Plane> rightPlanesByGasoline = new List<Plane>();
        private int countPlace;
        private int carryingCapacity;
        private double minGasoline;
        private double maxGasoline;
        public SobolAirline(List<Plane> planes, double minGasoline, double maxGasoline)
        {
            this.planes = planes;
            this.minGasoline = minGasoline;
            this.maxGasoline = maxGasoline;
            CalculateCountOfPlaceAndCarryingCapacity();
            CreateCollectionsRightPlanesByGasoline();
        }
        private void CalculateCountOfPlaceAndCarryingCapacity()
        {
            for (int i = 0; i < planes.Count; i++)
            {
                countPlace += planes[i].CountPlace;
                carryingCapacity += planes[i].CarryingCapacity;
            }
        }
        private void CreateCollectionsRightPlanesByGasoline()
        {
            for (int i = 0; i < planes.Count; i++)
            {
                if(planes[i].GasolinePerKilometer >= minGasoline & planes[i].GasolinePerKilometer <= maxGasoline)
                {
                    rightPlanesByGasoline.Add(planes[i]);
                }
            }
        }
        public int GetCountPlace
        {
            get { return countPlace; }
        }
        public int GetCarryingCapacity
        {
            get { return carryingCapacity; }
        }
        public List<Plane> SortByRangeOfFlight()
        {
            planes.Sort();
            return planes;
        }
        public List<Plane> GetRightPlanesByGasoline
        {
            get { return rightPlanesByGasoline; }
        }
    }
    
    //конкретный класс для самолета модели боинг, в этом классе переопределяются абстрактные члены базового класса
    class Boing360 : Plane
    {
        public Boing360(int countPlace, int carryingCapacity, int rangeOfFlight, double gasolinePerKilometer, string model)
        {
            this.CountPlace = countPlace;
            this.CarryingCapacity = carryingCapacity;
            this.RangeOfFlight = rangeOfFlight;
            this.GasolinePerKilometer = gasolinePerKilometer;
            this.Model = model;
        }
        public override int CountPlace
        {
            set
            {
                if (value > 0)
                {
                    countPlace = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return countPlace; }
        }
        public override int CarryingCapacity
        {
            set
            {
                if (value > 0)
                {
                    carryingCapacity = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return carryingCapacity; }
        }
        public override int RangeOfFlight
        {
            set
            {
                if (value > 0)
                {
                    rangeOfFlight = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return rangeOfFlight; }
        }
        public override double GasolinePerKilometer
        {
            set
            {
                if (value > 0)
                {
                    gasolinePerKilometer = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return gasolinePerKilometer; }
        }
        public override string Model
        {
            set { model = value; }
            get { return model; }
        }
        public override void Fly()
        {
            Console.WriteLine("Летит самолет модели {0}", model);
        }
        public override void Land()
        {
            Console.WriteLine("Приземляется самолет модели {0}", model);
        }
    }
    //конкретный класс для самолета модели Л29, в этом классе переопределяются абстрактные члены базового класса
    class L29 : Plane
    {
        public L29(int countPlace, int carryingCapacity, int rangeOfFlight, double gasolinePerKilometer, string model)
        {
            this.CountPlace = countPlace;
            this.CarryingCapacity = carryingCapacity;
            this.RangeOfFlight = rangeOfFlight;
            this.GasolinePerKilometer = gasolinePerKilometer;
            this.Model = model;
        }
        public override int CountPlace
        {
            set
            {
                if (value > 0)
                {
                    countPlace = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return countPlace; }
        }
        public override int CarryingCapacity
        {
            set
            {
                if (value > 0)
                {
                    carryingCapacity = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return carryingCapacity; }
        }
        public override int RangeOfFlight
        {
            set
            {
                if (value > 0)
                {
                    rangeOfFlight = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return rangeOfFlight; }
        }
        public override double GasolinePerKilometer
        {
            set
            {
                if (value > 0)
                {
                    gasolinePerKilometer = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return gasolinePerKilometer; }
        }
        public override string Model
        {
            set { model = value; }
            get { return model; }
        }
        public override void Fly()
        {
            Console.WriteLine("Летит самолет модели {0}", model);
        }
        public override void Land()
        {
            Console.WriteLine("Приземляется самолет модели {0}", model);
        }
    }
    //конкретный класс для самолета модели МО981, в этом классе переопределяются абстрактные члены базового класса
    class MO981 : Plane
    {
        public MO981(int countPlace, int carryingCapacity, int rangeOfFlight, double gasolinePerKilometer, string model)
        {
            this.CountPlace = countPlace;
            this.CarryingCapacity = carryingCapacity;
            this.RangeOfFlight = rangeOfFlight;
            this.GasolinePerKilometer = gasolinePerKilometer;
            this.Model = model;
        }
        public override int CountPlace
        {
            set
            {
                if (value > 0)
                {
                    countPlace = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return countPlace; }
        }
        public override int CarryingCapacity
        {
            set
            {
                if (value > 0)
                {
                    carryingCapacity = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return carryingCapacity; }
        }
        public override int RangeOfFlight
        {
            set
            {
                if (value > 0)
                {
                    rangeOfFlight = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return rangeOfFlight; }
        }
        public override double GasolinePerKilometer
        {
            set
            {
                if (value > 0)
                {
                    gasolinePerKilometer = value;
                }
                else
                    throw new Exception("Исключение");
            }
            get { return gasolinePerKilometer; }
        }
        public override string Model
        {
            set { model = value; }
            get { return model; }
        }
        public override void Fly()
        {
            Console.WriteLine("Летит самолет модели {0}", model);
        }
        public override void Land()
        {
            Console.WriteLine("Приземляется самолет модели {0}", model);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Plane> planes = new List<Plane>();
            Boing360[] arrayBoing360 = new Boing360[6];
            for (int i = 0; i < arrayBoing360.Length; i++)
            {
                arrayBoing360[i] = new Boing360(360, 500, 20, 34.5, "Boing360");
                planes.Add((Plane)arrayBoing360[i]);
            }

            L29[] arrayL29 = new L29[6];
            for (int i = 0; i < arrayL29.Length; i++)
            {
                arrayL29[i] = new L29(300, 420, 25, 29.8, "L29");
                planes.Add((Plane)arrayL29[i]);
            }

            MO981[] arrayMO981 = new MO981[6];
            for (int i = 0; i < arrayMO981.Length; i++)
            {
                arrayMO981[i] = new MO981(400, 700, 30, 50.4, "MO981");
                planes.Add((Plane)arrayMO981[i]);
            }

            double minGasoline = 15.7;
            double maxGasoline = 35.2;
            SobolAirline sobolAirline = new SobolAirline(planes,minGasoline,maxGasoline);

            int countPlace = sobolAirline.GetCountPlace;
            Console.WriteLine("Количество мест - {0}", countPlace);

            int carryingCapacity = sobolAirline.GetCarryingCapacity;
            Console.WriteLine("Общая грузоподъемность - {0}", carryingCapacity);

            List<Plane> sortedPlanes = sobolAirline.SortByRangeOfFlight();
            Console.WriteLine("Сортировка по дальности полета:");
            foreach (Plane plane in sortedPlanes)
            {
                Console.WriteLine("Модель самолета - {0}, дальность полета - {1}", plane.Model, plane.RangeOfFlight);
            }

            List<Plane> rightPlanesByGasoline = sobolAirline.GetRightPlanesByGasoline;
            Console.WriteLine("Нужные самолеты по бензину за километр:");
            foreach (Plane plane in rightPlanesByGasoline)
            {
                Console.WriteLine("Модель самолета - {0}, беззин за километр - {1}", plane.Model, plane.GasolinePerKilometer);
            }
            Console.ReadKey();
        }
    }
}
