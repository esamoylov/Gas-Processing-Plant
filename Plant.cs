using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    // Завод 
    static class Plant
    {
        // Свойство состояния завода
        public static Parameter.LevelOfDanger State
        {
            get { return Infrastructure.installations.Max(i => i.State); }
        }

        // Возвращает список всех объектов модели завода
        public static List<PlantObject> Objects()
        {            
                List<PlantObject> objects = new List<PlantObject>();

                objects.AddRange(Installations());
                objects.AddRange(Aggregates());
                objects.AddRange(Units());
                objects.AddRange(SubUnits());
                objects.AddRange(Detectors());
                objects.AddRange(Parameters());

                return objects;            
        }

        // Возвращает список всех установок завода
        public static List<Installation> Installations()
        {
            return Infrastructure.installations;            
        }

        // Возвращает список всех агрегатов завода
        public static List<Aggregate> Aggregates()
        {
            return Infrastructure.aggregates;            
        }

        // Возвращает список всех узлов завода
        public static List<Unit> Units()
        {
            return Infrastructure.units;
        }

        // Возвращает список всех подузлов завода
        public static List<SubUnit> SubUnits()
        {
            return Infrastructure.subUnits;
        }

        // Возвращает список всех датчиков завода
        public static List<Detector> Detectors()
        {
            return Infrastructure.detectors;
        }

        // Возвращает список всех измеряемых параметров завода
        public static List<Parameter> Parameters()
        {
            return Infrastructure.parameters;
        }
    }
}