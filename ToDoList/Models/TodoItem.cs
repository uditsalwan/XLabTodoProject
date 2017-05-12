using System;
using SQLite;

namespace ToDoList
{
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string title { get; set; }
		public string details { get; set; }
		public DateTime dueDate { get; set; }
		public string locationCoordinates { get; set; }

		public TodoItem()
		{
			title = "";
			details = "";
			dueDate = System.DateTime.Today;
			locationCoordinates = "";
		}
	}
}
