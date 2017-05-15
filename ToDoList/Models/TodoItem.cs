using System;
using SQLite;

namespace ToDoList
{
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }
		public DateTime DueDate { get; set; }
		public string LocationCoordinates { get; set; }

        public string DueDateString {
            get{
                return DueDate.ToString("d");
            }
        }
	}
}
