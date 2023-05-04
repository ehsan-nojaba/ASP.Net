using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.UI.Services;
using Microsoft.AspNetCore.Http;

namespace FrameWork.UI
{
    public class FileUtility:IFileUtility
    {
        public bool IsValidFileName(string fileName)
        {
            fileName = fileName.ToLower();
            if (fileName.Contains(".php") || fileName.Contains(".asp") || fileName.Contains(".jsp"))
            {
                return false;
            }
            return true;
        }

        public bool IsValidFileSize(IFormFile file, int minFileSize, int maxFileSize)
        {
            if (file.Length < minFileSize || file.Length > maxFileSize)
            {
                return false;
            }
            return true;
        }

        public string GenerateUniqueFileName(string fileName)
        {
            fileName = fileName.ToLower();
            fileName = "/ProductImages/" + Guid.NewGuid().ToString().Replace("-", "_") + fileName;
            return fileName;
        }
    }
}