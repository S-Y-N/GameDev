using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class BugattiFactory: CarObjectFactory
    {
        public BugattiFactory(GameSettings gameSettings):base(gameSettings)
        {
            //создаем к-тор по умолчанию, и передаем в него базовые настройки с родительського класса
        }
        //этот метод возвращает один объект  - машинку Бугатти
        public override CarObject GetCarObject(GameObjectPlace objectPlace)
        {
            CarObject carObject = new Bugatti() { Figure = GameSettings.Bugatti, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.Buggati };

            return carObject;
        }
        //перегрузка конструктора, так как при реализации класса Сцена он не должен получать параметры 
        public CarObject GetCarObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.StartPositionXCoordinateForBugatti, YCoordinate = GameSettings.StartPositionYCoordinateForBugatti };
            CarObject carObject = GetCarObject(place);

            return carObject;
        }
    }
}
