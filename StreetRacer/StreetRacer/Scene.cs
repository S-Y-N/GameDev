using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class Scene
        //Сцена - это отображения состояния экрана и слепок всех классов в моменте
        //сцена состоит из машин, игрового поля 
    {
        public CarObject bugatti;
        public CarObject bmw;
        public CarObject sprinter;
        public CarObject belaz;

        public List<CarObject> finish;

        GameSettings _gameSettings;

        private static Scene _scene; //реализация паттерна синглтон

        private Scene()
        {

        }
        private Scene(GameSettings gameSettings)//к-тор настроек и инициализация наших коллекция
        {
            _gameSettings = gameSettings;

            finish = new FinishFactory(_gameSettings).GetFinish();//создаем коллекцию для финиша и передаем ей коллекцию

            bugatti = new BugattiFactory(_gameSettings).GetCarObject();//вызываем нашу перегрузку и она не требует параметров
            bmw = new BmwFactory(_gameSettings).GetCarObject();
            sprinter = new SprinterFactory(_gameSettings).GetCarObject();
            belaz = new BelazFactory(_gameSettings).GetCarObject();

        }
        public static Scene GetScene(GameSettings gameSettings)//этот метод возвращает нам сцену
        {
            if(_scene  == null)//реализация паттерна синглтона, если сцены нет - создать
            {
                _scene = new Scene(gameSettings);//создание и наполенение
            }
            return _scene;//если есть - вернуть
        }
    }
}
