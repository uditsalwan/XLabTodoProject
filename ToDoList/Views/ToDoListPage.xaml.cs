using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System;


namespace ToDoList
{
	public partial class ToDoListPage : ContentPage
	{
		public ToDoListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			ItemList.ItemsSource = await App.DatabaseHandler.GetTodoItemList();
		}

		private void TodoList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var item = e.Item as TodoItem;
			DisplayAlert("Selection Made", "You tapped on " + item.title, "Ok");
		}


		async void OnAddItem(object sender, EventArgs e)
		{
			//TodoItem item1 = new TodoItem()
			//{
			//	title = "sample1",
			//	details = "details details",
			//	locationCoordinates = "100, 200"
			//};

			//await App.DatabaseHandler.SaveItem(item1);

			for (int i = 0; i < 5; i++)
			{
				TodoItem item = new TodoItem()
				{
					title = "sample" + i,
					details = "details details",
					locationCoordinates = "100, 200",
					dueDate = System.DateTime.Today
				};

				await App.DatabaseHandler.SaveItem(item);
			}

			ItemList.ItemsSource = await App.DatabaseHandler.GetTodoItemList();
		}
	}
}
