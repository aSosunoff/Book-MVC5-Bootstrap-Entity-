﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FirstMVC5App.Model.Infrastructure
{
    //public static class FileExtensions
    //{
    //    public const string PNG = ".png";
    //    public const string JPG = ".jpg";
    //    public const string JPEG = ".jpeg";

    
    //}:todo сделать проверку на расширение файла

    public static class FileOfWork
    {//:todo обязательно протестировать


        public static HttpPostedFileBase FileBase{ get; set; }
        //private static string[] _fileExtensionsString;
        
        //public static void SetExtension(params string[] extension)
        //{
        //    _fileExtensionsString = extension;
        //}

        public static string GetPath(string relativePath)
        {
            string fileName = "default.png";//Вставляем своё изображение если пользователь не выбрал изображение сам

            if (FileBase != null && FileBase.ContentLength > 0)
            {
                string absolutePathToFile = Path.Combine(HttpContext.Current.Server.MapPath(relativePath));

                if (!Directory.Exists(absolutePathToFile))
                    Directory.CreateDirectory(absolutePathToFile);

                fileName = Path.GetFileName(FileBase.FileName);

                if (File.Exists(Path.Combine(absolutePathToFile, fileName)))
                {
                    string fileNameWhithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    fileName = String.Format("{0}_{1}{2}",
                        fileNameWhithoutExtension,
                        Directory.GetFiles(absolutePathToFile, String.Concat(fileNameWhithoutExtension, "*")).Length + 1,
                        Path.GetExtension(fileName));
                }

                absolutePathToFile = Path.Combine(absolutePathToFile, fileName);

                FileBase.SaveAs(absolutePathToFile);
            }

            return Path.Combine(relativePath, fileName);//String.Concat("~/Content/tmp/", fileName);
        }
    }
}
