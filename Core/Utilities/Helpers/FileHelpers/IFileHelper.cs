using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root); //Yükleme (Fotoğrafın nereye kaydedileceği ve dosya verilir.)
        void Delete(string filePath); // Dosya yolunu silme
        string Update(IFormFile file, string filePath, string root); // Dosyayı veriyorsun dosya yolu dosyanın kaydedileceği yerde güncelleniyor.
    }
}
