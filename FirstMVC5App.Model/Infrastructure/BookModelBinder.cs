using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC5App.Model.Infrastructure
{
    public class BookModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            switch (propertyDescriptor.Name)
            {
                case "IMG_FILE_PATH":
                    //http://stackoverflow.com/questions/2083645/how-can-i-use-a-modelbinder-to-correct-values-that-will-then-be-visible-to-the-u
                    //Формируем путь до файла и сохраняем
                    //string fileValue = (string) bindingContext.ValueProvider.GetValue("IMG_FILE_PATH").ConvertTo(typeof (string));

                    HttpPostedFileBase file = (HttpPostedFileBase)bindingContext.ValueProvider.GetValue(propertyDescriptor.Name).ConvertTo(typeof(HttpPostedFileBase));
                    
                    string fileName = "default.png";//Вставляем своё изображение если пользователь не выбрал изображение сам

                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);

                        var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/tmp/"), fileName);

                        file.SaveAs(filePath);        
                    }

                    value = String.Concat("~/Content/tmp/", fileName);

                break;
                case "PRICE":
                    //http://aboutcode.net/2011/03/12/mvc-property-binder.html
                    //http://metanit.com/sharp/mvc5/9.5.php
                    //Использование данного метода происходит из за вывода сообщения об ошибки на английском языке
                    //http://professorweb.ru/my/ASP_NET/mvc/level7/7_5.php

                    //Проверяем цену на лишние символы
                    string priceValue = (string)bindingContext.ValueProvider.GetValue(propertyDescriptor.Name).ConvertTo(typeof(string));
                    decimal price;
                    //todo: Поменять на проверку без использования out параметра
                    if (!(decimal.TryParse(priceValue, out price)) //Прверяем ввели число или нет
                        &&
                        !(String.IsNullOrEmpty(priceValue))) //Исключаем пустую строку. Так как проверку на пустоту осуществляет DefaultModelBinder
                    {
                        bindingContext.ModelState.AddModelError(propertyDescriptor.Name, "Не допустимые символы");
                    }
                break;
            }
            
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
}
