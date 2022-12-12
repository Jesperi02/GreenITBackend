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
        public async Task<TextFile> AddFileAsync(TextFile file)
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

        public async Task<bool> DeleteFileAsync(TextFile file)
        {
            _fileContext.TextFiles.Remove(file);

            try
            {
                await _fileContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<TextFile> GetFileAsync(long id)
        {
            TextFile file = await _fileContext.TextFiles.Where(x =>
                x.Id == id
            ).FirstOrDefaultAsync();

            return file;
        }

        public async Task<IEnumerable<TextFile>> GetFilesAsync()
        {
            return await _fileContext.TextFiles.ToListAsync();
        }

        public async Task<TextFile> UpdateFileAsync(TextFile file)
        {
            _fileContext.Entry(file).State = EntityState.Modified;

            try
            {
                await _fileContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return file;
        }
    }
}
