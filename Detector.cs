using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    // Датчик
    class Detector : PlantObject
    {
        public SubUnit SubUnit { get; set; }    // Подузел, которому принадлежит датчик
        public Unit Unit { get; set; }          // Узел, которому принадлежит датчик

        public override Parameter.LevelOfDanger State
        {
            get => base.State;
            protected set
            {
                state = value;
                ChangeState(SubUnit, value);
                ChangeState(Unit, value);
            }
        }

        public Detector(string name = "", Unit unit = null, SubUnit subUnit = null) : base()
        {
            Name = name;
            Unit = unit;
            SubUnit = subUnit;

            Infrastructure.detectors.Add(this);
        }

        // Добавление параметра к датчику и изменение состояний объектов, если выполняется условие
        public void AddParameter(string name, double value, Parameter.LevelOfDanger level)
        {
            Parameter p = new Parameter(name, value, level, this);
            if (level > state)
            {
                State = level;
            }
        }

        // Получение параметра по его имени
        public Parameter GetParameter(string name)
        {
            return Infrastructure.parameters.FirstOrDefault(s => s.Name == name);
        }

        // Список всех параметров этого датчика
        public List<Parameter> Parameters()
        {
            return Infrastructure.parameters.Where(p => p.Detector == this).ToList();
        }
    }
}