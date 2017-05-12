using System;
using System.IO;
using Xamarin.Forms;
using Todo.iOS;
using ToDoList;

[assembly: Dependency(typeof(FilePathHelper))]
namespace Todo.iOS
{
	public class FilePathHelper : IFilePathHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			var path = Path.Combine(libFolder, filename);

			Console.WriteLine(path);
			if (!File.Exists(path))
			{
				File.Create(path);
			}

			return path;
		}
	}
}