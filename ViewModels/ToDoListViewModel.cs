using TODO_MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TODO_MVC.Models;
using Dapper;


namespace TODO_MVC.ViewModels
{
    public class TODOListViewModel
    {
        public TODOListViewModel() 
        {
            using (var db = DbHelper.GetConnection())
            {
                this.EditableItem = new ToDoListItem();
                this.ToDoItem = db.Query<ToDoListItem>("Select * From ToDoListItems Order By AddDate Desc").ToList();
            }
        }

        public List<ToDoListItem> ToDoItem { get; set; }
        public ToDoListItem EditableItem { get; set; }  
    }
}
