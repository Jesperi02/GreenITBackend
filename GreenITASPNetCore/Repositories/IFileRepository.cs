using GreenITASPNetCore.Models;

namespace GreenITASPNetCore.Repositories
{
    public interface IFileRepository
    {
        public Task<TextFile> GetFileASync(long id);
        public Task<IEnumerable<TextFile>> GetTextFilesAsync();
        public Task<TextFile> AddItemAsync(TextFile file);
        public Task<TextFile> UpdateItemAsync(TextFile file);
        public Task<Boolean> DeleteItemAsync(long id);
    }
}
