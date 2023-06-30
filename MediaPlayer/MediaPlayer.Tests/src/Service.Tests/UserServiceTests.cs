using MediaPlayer.Business.src.Service;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Tests.src.Service.Test
{
    public class UserServiceTests
    {
        private class FakeUserRepository : IUserRepository
        {
            public string? AddedListName { get; private set; }
            public int AddedListUserId { get; private set; }
            public int EmptyListId { get; private set; }
            public int EmptyListUserId { get; private set; }
            public int GetAllListUserId { get; private set; }
            public int GetListByIdId { get; private set; }
            public int RemoveAllListsUserId { get; private set; }
            public int RemoveOneListId { get; private set; }
            public int RemoveOneListUserId { get; private set; }

            public void AddNewList(string name, int userId)
            {
                AddedListName = name;
                AddedListUserId = userId;
            }

            public void GetAllList(int userId)
            {
                GetAllListUserId = userId;
            }

            public void RemoveAllLists(int userId)
            {
                RemoveAllListsUserId = userId;
            }

            public void RemoveOneList(int listId, int userId)
            {
                RemoveOneListId = listId;
                RemoveOneListUserId = userId;
            }

            public void GetListById(int listId)
            {
                GetListByIdId = listId;
            }

            public void EmptyOneList(int listId, int userId)
            {
                EmptyListId = listId;
                EmptyListUserId = userId;
            }

        }

        [Fact]
        public void AddNewList_CallsUserRepositoryWithCorrectArguments()
        {
            // Arrange
            string name = "My Playlist";
            int userId = 123;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.AddNewList(name, userId);

            // Assert
            Assert.Equal(name, userRepository.AddedListName);
            Assert.Equal(userId, userRepository.AddedListUserId);
        }

        [Fact]
        public void RemoveOneList_CallsUserRepositoryWithCorrectArguments()
        {
            // Arrange
            int listId = 1;
            int userId = 123;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.RemoveOneList(listId, userId);

            // Assert
            Assert.Equal(listId, userRepository.RemoveOneListId);
            Assert.Equal(userId, userRepository.RemoveOneListUserId);
        }

        [Fact]
        public void GetListById_CallsUserRepositoryWithCorrectArgument()
        {
            // Arrange
            int listId = 1;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.GetListById(listId);

            // Assert
            Assert.Equal(listId, userRepository.GetListByIdId);
        
        }

        [Fact]
        public void EmptyOneList_CallsUserRepositoryWithCorrectArguments()
        {
            // Arrange
            int listId = 1;
            int userId = 123;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.EmptyOneList(listId, userId);

            // Assert
            Assert.Equal(listId, userRepository.EmptyListId);
            Assert.Equal(userId, userRepository.EmptyListUserId);
        }

        [Fact]
        public void GetAllList_CallsUserRepositoryWithCorrectArgument()
        {
            // Arrange
            int userId = 123;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.GetAllList(userId);

            // Assert
            Assert.Equal(userId, userRepository.GetAllListUserId);
        }

        [Fact]
        public void RemoveAllLists_CallsUserRepositoryWithCorrectArgument()
        {
            // Arrange
            int userId = 123;
            var userRepository = new FakeUserRepository();
            var userService = new UserService(userRepository);

            // Act
            userService.RemoveAllLists(userId);

            // Assert
            Assert.Equal(userId, userRepository.RemoveAllListsUserId);
        }

    }
}