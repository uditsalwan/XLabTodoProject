using System;
using System.IO;
using Xamarin.Forms;
using Todo.Droid;
using ToDoList;

[assembly: Dependency(typeof(FilePathHelper))]
namespace Todo.Droid
{
	public class FilePathHelper : IFilePathHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var fullPath = Path.Combine(path, filename);

			if (!File.Exists(fullPath)) File.Create(fullPath);

			return fullPath;
		}
	}
}
