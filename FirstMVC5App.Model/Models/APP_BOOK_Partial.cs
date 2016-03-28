using System;
using System.ComponentModel.DataAnnotations;

namespace FirstMVC5App.Model.Models
{
    [MetadataType(typeof(Book))]
    public partial class APP_BOOK
    {

    }

    public class Book //: IValidatableObject
    {
        //Метаданные и валидация модели
        //Аннотации данных для отображения свойств
        //http://metanit.com/sharp/mvc/7.1.php

        [ScaffoldColumn(false)]
        public decimal ID { get; set; }

        [Required (ErrorMessage = "Необходимо заполнить название книги")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки не должна привышать 100 символов")]
        [Display(Name = "Название книги")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить жанр книги")]
        [StringLength(25, ErrorMessage = "Длина строки не должна привышать 50 символов")]
        [Display(Name = "Жанр")]
        public string GANRE { get; set; }

        //[CurrencyValid(DataType.Currency, ErrorMessage = "Ошибка")]
        //[CurrencyValid(ErrorMessage = "Меньше 5")]
        //[DataType(DataType.Currency, ErrorMessage = "Ошибка в стоимости")]
        //todo: ДОБАВИТЬ СВОЮ ПРОВЕРКУ ДОСТОВЕРНОСТИ
        //http://professorweb.ru/my/ASP_NET/mvc/level7/7_5.php
        //[RegularExpression(@"^(\d+)$|^(\d+,?\d+)$")]
        [Required (ErrorMessage = "Необходимо заполнить поле")]
        [Display(Name = "Стоимость")]
        public decimal PRICE { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DATE_REG { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DATE_UPDATE { get; set; }
    }


    //public class CurrencyValidAttribute : RequiredAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        return value != null ? false : true ; //base.IsValid(value) && ((decimal)value) > 5;
    //    }
    //}
}
