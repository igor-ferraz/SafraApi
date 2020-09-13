using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Safra.Domain.InfrastructureServices;

namespace Safra.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public bool IsImage(IFormFile file)
        {
            const int ImageMinimumBytes = 512;
            var contentTypes = new string[] { "image/jpg", "image/jpeg", "image/pjpeg", "image/gif", "image/x-png", "image/png" };
            var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            if (!contentTypes.Any(f => f == file.ContentType.ToLower()) || !extensions.Any(e => e == Path.GetExtension(file.FileName)))
                return false;

            try
            {
                if (!file.OpenReadStream().CanRead || file.Length < ImageMinimumBytes)
                    return false;

                var buffer = new byte[ImageMinimumBytes];

                file.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                var content = System.Text.Encoding.UTF8.GetString(buffer);

                const string imageRegex = @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy";

                if (Regex.IsMatch(content, imageRegex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                    return false;
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Save(IFormFile file, string baseName, string path)
        {
            System.Diagnostics.Debug.Print("Entrei no FileService | método Save()");

            if (!Directory.Exists(path))
            {
                System.Diagnostics.Debug.Print("FileService: diretório não existe: " + path);
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, baseName + Path.GetExtension(file.FileName));

            System.Diagnostics.Debug.Print("FileService: filepath: " + filePath);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return File.Exists(filePath);
        }
    }
}
