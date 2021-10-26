//Game StreetRacer v.1.0
//Создать игру "Гонки"
//Есть 4 типа авто, они движутся к финишу с разными скоростями - побеждает кто приехал первый.
//Тристан Евгений
//ПВ-011

using System;
using System.Threading;

namespace StreetRacer
{
    class Program

    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        

        static Music musicControl;

        static void Main(string[] args)
        {
            backMusic();
            Welcome();
            Thread.Sleep(2000);
            Initialize();
            gameEngine.Run();
        }
        public static void Initialize()
        {

            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);

        }
        public static void backMusic()
        {
            //Реализация фоновой музыки
            musicControl = new Music();
            System.Threading.Thread musicThread = new System.Threading.Thread(musicControl.BackgroundMusic);
            musicThread.Start();

        }

        public static void Welcome()
        {
            string text = "Welcome to STREET RACER";
            Console.Clear();

            int centerX = (Console.WindowWidth / 2) - (text.Length / 2);
            int centerY = (Console.WindowHeight / 2) - (text.Length / 2);
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(text);

            for (int i = 3; i >= 1; i--)
            {
                int cX = (Console.WindowWidth / 2);
                int cY = (Console.WindowHeight / 2);
                Console.SetCursorPosition(cX, cY);
                Console.CursorVisible = false;
                Thread.Sleep(1000);
                Console.Write(i);
            }
        }
    }
}
