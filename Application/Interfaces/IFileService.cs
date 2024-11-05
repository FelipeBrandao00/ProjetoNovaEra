using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IFileService {
        Task SaveFileAsync(IFormFile file, string relativePath);
        void DeleteFile(string relativePath, string fileName);
        Task<byte[]> GetFileAsync(string relativePath, string fileName);
        public int GetFileCountInDirectory(string relativePath);
    }
}
