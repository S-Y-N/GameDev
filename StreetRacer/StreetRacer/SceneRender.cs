using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    //Суть этого класса вывести содержимое класса Сцена на экран
    class SceneRender
    {
        int _screenWhidth;
        int _screenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)//класс скринрендер будет один - реализ сингтон
        {
            _screenWhidth = gameSettings.ConsoleWidth;//присвоения параметров
            _screenHeight = gameSettings.ConsoleHeight;

            _screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];//создание матрицы и передача значений в нее

            Console.WindowHeight = gameSettings.ConsoleHeight;//настройка параметров консоли
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;//убираем видимость курсора
            Console.SetCursorPosition(0, 0);//сброс настроек курсора
        }
        public void Render(Scene scene)
        {
            Console.SetCursorPosition(0, 0);

            AddListForRendering(scene.finish);//деплой коллекции финиша

            AddGameObjectForRendering(scene.bugatti);//вызываем рендер для машинок
            AddGameObjectForRendering(scene.bmw);
            AddGameObjectForRendering(scene.sprinter);
            AddGameObjectForRendering(scene.belaz);
            //все элементы загрузили в матрицу - теперь создаем конструктор для вывода всего на экран
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWhidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);//переход на новую строку
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);

        }
        public void AddGameObjectForRendering(CarObject carObject)
        {
            if (carObject.GameObjectPlace.YCoordinate < _screenMatrix.GetLength(0) && carObject.GameObjectPlace.XCoordinate < _screenMatrix.GetLength(1))
            {//проверка не выходит ли объект за границы и если вышел - не рендерить его
                _screenMatrix[carObject.GameObjectPlace.YCoordinate, carObject.GameObjectPlace.XCoordinate] = carObject.Figure;
            }
            else
            {
                ;
            }
        }
        //------------------
        public void AddListForRendering(List<CarObject> carObjects)//создаем коллекцию 
        {
            foreach (CarObject carObject in carObjects)//проганяем их через цикл
            {
                AddGameObjectForRendering(carObject);
            }
        }
        //-------------------

        public void ClearScreen()//очистка экрана
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
            stringBuilder.Append("Finish!\nGame Over!");
            Console.WriteLine(stringBuilder.ToString());
        }

    }
}
