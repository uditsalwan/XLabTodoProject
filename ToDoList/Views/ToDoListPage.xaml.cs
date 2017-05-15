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
            Title = "ToDos";
		}

        protected async override void OnAppearing()
		{
			base.OnAppearing();

            ItemList.ItemsSource = await App.DatabaseHandler.GetTodoItemList();
		}

        private async void TodoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as TodoItem;
            //DisplayAlert("Selection Made", "You tapped on " + item.title, "Ok");
            await Navigation.PushModalAsync(new NavigationPage(new ToDoItemDetailPage(item)));
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ToDoDetailInputPage()));
        }

        //Delete on long tap in android and swipe in iOS
        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            TodoItem item = mi.CommandParameter as TodoItem;

            var accepted = await DisplayAlert("Delete?",
                                              "Are your sure you want to delete " + item.Title,
                                              "OK", "Canel");

            if (accepted)
            {
                await App.DatabaseHandler.DeleteItem(item);
                ItemList.ItemsSource = await App.DatabaseHandler.GetTodoItemList();
            }
        }
    }
}
