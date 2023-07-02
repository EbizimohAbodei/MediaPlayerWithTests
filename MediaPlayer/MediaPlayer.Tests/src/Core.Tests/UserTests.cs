using MediaPlayer.Domain.src.Core;

namespace MediaPlayer.Tests.src.Core.Tests
{
    public class UserTests
    {
        private class TestablePlayList : PlayList
        {
            public TestablePlayList(string name, int userId)
                : base(name, userId)
            {
            }
        }

        [Fact]
        public void AddNewList_AddsToList()
        {
            // Arrange
            var user = User.Instance;
            var playlist = new TestablePlayList("Playlist 1", user.GetId);

            // Act
            user.AddNewList(playlist);

            // Assert
            Assert.Contains(playlist, user.GetLists()); 
        }

        [Fact]
        public void RemoveOneList_WhenListExists_RemovesFromLists()
        {
            // Arrange
            var user = User.Instance;
            var playlist = new TestablePlayList("Playlist 1", user.GetId);
            user.AddNewList(playlist);

            // Act
            user.RemoveOneList(playlist);

            // Assert
            Assert.DoesNotContain(playlist, user.GetLists());
        }

        // [Fact]
        // public void RemoveOneList_WhenListDoesNotExist_ThrowsArgumentNullException()
        // {
        //     // Arrange
        //     var user = User.Instance;
        //     var playlist = new TestablePlayList("Test Playlist", user.GetId);

        //     // Act & Assert
        //     Assert.Throws<ArgumentNullException>(() => user.RemoveOneList(playlist));
        // }

        [Fact]
        public void EmptyOneList_WhenListExists_EmptiesTheList()
        {
            // Arrange
            var user = User.Instance;
            var playlist = new TestablePlayList("Playlist 1", user.GetId);
            user.AddNewList(playlist);

            // Act
            user.EmptyOneList(playlist);

            // Assert
            Assert.Empty(playlist.GetFiles());
        }

        [Fact]
        public void EmptyOneList_WhenListDoesNotExist_ThrowsArgumentNullException()
        {
            // Arrange
            var user = User.Instance;
            var playlist = new TestablePlayList("Playlist 1", user.GetId);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.EmptyOneList(playlist));
        }

    }
}