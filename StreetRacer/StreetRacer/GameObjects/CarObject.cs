using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    //абстрактный класс где будут реализованы свойства автомобилей
   abstract class CarObject
    {
        public char Figure { get; set; } //реализация формы машинок, тут используем строковую типизацию, можно юзать массив для объема
        public GameObjectPlace GameObjectPlace { get; set; } //задаем какие-то первоначальные координаты

        public GameObjectType GameObjectType { get; set; }//используем константы для определения типа 
    }
}
