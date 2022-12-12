using GreenITASPNetCore.Models;

namespace GreenITASPNetCore.Repositories
{
    public interface IFileRepository
    {
        public Task<TextFile> GetFileAsync(long id);
        public Task<IEnumerable<TextFile>> GetFilesAsync();
        public Task<TextFile> AddFileAsync(TextFile file);
        public Task<TextFile> UpdateFileAsync(TextFile file);
        public Task<Boolean> DeleteFileAsync(TextFile file);
    }
}
