using System;

namespace GameSpaceInvader
{


    class Program
    {
        static GameEngine gameEngine;

        static GameSettings gameSettings;

        static UIController uIController;
        static Music musicControl;

        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            
            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePressed += (obj, arg) => gameEngine.Shot();//создали ракету


            System.Threading.Thread uIthread = new System.Threading.Thread(uIController.StartListing);
            uIthread.Start();
            musicControl = new Music();
            System.Threading.Thread musicThread = new System.Threading.Thread(musicControl.BackgroundMusic);

            musicThread.Start();

            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.AboveNormal;
        }
    }
}
