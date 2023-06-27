using System;

namespace MediaPlayer.Domain.src.Core
{
    public class Video : MediaFile
    {
        public Video(string fileName, string filePath, TimeSpan duration, double speed) : base(fileName, filePath, duration, speed)
        {
        }
    }
}