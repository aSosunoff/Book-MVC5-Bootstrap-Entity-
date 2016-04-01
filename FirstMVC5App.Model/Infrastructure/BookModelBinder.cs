using System;
using System.Web.Mvc;


namespace FirstMVC5App.Model.Infrastructure
{
    public class BookModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //http://aboutcode.net/2011/03/12/mvc-property-binder.html
            //http://metanit.com/sharp/mvc5/9.5.php
            //Использование данного метода происходит из за вывода сообщения об ошибки на английском языке
            //http://professorweb.ru/my/ASP_NET/mvc/level7/7_5.php

            //Проверяем цену на лишние символы
                string priceValue = (string)bindingContext.ValueProvider.GetValue("PRICE").ConvertTo(typeof(string));
                decimal price;
                //todo: Поменять на проверку без использования out параметра
                if (!(decimal.TryParse(priceValue, out price)) //Прверяем ввели число или нет
                    &&
                    !(String.IsNullOrEmpty(priceValue))) //Исключаем пустую строку. Так как проверку на пустоту осуществляет DefaultModelBinder
                {
                    bindingContext.ModelState.AddModelError("PRICE", "Не допустимые символы");
                    return base.BindModel(controllerContext, bindingContext);
                }
            return base.BindModel(controllerContext,  bindingContext);
            
        }
    }
}
