using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using System.Linq;

namespace ToDoList
{
    public class DbHandler
	{
        SQLiteConnection database;

		public DbHandler(string path)
		{
			try
			{
                database = new SQLiteConnection(path, true);
                database.CreateTable<TodoItem>();
			}
			catch (SQLiteException ex)
			{
				Debug.WriteLine("DbHandler" + ex.Message);
			}
		}

		public List<TodoItem> GetTodoItemList()
		{
            List<TodoItem> list;
            try
            {
                list = database.Table<TodoItem>().ToList();
                return list;
            } catch (Exception e)
            {
                Debug.WriteLine("GetTodoItemList" + e.Message);
                return null;
            }
		}

		public List<TodoItem> GetTodayTodoItemList()
		{
            return database.Query<TodoItem>("SELECT * FROM [TodoItem] WHERE [dueDate] >= ? AND [dueDate] < ?", 
                                                 DateTime.Today.Ticks, 
                                                 DateTime.Today.AddHours(24));
		}

        public int SaveItem(TodoItem item)
		{
			if (item.ID != 0)
			{
                return database.Update(item);
			}
			else
			{
                return database.Insert(item);
			}
		}

        public int DeleteItem(TodoItem item)
		{
            return database.Delete(item);
		}
	}
}
