using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    // Агрегат
    class Aggregate : PlantObject
    {
        public Installation Installation { get; set; }      // Установка, которой принадлежит агрегат

        public override Parameter.LevelOfDanger State
        {
            get => base.State;
            protected set
            {
                state = value;
                ChangeState(Installation, value);
            }
        }

        public Aggregate(string name = "", Installation installation = null) : base()
        {
            Name = name;
            Installation = installation;

            Infrastructure.aggregates.Add(this);
        }

        // Добавление нового узла
        public void AddUnit(string name)
        {
            Unit u = new Unit(name, this);
        }

        // Добавление существующего узла
        public void AddUnit(Unit u)
        {
            u.Aggregate = this;
            if (u.State > state)
                State = u.State;
        }

        public Unit GetUnit(string name)
        {
            return Infrastructure.units.FirstOrDefault(u => u.Name == name);
        }

        // Список узлов данного агрегата
        public List<Unit> Units()
        {
            return Infrastructure.units.Where(u => u.Aggregate == this).ToList();
        }
    }
}