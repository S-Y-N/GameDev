using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class SprinterFactory:CarObjectFactory
    {
        public SprinterFactory(GameSettings gameSettings) : base(gameSettings)
        {
            //создаем к-тор по умолчанию, и передаем в него базовые настройки с родительського класса
        }
        //этот метод возвращает один объект  - машинку Sprinter
        public override CarObject GetCarObject(GameObjectPlace objectPlace)
        {
            CarObject carObject = new Sprinter() { Figure = GameSettings.Sprinter, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.Sprinter };

            return carObject;
        }
        //перегрузка конструктора, так как при реализации класса Сцена он не должен получать параметры 
        public CarObject GetCarObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.StartPositionXCoordinateForSprinter, YCoordinate = GameSettings.StartPositionYCoordinateForSprinter };
            CarObject carObject = GetCarObject(place);

            return carObject;
        }
    }
}
