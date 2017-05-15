using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

namespace ToDoList
{
	public class DbHandler
	{
		SQLiteAsyncConnection database;

		public DbHandler(string path)
		{
			try
			{
                database = new SQLiteAsyncConnection(path, true);
				database.CreateTableAsync<TodoItem>();
			}
			catch (SQLiteException ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		public Task<List<TodoItem>> GetTodoItemList()
		{
			return database.Table<TodoItem>().ToListAsync();
		}

		public Task<List<TodoItem>> GetTodayTodoItemList()
		{
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [dueDate] >= ? AND [dueDate] < ?", 
                                                 DateTime.Today.Ticks, 
                                                 DateTime.Today.AddHours(24));
		}

		public Task<int> SaveItem(TodoItem item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItem(TodoItem item)
		{
			return database.DeleteAsync(item);
		}
	}
}
