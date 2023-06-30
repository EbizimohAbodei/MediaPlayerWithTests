using System;
using System.Collections.Generic;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class PlayListRepository : IPlayListRepository
    {
        private Dictionary<int, List<int>> _playlists; // Dictionary to store playlists

        public PlayListRepository()
        {
            _playlists = new Dictionary<int, List<int>>();
        }
        public void AddNewFile(int playListId, int fileId, int userId)
        {
            if (_playlists.ContainsKey(playListId))
            {
                List<int> playlist = _playlists[playListId];
                if (!playlist.Contains(fileId))
                {
                    playlist.Add(fileId);
                    Console.WriteLine($"Added File ID {fileId} to Playlist ID {playListId} for User ID {userId}");
                }
                else
                {
                    Console.WriteLine($"File ID {fileId} already exists in Playlist ID {playListId}");
                }
            }
            else
            {
                List<int> playlist = new List<int> { fileId };
                _playlists.Add(playListId, playlist);
                Console.WriteLine($"Added File ID {fileId} to new Playlist ID {playListId} for User ID {userId}");
            }
        }

        public void EmptyList(int playListId, int userId)
        {
            if (_playlists.ContainsKey(playListId))
            {
                List<int> playlist = _playlists[playListId];
                if (playlist.Contains(userId))
                {
                    playlist.Remove(userId);
                    Console.WriteLine($"Removed File ID {userId} from Playlist ID {playListId} for User ID {userId}");
                }
                else
                {
                    Console.WriteLine($"File ID {userId} does not exist in Playlist ID {playListId}");
                }
            }
            else
            {
                Console.WriteLine($"Playlist ID {playListId} not found");
            }
        }

        public void RemoveFile(int playListId, int fileId, int userId)
        {
            if (_playlists.ContainsKey(playListId))
            {
                _playlists[playListId].Clear();
                Console.WriteLine($"Emptied Playlist ID {playListId} for User ID {userId}");
            }
            else
            {
                Console.WriteLine($"Playlist ID {playListId} not found");
            }
        }
    }
}