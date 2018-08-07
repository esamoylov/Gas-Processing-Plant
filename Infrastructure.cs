using System.Collections.Generic;

namespace GasProcessingPlant
{
    // Класс инфраструктуры
    // Содержит списки всех объектов, созданных в модели
    static class Infrastructure
    {
        public static List<Installation> installations = new List<Installation>();
        public static List<Aggregate> aggregates = new List<Aggregate>();
        public static List<Unit> units = new List<Unit>();
        public static List<SubUnit> subUnits = new List<SubUnit>();
        public static List<Detector> detectors = new List<Detector>();
        public static List<Parameter> parameters = new List<Parameter>();
    }
}