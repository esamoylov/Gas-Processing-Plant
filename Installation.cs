using System.Collections.Generic;
using System.Linq;

namespace GasProcessingPlant
{
    // Установка
    class Installation : PlantObject
    {        
        public Installation(string name = "") : base()
        {
            Name = name;

            Infrastructure.installations.Add(this);
        }
        
        // Добавить новый агрегат
        public void AddAggregate(string name)
        {
            Aggregate a = new Aggregate(name, this);
        }

        // Добавить существующий агрегат
        public void AddAggregate(Aggregate a)
        {
            a.Installation = this;
            if (a.State > state)
                State = a.State;
        }

        public Aggregate GetAggregate(string name)
        {
            return Infrastructure.aggregates.FirstOrDefault(a => a.Name == name);
        }

        // Список агрегатов данной установки
        public List<Aggregate> Aggregates()
        {
            return Infrastructure.aggregates.Where(a => a.Installation == this).ToList();
        }
    }
}