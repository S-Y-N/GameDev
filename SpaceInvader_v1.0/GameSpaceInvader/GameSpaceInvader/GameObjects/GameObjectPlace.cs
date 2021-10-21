using System;
using System.Collections.Generic;
using System.Text;

namespace GameSpaceInvader
{
    class GameObjectPlace //будет хранить координаты по Х и У
    {
        //получаем инкапсулированую логику какой-то точки
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public override bool Equals(object obj)
        {
            GameObjectPlace newObj = obj as GameObjectPlace;//приводим объект к классу

            if(newObj !=null && this.XCoordinate == newObj.XCoordinate&&this.YCoordinate ==newObj.YCoordinate)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
