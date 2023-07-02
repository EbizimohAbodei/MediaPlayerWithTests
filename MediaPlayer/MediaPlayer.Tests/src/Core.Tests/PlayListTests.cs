using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Core.Tests
{
    public class PlayListTests
    {
        private class ConcreteMediaFile : MediaFile
        {
            public ConcreteMediaFile(string fileName, string filePath, TimeSpan duration, double speed)
                : base(fileName, filePath, duration, speed)
            {
            }
        }

        [Fact]
        public void AddNewFile_InvalidUser_DoesNotAddFileToList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var validUserId = 123;
            var invalidUserId = 456;
            var file = new ConcreteMediaFile("Sample.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(180), 1.0);

            // Act
            var playlist = new PlayList(playlistName, validUserId);
            playlist.AddNewFile(file, invalidUserId);

            // Assert
            Assert.Empty(playlist.Files);
        }

        [Fact]
        public void AddNewFile_ValidUser_AddsFileToList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var userId = 123;
            var file = new ConcreteMediaFile("Sample.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(180), 1.0);

            // Act
            var playlist = new PlayList(playlistName, userId);
            playlist.AddNewFile(file, userId);

            //Assert
            Assert.Single(playlist.Files);
            Assert.Equal(file, playlist.Files[0]);
        }

        [Fact]
        public void RemoveFile_ValidUser_RemovesFileFromList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var userId = 123;
            var file = new ConcreteMediaFile("Sample.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(180), 1.0);

            //Act
            var playlist = new PlayList(playlistName, userId);
            playlist.AddNewFile(file, userId);
            playlist.RemoveFile(file, userId);

            // Assert
            Assert.Empty(playlist.Files);

        }

        [Fact]
        public void RemoveFile_InvalidUserId_DoesNotRemoveFileFromList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var validUserId = 123;
            var invalidUserId = 456;
            var file = new ConcreteMediaFile("Sample.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(180), 1.0);

            // Act
            var playlist = new PlayList(playlistName, validUserId);
            playlist.AddNewFile(file, validUserId);
            playlist.RemoveFile(file, invalidUserId);

            // Assert
            Assert.Single(playlist.Files);
        }

         [Fact]
        public void EmptyList_WhenValidUserId_ClearsFilesList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var userId = 123;
            var file1 = new ConcreteMediaFile("Sample_one.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(10), 5.0);
            var file2 = new ConcreteMediaFile("Sample_two.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(120), 1.0);

            // Act
            var playlist = new PlayList(playlistName, userId);
            playlist.AddNewFile(file1, userId);
            playlist.AddNewFile(file2, userId);
            playlist.EmptyList(userId);

            // Assert
            Assert.Empty(playlist.Files);
        }

        [Fact]
        public void EmptyList_WhenInvalidUserId_DoesNotClearFilesList()
        {
            // Arrange
            var playlistName = "My Playlist";
            var validUserId = 123;
            var invalidUserId = 456;
            var file1 = new ConcreteMediaFile("Sample_one.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(110), 3.0);
            var file2 = new ConcreteMediaFile("Sample_two.mp3", "/path/to/sample.mp3", TimeSpan.FromSeconds(80), 2.0);

            // Act
            var playlist = new PlayList(playlistName, validUserId);
            playlist.AddNewFile(file1, validUserId);
            playlist.AddNewFile(file2, validUserId);
            playlist.EmptyList(invalidUserId);

            // Assert
            Assert.Equal(2, playlist.Files.Count);
        }

    }
}