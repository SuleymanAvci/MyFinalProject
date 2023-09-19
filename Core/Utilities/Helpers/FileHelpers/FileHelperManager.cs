using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelperManager : IFileHelper
    {
        public string Upload(IFormFile file, string root) // Verdiğin dosya istenilen yere yükleniyor.
        {
            if (file.Length > 0) // Dosya boyutu 0 dan büyük olmalı ki resim olsun
            {
                if (Directory.Exists(root)) // Yüklenecek yer var mı yoksa yarat
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); // Dosyanın uzantısını alıyor.
                string guid = Guid.NewGuid().ToString(); // Dosyanın ismini rastgele isim yapıyor.
                string fileName = guid + extension; // Resmin bütününü oluşturuyor.

                using (FileStream fileStream = File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return fileName;
                }          
            }
            return null;        
        }


        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) // Verilen Dosya yolu varsa siler.
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            Delete(filePath);           // Dosya yolunu siler yenisini yükler 
            return Upload(file, root);
        }


    }
}
