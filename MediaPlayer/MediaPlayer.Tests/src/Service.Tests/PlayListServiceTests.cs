using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.RepositoryInterface;
using Moq;

namespace MediaPlayer.Tests.src.Service.Test
{
    public class PlayListServiceTests
    {
        private readonly Mock<IPlayListRepository> _mockPlayListRepository;
        private readonly PlayListService _playListService;

        public PlayListServiceTests()
        {
            _mockPlayListRepository = new Mock<IPlayListRepository>();
            _playListService = new PlayListService(_mockPlayListRepository.Object);
        }

        [Fact]
        public void AddNewFile_CallsPlayListRepositoryWithCorrectArguments()
        {
            // Arrange
            int playListId = 1;
            int fileId = 123;
            int userId = 456;

            // Act
            _playListService.AddNewFile(playListId, fileId, userId);

            // Assert
            _mockPlayListRepository.Verify(r => r.AddNewFile(playListId, fileId, userId), Times.Once);
        }

        [Fact]
        public void RemoveFile_CallsPlayListRepositoryWithCorrectArguments()
        {
            // Arrange
            int playListId = 1;
            int fileId = 123;
            int userId = 456;

            // Act
            _playListService.RemoveFile(playListId, fileId, userId);

            // Assert
            _mockPlayListRepository.Verify(r => r.RemoveFile(playListId, fileId, userId), Times.Once);
        }

        [Fact]
        public void EmptyList_CallsPlayListRepositoryWithCorrectArguments()
        {
            // Arrange
            int playListId = 1;
            int userId = 456;

            // Act
            _playListService.EmptyList(playListId, userId);

            // Assert
            _mockPlayListRepository.Verify(r => r.EmptyList(playListId, userId), Times.Once);
        }
    }
}