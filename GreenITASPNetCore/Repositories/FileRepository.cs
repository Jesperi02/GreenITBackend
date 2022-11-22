using GreenITASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenITASPNetCore.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileContext _fileContext;

        public FileRepository(FileContext fileContext)
        {
            _fileContext = fileContext;
        }
        public async Task<TextFile> AddItemAsync(TextFile file)
        {
            _fileContext.TextFiles.Add(file);

            try
            {
                await _fileContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return file;
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<TextFile> GetFileASync(long id)
        {
            TextFile file = await _fileContext.TextFiles.Where(x =>
                x.Id == id
            ).FirstOrDefaultAsync();

            return file;
        }

        public async Task<IEnumerable<TextFile>> GetTextFilesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TextFile> UpdateItemAsync(TextFile file)
        {
            throw new NotImplementedException();
        }
    }
}
