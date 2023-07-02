using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Core.Tests
{
    public class MediaFileTests
    {
        private class TestableMediaFile : MediaFile
        {
            public TestableMediaFile(string fileName, string filePath, TimeSpan duration, double speed)
                : base(fileName, filePath, duration, speed)
            {
            }
            public bool GetIsPlaying() => GetIsPlayingInternal();
            public TimeSpan GetCurrentPosition() => GetCurrentPositionInternal();
        }

        [Fact]
        public void Play_WhenCalled_StartsPlayback()
        {
            // Arrange
            var fileName = "Sample.mp3";
            var filePath = "/path/to/sample.mp3";
            var duration = TimeSpan.FromSeconds(180);
            var speed = 1.0;
            var mediaFile = new TestableMediaFile(fileName, filePath, duration, speed);

            // Act
            mediaFile.Play();

            // Assert
            Assert.True(mediaFile.GetIsPlaying());
        }

        [Fact]
        public void Pause_WhenPlaying_PausesPlayback()
        {
            // Arrange
            var fileName = "Sample.mp3";
            var filePath = "/path/to/sample.mp3";
            var duration = TimeSpan.FromSeconds(180);
            var speed = 1.0;
            var mediaFile = new TestableMediaFile(fileName, filePath, duration, speed);
            mediaFile.Play();

            // Act
            mediaFile.Pause();

            // Assert
            Assert.False(mediaFile.GetIsPlaying());
        }

        [Fact]
        public void GetCurrentPosition_WhenPlaying_ReturnsValidPosition()
        {
            // Arrange
            var fileName = "Sample.mp3";
            var filePath = "/path/to/sample.mp3";
            var duration = TimeSpan.FromSeconds(180);
            var speed = 1.0;
            var mediaFile = new TestableMediaFile(fileName, filePath, duration, speed);
            mediaFile.Play();

            // Act
            var currentPosition = mediaFile.GetCurrentPosition();

            // Assert
            Assert.True(currentPosition >= TimeSpan.Zero);
            Assert.True(currentPosition <= duration);
        }

        [Fact]
        public void GetCurrentPosition_WhenPaused_ReturnsPausedPosition()
        {
            // Arrange
            var fileName = "Sample.mp3";
            var filePath = "/path/to/sample.mp3";
            var duration = TimeSpan.FromSeconds(180);
            var speed = 1.0;
            var mediaFile = new TestableMediaFile(fileName, filePath, duration, speed);
            mediaFile.Play();
            mediaFile.Pause();
            var expectedPosition = mediaFile.GetCurrentPosition();

            // Act
            var currentPosition = mediaFile.GetCurrentPosition();

            // Assert
            Assert.Equal(expectedPosition, currentPosition);
        }
    }
}