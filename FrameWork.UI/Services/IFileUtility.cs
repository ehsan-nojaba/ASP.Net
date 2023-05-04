using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FrameWork.UI.Services
{
    public interface IFileUtility
    {
        bool IsValidFileName(string fileName);
        bool IsValidFileSize(IFormFile file , int minFileSize , int maxFileSize);
        string GenerateUniqueFileName(string fileName);
    }
}