using GreenITASPNetCore.Models;

namespace GreenITASPNetCore.Services
{
    public interface IFileService
    {
        public Task<TextFileDTO> CreateFileAsync(TextFileDTO dto);  
        public Task<TextFileDTO> GetFileAsync(long id);
        public Task<IEnumerable<TextFileDTO>> GetFilesAsync();
        public Task<TextFileDTO> UpdateFileAsync(TextFileDTO dto);
        public Task<Boolean> DeleteFileAsync(long id);
    }
}
