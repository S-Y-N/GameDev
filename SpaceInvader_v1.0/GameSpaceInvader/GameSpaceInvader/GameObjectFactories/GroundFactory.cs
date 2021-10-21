using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class GroundFactory: GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings) //к-тор принимает настройки
            : base(gameSettings)//перенапрявляем настройки с базового класса где они реализиваны   
        {

        }


        public override GameObject GetGameObject(GameObjectPlace objectPlace) //переопределяем метод и образовуем первоначальное положение объектов
        {
            GameObject groundObject = new GroundObject() { Figure = GameSettings.Ground, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.GroundObject };

            return groundObject;

        }
        public List<GameObject> GetGround() //метод должен создавать два уровня врагов
        {
            List<GameObject> ground = new List<GameObject>(); //создаем коллекцию
            int startX = GameSettings.GroundStartXCoordinate;         //реализ начало, откуда начнутся реализ вргаи
            int startY = GameSettings.GroundStartYCoordinate; //реализ по координате У где будут располаг враги 

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject groundObj = GetGameObject(objectPlace);//формировка коллекции
                    ground.Add(groundObj);
                }
            }
            return ground;
        }
    }
}
