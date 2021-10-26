using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class FinishFactory:CarObjectFactory
    {
        public FinishFactory(GameSettings gameSettings ):base(gameSettings)
        {
            //к-тор принимает настройки и перенаправляет их с базового класса где они были реализованы
        }
        public override CarObject GetCarObject(GameObjectPlace objectPlace)
        {
            //переопределяем метод и устанавливаем первоначальное положени объектов
            CarObject finishObject = new FinishObject() { Figure = GameSettings.Finish, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.Finish };

            return finishObject;
        }

        public List<CarObject> GetFinish()
        {
            List<CarObject> finish = new List<CarObject>(); //cоздаем коллекцию финишной прямой
            int startX = GameSettings.FinishStartXCoordanite;//реализуем начало и конец финиша
            int startY = GameSettings.FinishStartYCoordanite;

            for(int y=0;y<GameSettings.NumberOfFinishRows;y++)
            {
                for(int x=0; x<GameSettings.NumberOfFinishColls;x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    CarObject finishObj = GetCarObject(objectPlace);//формируем коллекцию
                    finish.Add(finishObj);
                }
            }
            return finish;
        }

    }
}
