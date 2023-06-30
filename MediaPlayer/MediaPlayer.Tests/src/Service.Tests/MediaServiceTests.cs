using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.RepositoryInterface;
using Moq;

namespace MediaPlayer.Tests.src.Service.Test
{
     public class MediaServiceTests
    {
        private readonly Mock<IMediaRepository> _mockMediaRepository;
        private readonly MediaService _mediaService;

        public MediaServiceTests()
        {
            _mockMediaRepository = new Mock<IMediaRepository>();
            _mediaService = new MediaService(_mockMediaRepository.Object);
        }

        [Fact]
        public void CreateNewFile_CallsMediaRepositoryWithCorrectArguments()
        {
            // Arrange
            string fileName = "test.mp3";
            string filePath = "/path/to/file";
            var duration = new TimeSpan(0, 5, 0);

            // Act
            _mediaService.CreateNewFile(fileName, filePath, duration);

            // Assert
            _mockMediaRepository.Verify(r => r.CreateNewFile(fileName, filePath, duration), Times.Once);
        }

        [Fact]
        public void DeleteFileById_CallsMediaRepositoryWithCorrectArgument()
        {
            // Arrange
            int fileId = 123;

            // Act
            _mediaService.DeleteFileById(fileId);

            // Assert
            _mockMediaRepository.Verify(r => r.DeleteFileById(fileId), Times.Once);
        }

        [Fact]
        public void GetAllFiles_CallsMediaRepository()
        {
            // Act
            _mediaService.GetAllFiles();

            // Assert
            _mockMediaRepository.Verify(r => r.GetAllFiles(), Times.Once);
        }

        [Fact]
        public void GetFileById_CallsMediaRepositoryWithCorrectArgument()
        {
            // Arrange
            int fileId = 123;

            // Act
            _mediaService.GetFileById(fileId);

            // Assert
            _mockMediaRepository.Verify(r => r.GetFileById(fileId), Times.Once);
        }
    }
}