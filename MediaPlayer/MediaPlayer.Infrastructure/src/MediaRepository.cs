using MediaPlayer.Domain.src.RepositoryInterface;
using static MediaPlayer.Domain.src.Core.MediaFile;

namespace MediaPlayer.Infrastructure.src.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private List<ConcreteMediaFile> _files;

        public MediaRepository()
        {
            _files = new List<ConcreteMediaFile>();
        }
        public void CreateNewFile(string fileName, string filePath, TimeSpan duration)
        {
            ConcreteMediaFile newFile = new ConcreteMediaFile(fileName, filePath, duration, 1);
            _files.Add(newFile);
            Console.WriteLine($"New file created. File ID: {newFile.FileId}, Name: {fileName}, Path: {filePath}, Duration: {duration}");
        }

        public void DeleteFileById(int fileId)
        {
            ConcreteMediaFile? fileToDelete = _files.FirstOrDefault(f => f.FileId == fileId);
            if (fileToDelete != null)
            {
                _files.Remove(fileToDelete);
                Console.WriteLine($"File with ID {fileId} deleted.");
            }
            else
            {
                Console.WriteLine($"File with ID {fileId} not found.");
            }
        }

        public void GetAllFiles()
        {
            Console.WriteLine("All Files:");
            foreach (ConcreteMediaFile file in _files)
            {
                Console.WriteLine($"File ID: {file.FileId}, Name: {file.FileName}, Path: {file.FilePath}, Duration: {file.Duration}");
            }        
        }

        public void GetFileById(int fileId)
        {
            ConcreteMediaFile? file = _files.FirstOrDefault(f => f.FileId == fileId);
            if (file != null)
            {
                Console.WriteLine($"File found. File ID: {file.FileId}, Name: {file.FileName}, Path: {file.FilePath}, Duration: {file.Duration}");
            }
            else
            {
                Console.WriteLine($"File with ID {fileId} not found.");
            }
        }

        public void Pause(int fileId)
        {
            ConcreteMediaFile? file = _files.FirstOrDefault(f => f.FileId == fileId);
            if (file != null)
            {
                file.Pause();
                Console.WriteLine($"Playback paused for File ID {fileId}: {file.FileName}");
            }
            else
            {
                Console.WriteLine($"File with ID {fileId} not found.");
            }
        }

        public void Play(int fileId)
        {
            ConcreteMediaFile? file = _files.FirstOrDefault(f => f.FileId == fileId);
            if (file != null)
            {
                file.Play();
                Console.WriteLine($"Playing File ID {fileId}: {file.FileName}");
            }
            else
            {
                Console.WriteLine($"File with ID {fileId} not found.");
            }
        }

        public void Stop(int fileId)
        {
            ConcreteMediaFile? file = _files.FirstOrDefault(f => f.FileId == fileId);
            if (file != null)
            {
                file.Stop();
                Console.WriteLine($"Playback stopped for File ID {fileId}: {file.FileName}");
            }
            else
            {
                Console.WriteLine($"File with ID {fileId} not found.");
            }
        }
    }
}