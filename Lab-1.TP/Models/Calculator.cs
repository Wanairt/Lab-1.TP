using System;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.TP.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "Поле 'Операнд 1' обязательно для заполнения!")]
        public string? Operand1Input { get; set; }

        [Compare("Operand1Input", ErrorMessage = "Значение операнда 2 должно совпадать со значением операнда 1!")]
        public string? Operand2Input { get; set; }

        public string? Operation { get; set; }
        public double Result { get; set; }
        public byte Operand1 { get; set; }
        public double Operand2 { get; set; }
    }
}
