using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    abstract class CarObjectFactory // на основании фабрики будут создаваться объекты
    {
        public GameSettings GameSettings { get; set; }//подключим доступ к настройкам, создадим объект настроек

        public abstract CarObject GetCarObject(GameObjectPlace objectPlace); //метод который будет шаблоном для коллекций
        //коллекции(в данной игре это будут синглтоны, так как машинки будут в 1 экз)
        //они буду наследовать этот класс и получать настройки

        public CarObjectFactory(GameSettings gameSettings)//обычный конструктор для создания настроек объектов
        {
            GameSettings = gameSettings;
        }

       
    }
}
