using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    //задача этого класса содержат все методы что реализ в классе Scene и вывести это на экран 
    class SceneRender 
    {
        int _screenWhidth;

        int _screenHeight;

        char[,] _screenMatrix; // массив символов

        public SceneRender(GameSettings gameSettings) //тк класс скринрендер будет один - можно реализ синглтон
        {
            _screenWhidth = gameSettings.ConsoleWidth ;
            _screenHeight = gameSettings.ConsoleHight;

            _screenMatrix = new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth]; //реализация матрицы символов, передаем ей значения с настроек

            Console.WindowHeight = gameSettings.ConsoleHight; //настройка экрана консоли
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false; //свойство видимости курсора на экране
            Console.SetCursorPosition(0, 0); //Скидаываем настройки позиции курсора на экране 
        }

        public void Render(Scene scene)//вывод содержимого на экран
        {


            

            Console.SetCursorPosition(0, 0);

            AddListForRendering(scene.swarm);//отправляем на рендер коллекцию врагов
            AddListForRendering(scene.ground);
            AddListForRendering(scene.playerShipMissile);

            AddGameObjectForRendering(scene.playerShip);//вызываем ренд для нашего корабля
            //все элементы добавлены в матрицу и с ней нужно что делать
            //на основании этой матрицы нужно формировать конструкцию к-рая будет вывод на экран

            StringBuilder stringBuilder = new StringBuilder();
            for(int y = 0; y< _screenHeight; y++)
            {
                for(int x=0; x<_screenWhidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);//переход на новую строку 
            }

            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if(gameObject.GameObjectPlace.YCoordinate<_screenMatrix.GetLength(0)&& //проверка не выходит ли объект за границы
                gameObject.GameObjectPlace.XCoordinate<_screenMatrix.GetLength(1))//если вышел  - не рендерить 
            {
                _screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = gameObject.Figure;
                
            }
            else
            {
               //  _screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = ' ';//если вышел - добавить пробелы
            }
        }


        public void AddListForRendering(List<GameObject> gameObjects) //создание коллекции объектов
        {
            foreach(GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
           
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWhidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                }
              
            }

            Console.SetCursorPosition(0, 0);


        }
        public void RenderGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Game Over!");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
