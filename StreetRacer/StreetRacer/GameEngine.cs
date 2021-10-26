using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace StreetRacer
{
    class GameEngine
    {

        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private SceneRender _sceneRender;
        private Scene _scene;
        private GameSettings _gameSettings;
        private GameEngine() { }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int bugattiMoveCounter = 0;
            int bmwMoveCounter = 0;
            int sprinterMoveCounter = 0;
            int belazMoveCounter = 0;


            do
            {
                _sceneRender.ClearScreen();
                _sceneRender.Render(_scene);
                Thread.Sleep(_gameSettings.GameSpeed);
                if (bugattiMoveCounter == _gameSettings.BuggatiSpeed)
                {
                    MoveBugatti();
                    bugattiMoveCounter = 0;
                }
                bugattiMoveCounter++;
                if (bmwMoveCounter == _gameSettings.BmwSpeed)
                {
                    MoveBMW();
                    bmwMoveCounter = 0;
                }
                bmwMoveCounter++;
                if (sprinterMoveCounter == _gameSettings.SprinterSpeed)
                {
                    MoveSprinter();
                    sprinterMoveCounter = 0;
                }
                sprinterMoveCounter++;
                if (belazMoveCounter == _gameSettings.BelazSpeed)
                {
                    MoveBelaz();
                    belazMoveCounter = 0;
                }
                belazMoveCounter++;


            } while (_isNotOver);
            Console.ForegroundColor = ConsoleColor.Green;
            _sceneRender.RenderGameOver();
        }

        public void MoveBugatti()
        {
            if (_scene.bugatti.GameObjectPlace.XCoordinate < 75)
            {
                _scene.bugatti.GameObjectPlace.XCoordinate++;
            }

        }
        public void MoveBMW()
        {
            if (_scene.bmw.GameObjectPlace.XCoordinate < 75)
            {
                _scene.bmw.GameObjectPlace.XCoordinate++;
            }
        }
        public void MoveSprinter()
        {
            if (_scene.sprinter.GameObjectPlace.XCoordinate < 75)
            {
                _scene.sprinter.GameObjectPlace.XCoordinate++;
            }
        }
        public void MoveBelaz()
        {
            if (_scene.belaz.GameObjectPlace.XCoordinate < 75)
            {
                _scene.belaz.GameObjectPlace.XCoordinate++;
            }
        }
    }
}
