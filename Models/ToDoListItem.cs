using System;
using System.ComponentModel.DataAnnotations;

namespace TODO_MVC.Models
{
    public class ToDoListItem
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "Title must contain at least 2 characters")]
        [MaxLength(200, ErrorMessage = "Title muist contain a maximum of 200 characters")]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
