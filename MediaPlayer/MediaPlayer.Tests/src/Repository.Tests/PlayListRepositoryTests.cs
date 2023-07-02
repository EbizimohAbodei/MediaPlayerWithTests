using MediaPlayer.Infrastructure.src.Repository;

namespace MediaPlayer.Tests.src.Repository.Tests
{
    public class PlayListRepositoryTests
    {
        [Fact]
        public void AddNewFile_PlaylistDoesNotExists_AddsNewFileToPlaylist()
        {
            // Arrange
            PlayListRepository repository = new PlayListRepository();

            // Act
            repository.AddNewFile(1, 10001, 1);

            // Assert
            List<int> playlist = repository.GetPlaylist(1);
            Assert.NotNull(playlist);
            Assert.Single(playlist);
            Assert.Contains(10001, playlist);
        }

        [Fact]
        public void AddNewFile_PlaylistExists()
        {
            // Arrange
            PlayListRepository repository = new PlayListRepository();
            repository.AddNewFile(1, 10001, 1);

            // Act
            repository.AddNewFile(1, 10002, 1);

            // Assert
            List<int> playlist = repository.GetPlaylist(1);
            Assert.NotNull(playlist);
            Assert.Equal(2, playlist.Count);
            Assert.Contains(10001, playlist);
            Assert.Contains(10002, playlist);
        }

        [Fact]
        public void EmptyList_PlaylistExists()
        {
            // Arrange
            var playlistRepository = new PlayListRepository();
            int playListId = 1;
            int userId = 10001;

            // Add files to the playlist
            playlistRepository.AddNewFile(playListId, 10001, 10001);
            playlistRepository.AddNewFile(playListId, 10002, 10001);

            // Act
            playlistRepository.EmptyList(playListId, userId);

            // Assert
            var playlist = playlistRepository.GetPlaylist(playListId);
            Assert.DoesNotContain(userId, playlist);
            Assert.Single(playlist);
        }

        [Fact]
        public void EmptyList_PlaylistDoesNotExist()
        {
            // Arrange
            PlayListRepository repository = new PlayListRepository();

            // Act
            repository.EmptyList(1, 1);

            // Assert (No exception should be thrown)
            Assert.True(true);
        }

        [Fact]
        public void RemoveFile_PlaylistExists()
        {
            // Arrange
            PlayListRepository repository = new PlayListRepository();
            repository.AddNewFile(1, 10001, 1);
            repository.AddNewFile(1, 10002, 1);

            // Act
            repository.RemoveFile(1, 10001, 1);

            // Assert
            List<int> playlist = repository.GetPlaylist(1);
            Assert.NotNull(playlist);
            Assert.Single(playlist);
            Assert.DoesNotContain(10001, playlist);
            Assert.Contains(10002, playlist);
        }

        [Fact]
        public void RemoveFile_PlaylistDoesNotExist()
        {
            // Arrange
            PlayListRepository repository = new PlayListRepository();

            // Act
            repository.RemoveFile(1, 101, 1);

            // Assert (No exception should be thrown)
            Assert.True(true);
        }
    }
}