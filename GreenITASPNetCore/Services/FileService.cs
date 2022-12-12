using GreenITASPNetCore.Models;
using GreenITASPNetCore.Repositories;
using System.Globalization;

namespace GreenITASPNetCore.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<TextFileDTO> CreateFileAsync(TextFileDTO dto)
        {
            TextFile textFile = await DTOToFile(dto);
            TextFile updatedFile = await _fileRepository.AddFileAsync(textFile);

            if (updatedFile == null)
            {
                return null;
            }

            return FileToDTO(updatedFile);
        }

        public async Task<bool> DeleteFileAsync(long id)
        {
            TextFile file = await _fileRepository.GetFileAsync(id);

            if (file == null)
            {
                return false;
            }

            return await _fileRepository.DeleteFileAsync(file);
        }

        public async Task<TextFileDTO> GetFileAsync(long id)
        {
            TextFile file = await _fileRepository.GetFileAsync(id);

            if (file == null)
            {
                return null;
            }

            return FileToDTO(file);
        }

        public async Task<IEnumerable<TextFileDTO>> GetFilesAsync()
        {
            IEnumerable<TextFile> fileList = await _fileRepository.GetFilesAsync();
            List<TextFileDTO> fileDTOList = new List<TextFileDTO>();

            foreach (TextFile file in fileList)
            {
                fileDTOList.Add(FileToDTO(file));
            }

            return fileDTOList;
        }

        public async Task<TextFileDTO> UpdateFileAsync(TextFileDTO dto)
        {
            TextFile file = await _fileRepository.GetFileAsync(dto.Id);

            if (file == null)
            {
                return null;
            }

            file.Name = dto.Name;
            file.Filename = dto.Filename;


            TextFile updatedFile = await _fileRepository.UpdateFileAsync(file);

            if (updatedFile == null)
            {
                return null;
            }

            return FileToDTO(updatedFile);
        }

        private TextFileDTO FileToDTO(TextFile file)
        {
            TextFileDTO dto = new TextFileDTO();
            dto.Id = file.Id;
            dto.Name = file.Name;
            dto.Filename = file.Filename;

            // add file data here

            return dto;
        }

        private async Task<TextFile> DTOToFile(TextFileDTO dto)
        {
            TextFile file = new TextFile();
            file.Id = dto.Id;
            file.Name = dto.Name;
            file.Filename = dto.Filename;

            return file;
        }
    }
}
