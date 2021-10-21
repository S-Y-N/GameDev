using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class Scene  //некий слепок соостояния экрана
                 //сцена состоит из коллекций объектов захватчиков, игрока, ракет и поверхности Земли
    {
        public List<GameObject> swarm;     //используем базовый класс как основу для наших коллекций вражеских корблей(рой)

        public List<GameObject> ground; //коллекция элементов земли

        public GameObject playerShip;

        public List<GameObject> playerShipMissile; //коллекция ракет пользователя
        GameSettings _gameSettings;

        private static Scene _scene;  //реализация паттерна singlton, что объект созд в единствен варианте 

        private Scene()
        {

        }
        private Scene(GameSettings gameSettings)//к-тор настроек и иннициал наших коллекций
        {
            _gameSettings = gameSettings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm(); //инициализ нашу фабрику

            //нужно создать фабрики для всех объектов
            ground = new GroundFactory(_gameSettings).GetGround();//создаем фабрику для Земли и передаем ей настройки для коллекции
            playerShip = new PlayerShipFactory(_gameSettings).GetGameObject(); //тут вызывается наша перегрузка и соответ она не требует параметров
            playerShipMissile = new List<GameObject>();
        }
        public static Scene GetScene(GameSettings gameSettings) //метод возвращает нам сцену
        {
            if (_scene == null) //реализация паттерна синглтон, что объект созд в един варианте, если объекта нет, то создать
            {
                _scene = new Scene(gameSettings);
            }

            return _scene; //если объект есть - вернуть созданный объект

        }

    }
}
