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

                    FileOfWork.FileBase = (HttpPostedFileBase)bindingContext.ValueProvider.GetValue(propertyDescriptor.Name).ConvertTo(typeof(HttpPostedFileBase));

                    value = FileOfWork.GetPath(String.Format("\\tmp\\{0}\\", controllerContext.RouteData.Values["controller"]));

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
