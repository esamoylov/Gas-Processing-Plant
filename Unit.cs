using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    // Узел
    class Unit : PlantObject
    {
        public Aggregate Aggregate { get; set; }        // Агрегат, которому принадлежит узел

        public override Parameter.LevelOfDanger State
        {
            get => base.State;
            protected set
            {
                state = value;
                ChangeState(Aggregate, value);
            }
        }


        public Unit(string name = "", Aggregate aggregate = null) : base()
        {
            Name = name;
            Aggregate = aggregate;

            Infrastructure.units.Add(this);
        }

        // Добавление нового подузла
        public void AddSubUnit(string name)
        {
            SubUnit s = new SubUnit(name, this);
        }

        // Добавление существующего подузла
        public void AddSubUnit(SubUnit s)
        {
            s.Unit = this;

            if(s.State > state)
                State = s.State;
        }

        public SubUnit GetSubUnit(string name)
        {
            return Infrastructure.subUnits.FirstOrDefault(s => s.Name == name);
        }

        // Список подузлов данного узла
        public List<SubUnit> SubUnits()
        {
            return Infrastructure.subUnits.Where(s => s.Unit == this).ToList();
        }

        // Добавление нового датчика
        public void AddDetector(string name)
        {
            Detector d = new Detector(name, this);
        }

        // Добавление существующего датчика
        public void AddDetector(Detector d)
        {
            d.Unit = this;
            if (d.State > state)
                State = d.State;
        }

        public Detector GetDetector(string name)
        {
            return Infrastructure.detectors.FirstOrDefault(d => d.Name == name);
        }

        // Список датчиков данного узла
        public List<Detector> Detectors()
        {
            return Infrastructure.detectors.Where(s => s.Unit == this).ToList();
        }
    }
}