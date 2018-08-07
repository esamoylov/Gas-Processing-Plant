namespace GasProcessingPlant 
{
    // Параметр (измерение)
    class Parameter : PlantObject
    {        
        public enum LevelOfDanger
        {
            Normal,     // Нормально
            Alarm,      // Тревога
            Accident,   // Авария
            Fault       // Неисправность
        }

        public double Value { get; set; }           // Числовое значение измерения
        public Detector Detector { get; set; }      // Датчик, которому принадлежит измерение

        // Перекрывает свойство родительского класса, поскольку здесь блок set должен быть public
        public new LevelOfDanger State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                ChangeState(Detector, value);
            }
        }

        /// <param name="name">Низвание измерения</param>
        /// <param name="val">Числовое значение параметра</param>
        /// <param name="lvl">Уровень опасности</param>
        /// <param name="detector">Датчик, которому принадлежит измерение</param>
        public Parameter(string name = "", double val = 0, LevelOfDanger lvl = LevelOfDanger.Normal, Detector detector = null)
        {
            Name = name;
            Value = val;
            State = lvl;
            Detector = detector;

            // Добавление параметра в инфраструктуру модели
            Infrastructure.parameters.Add(this);
        }
    }
}