using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class ToDoItemDetailPageViewModel
    {

        #region constructor
        public ToDoItemDetailPageViewModel(TodoItem todoItem)
        {
            ID = todoItem.ID;
            Title = todoItem.title;
            Details = todoItem.details;
            DueDate = todoItem.dueDate.ToString();
            LocationCoordinates = todoItem.locationCoordinates;
        }
        #endregion

        #region properties
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string DueDate { get; set; }
        public string LocationCoordinates { get; set; }
        #endregion
    }
}
