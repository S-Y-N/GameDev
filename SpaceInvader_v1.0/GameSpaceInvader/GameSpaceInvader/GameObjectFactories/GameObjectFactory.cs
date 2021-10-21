using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
     abstract class GameObjectFactory
    {
        //у фабрики есть некоторые настройки на основании чего будут созд объекты

        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectPlace objectPlace);//метод который будет служить шаблоном для коллекций

        public GameObjectFactory(GameSettings gameSettings) //к-тор созд настроек 
        {
            GameSettings = gameSettings;
        }

    }
}
