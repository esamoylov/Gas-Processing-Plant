using System;

namespace GasProcessingPlant
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание установок
            Installation i1 = new Installation("Установка 1");
            Installation i2 = new Installation("Установка 2");


            // Варианты создания агрегатов и привязки их к установкам
            Aggregate a1 = new Aggregate("Агрегат первой установки", i1);
            i2.AddAggregate("Агрегат второй установки");
            Aggregate anotherAggr = new Aggregate("Агрегат");


            // Создание связи между установкой и агрегатом
            anotherAggr.Installation = i1;
            anotherAggr.Name = "Еще один агрегат первой установки";

            // Получение и вывод в консоль списка агрегатов первой установки
            var i1Aggregates = i1.Aggregates();
            Console.WriteLine("Агрегаты установки 1: ");
            foreach (var a in i1Aggregates)
                Console.WriteLine(a);
            Console.WriteLine();

            
            // Получение состояния установки 1
            Console.WriteLine("Состояние установки 1: {0}", i1.State);
            Console.WriteLine();

            
            // Создание нового узла и связывание его с агрегатом второй установки
            Unit u1 = new Unit("Редуктор");
            Aggregate a2 = i2.GetAggregate("Агрегат второй установки");
            a2.AddUnit(u1);


            // Добавление узла и его подузла в агрегат второй установки
            a2.AddUnit("Двигатель");
            Unit u2 = a2.GetUnit("Двигатель");
            u2.AddSubUnit("Вал");

            
            // Добавление датчиков в узел и подузел
            Detector pressureDet = new Detector("Датчик давления", unit: u2);
            Detector speedDet = new Detector("Датчик скорости", subUnit: u2.GetSubUnit("Вал"));

            
            // Установка параметров для датчиков
            pressureDet.AddParameter("Давление", 0.2, Parameter.LevelOfDanger.Normal);
            speedDet.AddParameter("Скорость", 2500, Parameter.LevelOfDanger.Alarm);


            // Вывод на консоль агрегатов модели завода
            var aggregates = Plant.Aggregates();
            Console.WriteLine("Список всех агрегатов завода: ");
            foreach(var a in aggregates)
                Console.WriteLine(a);
            Console.WriteLine();
            

            // Вывод состояний узлов
            Console.WriteLine("Состояние объекта \"{0}\": {1}", u1.Name, u1.State);
            Console.WriteLine("Состояние объекта \"{0}\": {1}", u2.Name, u2.State);
            Console.WriteLine();


            // Вывод списка всех объектов модели
            Console.WriteLine("Список Объектов модели");
            foreach (var o in Plant.Objects())
                Console.WriteLine(o);
            Console.WriteLine();


            // Состояние завода
            Console.WriteLine("Общее состояние завода: {0}", Plant.State);


            Console.Read();
        }
    }
}