using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.RepositoryInterface;
using Moq;

namespace MediaPlayer.Tests.src.Service.Test
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void AddNewList_CallsUserRepositoryWithCorrectArguments()
        {
            // Arrange
            string name = "My Playlist";
            int userId = 123;

            // Act
            _userService.AddNewList(name, userId);

            // Assert
            _mockUserRepository.Verify(r => r.AddNewList(name, userId), Times.Once);
        }

    }
}