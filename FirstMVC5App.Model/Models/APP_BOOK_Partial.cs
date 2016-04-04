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

        [Required (ErrorMessage = "Необходимо заполнить поле")]
        [Display(Name = "Стоимость")]
        public Nullable<decimal> PRICE { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DATE_REG { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> DATE_UPDATE { get; set; }

        [Display(Name = "Название изображение")]
        public string IMG_NAME { get; set; }

        [Display(Name = "Изображение")]
        public string IMG_FILE_PATH { get; set; }
    }
}
