using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    //этот класс вовращает наши корабли пришельцов
    class AlienShipFactory:GameObjectFactory //основ объект который будет формировать коллекцию враж кораблей
    {
        public AlienShipFactory(GameSettings gameSettings) //к-тор принимает настройки
            : base(gameSettings)//перенапрявляем настройки с базового класса где они реализиваны   
        {

        }


        public override GameObject GetGameObject(GameObjectPlace objectPlace) //переопределяем метод и образовуем первоначальное положение объектов
        {
            GameObject alienShip = new AllienShip() { Figure = GameSettings.AlienShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.AllienShip };

            return alienShip;
            
        }
        public List<GameObject> GetSwarm() //метод должен создавать два уровня врагов
        {
            List<GameObject> swarm = new List<GameObject>(); //создаем коллекцию
            int startX = GameSettings.SwarmStartXCoordinate;         //реализ начало, откуда начнутся реализ вргаи
            int startY = GameSettings.SwarmStartYCoordinate; //реализ по координате У где будут располаг враги 

            for (int y =0; y<GameSettings.NumberOfSwarmRows; y++)      
            {
                for (int x = 0; x < GameSettings.NumberOfSwarmColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject alienShip = GetGameObject(objectPlace);//формировка коллекции
                    swarm.Add(alienShip);                
                }
            }
            return swarm;
        }
    }
}
