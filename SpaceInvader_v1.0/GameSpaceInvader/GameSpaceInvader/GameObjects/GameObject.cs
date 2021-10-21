using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
     abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }

        public char Figure { get; set; }//в этой реализации игры объекты представлены символами, но можно их заменить на массив символов,
                                        //но для этого нужно немного изменить логику для отрисовки
        public GameObjectType GameObjectType { get; set; }

    }
}
