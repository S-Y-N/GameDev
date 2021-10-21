using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class GameEngine //этот класс соответственно должен быть сингтоном
    {
        //класс можно сделать статическим, он будет выполнять механиз синглтона и будет хранилищем коллекций
        //но все так класс должен возвращать методы
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private SceneRender _sceneRender;
        private Scene _scene;
        private GameSettings _gameSettings;
        private GameEngine() { }

        public static GameEngine GetGameEngine(GameSettings gameSettings) //метод возвращает настройки
        {
            if(_gameEngine == null)//проверка состояния если нет - создать
            {
                _gameEngine = new GameEngine(gameSettings);//если нет - создать

            }
            return _gameEngine;//если есть - вернуть
        }

        private GameEngine(GameSettings  gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings); //класс Сцена исповедует синглтон -- передаем метод который реализ в ее классе
            //сейчас у нас есть сцена в некотором состоянии - и мы можем ее отрисовать
            _sceneRender = new SceneRender(gameSettings);
        }
        
        public void Run() //метод запускает отрисовку игры
        {
            //нужен безконечний цикл для отрисовки всех элементов игры
            //тк нужно хотя бы раз отрисоваться - цикл тут логично ду вайл
            int swarmMoveCounter = 0;
            int playerMissileCounter = 0;
            do
            {
                _sceneRender.ClearScreen();//очистка экрана от дерганья
                _sceneRender.Render(_scene);

                System.Threading.Thread.Sleep(_gameSettings.GameSpeed);//скорость задержки цикла

                
                if(swarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }
                swarmMoveCounter++;

                if(playerMissileCounter == _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }
                playerMissileCounter++;//увеличить если не попадаем на пересчет
            } while (_isNotOver);
            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();

        }


        public void CalculateMovePlayerShipLeft()//метод передвижения корабля игрока
                                                 //метод передвижения должен базироваться на текущем положения корабля
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;//если больше то двигаемся влево
            }

        }
        public void CalculateMovePlayerShipRight()//метод передвижения корабля игрока
                                                  //метод передвижения должен базироваться на текущем положения корабля
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;//если меньше  то двигаемся вправо
            }

        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    //если координаты врагов будут равны координатам игрока = конец игры и изменения состояния игры

                    _isNotOver = false;
                }



            }

        }

        public void Shot()
        {
            //создания ракет = создаем новый класс и параметризиуем его
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);
            //создаем объект ракет = их положение должно быть привязанно к текущему положению корабля игрока
            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.GameObjectPlace);


            _scene.playerShipMissile.Add(missile);//добавление коллекции ракет

           // Console.Beep(1000, 200); //будет издавать звук, первое число частота, второе длительность
        }

        public void CalculateMissileMove()//переопределение положения ракеты в текущий момент
        {
            if(_scene.playerShipMissile.Count==0)//если ракет нет - пересчет делать не нужно - возрат значения
            {
                return;
            }
            //если есть - сделать рассчет и сопоставить координаты корабля врага и ракеты
            for(int x=0; x<_scene.playerShipMissile.Count;x++)
            {

                GameObject missile = _scene.playerShipMissile[x];

                if(missile .GameObjectPlace.YCoordinate ==1)
                {
                    _scene.playerShipMissile.RemoveAt(x);//если ракета дойдет до границы поля - она должна уничтожиться

                 
                }
                missile.GameObjectPlace.YCoordinate--;

                for(int i =0; i<_scene.swarm.Count;i++)//ракета пока не обойдет всех корабли врагов
                {
                    GameObject alienShip = _scene.swarm[i];//получаем нашего корабля врагов для дальнейшего сравнения
                    if(missile.GameObjectPlace.Equals(alienShip.GameObjectPlace))//и сравнить его координаты(врага) и координаты ракеты
                    {
                        _scene.swarm.RemoveAt(i);//если координаты совпали - удалить

                        _scene.playerShipMissile.RemoveAt(x);// и удалить ракету тоже

                        break;//выход с цикла, что бы цикл мог работать снова с другими ракетами

                    }
                }

            }

        }
    }
}
