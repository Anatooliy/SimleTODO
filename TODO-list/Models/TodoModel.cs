using System;
using System.ComponentModel.DataAnnotations;

namespace TODO_list.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [Required]
        public string ToDoDescription { get; set; }
    }
}