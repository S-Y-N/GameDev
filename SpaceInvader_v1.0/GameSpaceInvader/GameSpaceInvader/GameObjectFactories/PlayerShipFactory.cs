using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class PlayerShipFactory : GameObjectFactory
    {

        public PlayerShipFactory(GameSettings gameSettings) :base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace) //этот метод возвращает только один объект - тут не будет коллекции
        {
            
            GameObject gameObject = new PlayerShip() { Figure = GameSettings.PlayerShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.PlayerShip };

            return gameObject;
        }
        public GameObject GetGameObject() //перегрузили наш конструктор, тк в классе Сцена он не должен получать параметры
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.PlayerShipStartXCoordinate, YCoordinate = GameSettings.PlayerShipStartYCoordinate };
            GameObject gameObject = GetGameObject(place);
            return gameObject;
        }
    }
}
