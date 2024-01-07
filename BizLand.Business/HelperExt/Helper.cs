using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.HelperExt
{
    public static class Helper
    {
        public static string SaveFile(string root, string directory, IFormFile file)
        {
            string fileName = file.FileName.Length > 100
                ? file.FileName.Substring(file.FileName.Length - 64, 64)
                : file.FileName;
            fileName = Guid.NewGuid().ToString() + fileName;

            string path = Path.Combine(root, directory, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}
