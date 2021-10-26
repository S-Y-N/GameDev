using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class BmwFactory:CarObjectFactory
    {
        public BmwFactory(GameSettings gameSettings) : base(gameSettings)
        {
            //создаем к-тор по умолчанию, и передаем в него базовые настройки с родительського класса
        }
        //этот метод возвращает один объект  - машинку BMW
        public override CarObject GetCarObject(GameObjectPlace objectPlace)
        {
            CarObject carObject = new BMW() { Figure = GameSettings.BMW, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.BMW };

            return carObject;
        }
        //перегрузка конструктора, так как при реализации класса Сцена он не должен получать параметры 
        public CarObject GetCarObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.StartPositionXCoordinateForBMW, YCoordinate = GameSettings.StartPositionYCoordinateForBMW };
            CarObject carObject = GetCarObject(place);

            return carObject;
        }
    }
}
