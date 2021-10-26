using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacer
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHeight { get; set; } = 30;

        //------------------------------------------
        //Bugatti Chiron
        public char Bugatti { get; set; } = 'B'; //пока реализация символами, в релизе 2.0 - массив
        public int BuggatiSpeed { get; set; } = 2;

        public int StartPositionXCoordinateForBugatti { get; set; } = 2;
        public int StartPositionYCoordinateForBugatti { get; set; } = 7;

        //-------------------------------------------------
        public char BMW { get; set; } = 'W';
        public int BmwSpeed { get; set; } = 5;

        public int StartPositionXCoordinateForBMW { get; set; } = 2;
        public int StartPositionYCoordinateForBMW { get; set; } = 13;


        //-------------------------------------------------
        public char Sprinter { get; set; } = 'S';
        public int SprinterSpeed { get; set; } = 8;

        public int StartPositionXCoordinateForSprinter { get; set; } = 2;
        public int StartPositionYCoordinateForSprinter { get; set; } = 18;
        //-------------------------------------------------
        public char Belaz { get; set; } = 'G';
        public int BelazSpeed { get; set; } = 10;

        public int StartPositionXCoordinateForBelaz { get; set; } = 2;
        public int StartPositionYCoordinateForBelaz { get; set; } = 23;

        //----------------------------------------------------

        public int FinishStartXCoordanite { get; set; } = 75;
        public int FinishStartYCoordanite { get; set; } = 1;

        public char Finish { get; set; } = '*';

        public int NumberOfFinishRows { get; set; } = 30;
        public int NumberOfFinishColls { get; set; } = 1;
        //----------------------------------------------------
        public int GameSpeed { get; set; } = 100;
    }
}
