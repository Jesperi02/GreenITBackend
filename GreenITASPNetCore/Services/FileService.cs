using GreenITASPNetCore.Models;
using GreenITASPNetCore.Repositories;

namespace GreenITASPNetCore.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Task<TextFileDTO> CreateFileAsync(TextFileDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFileAsync(TextFileDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TextFileDTO> GetFileAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TextFileDTO>> GetFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TextFileDTO> UpdateFileAsync(TextFileDTO dto)
        {
            throw new NotImplementedException();
        }

        private TextFileDTO FileToDTO(TextFile file)
        {
            TextFileDTO dto = new TextFileDTO();
            dto.Id = file.Id;
            dto.Name = file.Name;
            dto.Filename = file.Filename;

            return dto;
        }

        private async Task<TextFile> DTOToFile(TextFileDTO dto)
        {
            TextFile file = new TextFile();
            file.Id = dto.Id;
            file.Name = dto.Name;
            file.Filename = dto.Filename;

            // hae tiedosto
            if (file.Filename != String.Empty)
            {
                file.File = null;
            }

            return file;
        }
    }
}
