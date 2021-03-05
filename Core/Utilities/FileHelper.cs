using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities
{
  public  class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch(Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();

        }
        public static string Update(string sourcePaht, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePaht.Length>0)
            {
                using(var stream=new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePaht);
        }
    }

}
