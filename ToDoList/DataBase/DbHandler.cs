using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace ToDoList
{
    public class DbHandler
	{
		private static DbHandler dbInstance;

        SQLiteConnection database;

        private DbHandler()
		{
			try
			{
                var path = DependencyService.Get<IFilePathHelper>().GetLocalFilePath(Constants.DB_NAME);
                database = new SQLiteConnection(path, true);
                database.CreateTable<TodoItem>();
			}
			catch (SQLiteException ex)
			{
				Debug.WriteLine("DbHandler" + ex.Message);
			}
		}

        public static DbHandler Instance()
        {
			if (dbInstance == null)
			{
				dbInstance = new DbHandler();
			}
			return dbInstance;
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
