using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class UIController
    {

        //класс контроллер перемещения игрока по полю
        //любое передвижение осуществляется нажатием на клавишу - а это событие для системы
        //по этому используем события и делегаты

       public  event EventHandler OnAPressed;//событие нажатия на клавишу А
        public event EventHandler OnDPressed;// Д
        public event EventHandler OnSpacePressed;//событие выстрела

        public void StartListing()
        {
            while(true)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);// //метод для проверки нажатия на клавишу - равно тру - что бы не выводило на консоль введеную клавишу
                if(key.Key.Equals(ConsoleKey.A))
                {
                    OnAPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.D))
                {
                    OnDPressed?.Invoke(this, new EventArgs());
                }
                else if(key.Key.Equals(ConsoleKey.Spacebar))
                {
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
                else
                {

                }
            }
        }
    }
}
