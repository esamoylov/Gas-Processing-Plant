using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    class SubUnit : PlantObject
    {
        public Unit Unit { get; set; }      // Узел, которому принадлежит подузел

        public override Parameter.LevelOfDanger State
        {
            get => base.State;
            protected set
            {
                state = value;
                ChangeState(Unit, value);
            }
        }

        public SubUnit(string name = "", Unit unit = null) : base()
        {
            Name = name;
            Unit = unit;

            Infrastructure.subUnits.Add(this);
        }

        // Добавление нового датчка к подузлу
        public void AddDetector(string name)
        {
            Detector d = new Detector(name, null, this);
        }

        // Добавление существующего датчика к подузлу и изменение состояний объектов
        public void AddDetector(Detector d)
        {
            d.SubUnit = this;

            if (d.State > state)
                State = d.State;
        }

        public Detector GetDetector(string name)
        {
            return Infrastructure.detectors.FirstOrDefault(d => d.Name == name);
        }

        // Список датчиков данного подузла
        public List<Detector> Detectors()
        {
            return Infrastructure.detectors.Where(d => d.SubUnit == this).ToList();
        }
    }
}