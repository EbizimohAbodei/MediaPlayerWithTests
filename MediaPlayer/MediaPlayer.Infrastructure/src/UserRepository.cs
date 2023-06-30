using System;
using System.Collections.Generic;
using MediaPlayer.Domain.src.RepositoryInterface;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<int, List<string>> _userLists; // Dictionary to store user lists

        public UserRepository()
        {
            _userLists = new Dictionary<int, List<string>>();
        }
        public void AddNewList(string name, int userId)
        {
            if (_userLists.ContainsKey(userId))
            {
                List<string> userLists = _userLists[userId];
                if (!userLists.Contains(name))
                {
                    userLists.Add(name);
                    Console.WriteLine($"Added new list '{name}' for User ID {userId}");
                }
                else
                {
                    Console.WriteLine($"List '{name}' already exists for User ID {userId}");
                }
            }
            else
            {
                List<string> userLists = new List<string> { name };
                _userLists.Add(userId, userLists);
                Console.WriteLine($"Added new list '{name}' for User ID {userId}");
            }
        }

        public void EmptyOneList(int listId, int userId)
        {
            if (_userLists.ContainsKey(userId))
            {
                List<string> userLists = _userLists[userId];
                if (listId >= 0 && listId < userLists.Count)
                {
                    string listName = userLists[listId];
                    userLists[listId] = string.Empty;
                    Console.WriteLine($"Emptied list '{listName}' (ID: {listId}) for User ID {userId}");
                }
                else
                {
                    Console.WriteLine($"List ID {listId} does not exist for User ID {userId}");
                }
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found");
            }
        }

        public void GetAllList(int userId)
        {
            if (_userLists.ContainsKey(userId))
            {
                List<string> userLists = _userLists[userId];
                Console.WriteLine($"Lists for User ID {userId}:");
                for (int i = 0; i < userLists.Count; i++)
                {
                    Console.WriteLine($"- List ID: {i}, Name: {userLists[i]}");
                }
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found");
            }
        }

        public void GetListById(int listId)
        {
            bool listFound = false;

            foreach (var userLists in _userLists.Values)
            {
                if (listId >= 0 && listId < userLists.Count)
                {
                    string listName = userLists[listId];
                    if (!string.IsNullOrEmpty(listName))
                    {
                        Console.WriteLine($"List ID: {listId}, Name: {listName}");
                        listFound = true;
                    }
                    break;
                }
            }

            if (!listFound)
            {
                Console.WriteLine($"List ID {listId} not found");
            }
        }

        public void RemoveAllLists(int userId)
        {
            if (_userLists.ContainsKey(userId))
            {
                _userLists[userId].Clear();
                Console.WriteLine($"Removed all lists for User ID {userId}");
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found");
            }
        }

        public void RemoveOneList(int listId, int userId)
        {
            if (_userLists.ContainsKey(userId))
            {
                List<string> userLists = _userLists[userId];
                if (listId >= 0 && listId < userLists.Count)
                {
                    string removedList = userLists[listId];
                    userLists.RemoveAt(listId);
                    Console.WriteLine($"Removed list '{removedList}' (ID: {listId}) for User ID {userId}");
                }
                else
                {
                    Console.WriteLine($"List ID {listId} does not exist for User ID {userId}");
                }
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found");
            }
        }

    }
}