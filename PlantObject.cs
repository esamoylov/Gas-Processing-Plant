namespace GasProcessingPlant
{
    // Базовый класс для объектов завода
    abstract class PlantObject
    {
        public string Name { get; set; }

        protected Parameter.LevelOfDanger state;
        public virtual Parameter.LevelOfDanger State
        {
            get { return state; }          
            protected set { state = value; }            
        }

        public PlantObject()
        {
            state = Parameter.LevelOfDanger.Normal;
        }

        // Обеспечивает изменение состояния объекта
        // Т - класс, в котором необходимо изменить состояние
        protected void ChangeState<T>(T t, Parameter.LevelOfDanger level) where T : PlantObject
        {
            /* Если условие выполняется, вызывается блок set свойства объекта t, в котором переменной
               state этого объекта присваивается значение level, а затем происходит вызов метода 
               ChangeState для изменения состояния объекта, находящегося выше в иерархии классов
            */
            if (t != null && t.State < level)
                t.State = level;
        }

        // Возвращает имя объекта
        public override string ToString()
        {
            return Name;
        }
    }
}