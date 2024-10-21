using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services {
    public class FileService : IFileService {
        private readonly string _baseDirectory;

        public FileService() {
            _baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "arquivos");
            if (!Directory.Exists(_baseDirectory)) {
                Directory.CreateDirectory(_baseDirectory);
            }
        }
        public async Task SaveFileAsync(IFormFile file, string relativePath) {
            try {
                string fullPath = Path.Combine(_baseDirectory, relativePath);

                if (!Directory.Exists(fullPath)) {
                    Directory.CreateDirectory(fullPath);
                }

                string filePath = Path.Combine(fullPath, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex) {
                throw new Exception("Erro ao salvar o arquivo.", ex);
            }
        }

        public void DeleteFile(string relativePath, string fileName) {
            try {
                string filePath = Path.Combine(_baseDirectory, relativePath, fileName);

                if (File.Exists(filePath)) {
                    File.Delete(filePath);
                }
                else {
                    throw new FileNotFoundException("Arquivo não encontrado.");
                }
            }
            catch (Exception ex) {
                throw new Exception("Erro ao excluir o arquivo.", ex);
            }
        }

        public async Task<byte[]> GetFileAsync(string relativePath, string fileName) {
            try {
                string filePath = Path.Combine(_baseDirectory, relativePath, fileName);

                if (!File.Exists(filePath)) {
                    throw new FileNotFoundException("Arquivo não encontrado.");
                }
                return await File.ReadAllBytesAsync(filePath);
            }
            catch (Exception ex) {
                throw new Exception("Erro ao buscar o arquivo.", ex);
            }
        }
    }
}
