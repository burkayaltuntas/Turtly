using System;
using System.Collections.Generic;
using System.IO;
using Turtly.Game.Models;
using System.Text;

namespace Turtly.Game.Helpers
{
    public class FileReader
    {
   
        private static FileReader _fileReader;
        private FileReader() { }
        public static FileReader Instance()
        {
            return _fileReader ?? (_fileReader = new FileReader());
        }


        public SettingsModel GetSettings()
        {
            var settingString = File.ReadAllLines("..\\..\\..\\GameSettings.csv");
            var settings = new SettingsModel();

            var sizeStrings = settingString[0].Split(' ');
            int.TryParse(sizeStrings[0], out var sizeX);
            int.TryParse(sizeStrings[1], out var sizeY);
            settings.Size = new Point(sizeX, sizeY);

            var minePointStrings = settingString[1].Split(' ');
            foreach (var item in minePointStrings)
            {
                var minePoints = item.Split(',');
                int.TryParse(minePoints[0], out var mineX);
                int.TryParse(minePoints[1], out var mineY);
                settings.MinePoints.Add(new Point(mineX, mineY));

            }

            var successPointStrings = settingString[2].Split(' ');
            int.TryParse(successPointStrings[0], out var exitX);
            int.TryParse(successPointStrings[1], out var exitY);
            settings.SuccessPoint = new Point(exitX, exitY);

            var startPositionStrings = settingString[3].Split(' ');
            int.TryParse(startPositionStrings[0], out var posX);
            int.TryParse(startPositionStrings[1], out var posY);
            settings.StartPoint = new Point(posX, posY);
            if(startPositionStrings[2] == "N")
            {
                settings.Direction = "North";
            }
            else if (startPositionStrings[2] == "S")
            {
                settings.Direction = "South";
            }
            else if (startPositionStrings[2] == "E")
            {
                settings.Direction = "East";
            }
            else if (startPositionStrings[2] == "W")
            {
                settings.Direction = "West";
            }

            settings.Moves = settingString[4].Split(' ');



            return settings;
        }

    }
}
