using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class BelazFactory:CarObjectFactory
    {
        public BelazFactory(GameSettings gameSettings) : base(gameSettings)
        {
            //создаем к-тор по умолчанию, и передаем в него базовые настройки с родительського класса
        }
        //этот метод возвращает один объект  - машинку Belaz
        public override CarObject GetCarObject(GameObjectPlace objectPlace)
        {
            CarObject carObject = new Belaz() { Figure = GameSettings.Belaz, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.Belaz };

            return carObject;
        }
        //перегрузка конструктора, так как при реализации класса Сцена он не должен получать параметры 
        public CarObject GetCarObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.StartPositionXCoordinateForBelaz, YCoordinate = GameSettings.StartPositionYCoordinateForBelaz };
            CarObject carObject = GetCarObject(place);

            return carObject;
        }
    }
}
