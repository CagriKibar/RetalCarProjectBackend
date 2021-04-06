using Core.Utilities.Results;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
       
            public static string Add(IFormFile file)
            {
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            var path1 = newPath(file);
            var result = path + path1;
            File.Move(sourcepath, result);
            return "/Images/" + path1;
        }

            public static void Delete(string path)
            {
            string path2 = Environment.CurrentDirectory + @"\wwwroot";

            File.Delete(path2 + path);
            //try
            //    {
            //        File.Delete(path);
            //    }
            //    catch (Exception e)
            //    {
            //        return new ErrorResult(e.Message);
            //    }
            //    return new SuccessResult();
        }


        public static string Update(string sourcePath, IFormFile file)
            {
                var result = Add(file);
                if (sourcePath.Length > 0)
                {
                //using (var stream = new FileStream(result, FileMode.Create))
                //{
                //    file.CopyToAsync(stream);
                //}
                Delete(sourcePath);
                }
                //File.Delete(sourcePath);
                return result;
            }

            public static string newPath(IFormFile file)
            {
                FileInfo fileInfo = new FileInfo(file.FileName);
                string extension = fileInfo.Extension;
               
                //string path = Environment.CurrentDirectory + @"\wwwroot\Images";
                var newPath = Guid.NewGuid().ToString() + "--" + DateTime.Now.Day + "--" + DateTime.Now.Month + "--" + DateTime.Now.Year + extension;

                //string result = $@"{path}\{newPath}";
                return newPath;
            }

        }
   }
