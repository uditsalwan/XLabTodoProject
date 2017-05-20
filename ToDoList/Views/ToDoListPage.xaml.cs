using Xamarin.Forms;
using System;


namespace ToDoList
{
    public partial class ToDoListPage : ContentPage
	{
		public ToDoListPage()
		{
			InitializeComponent();
            Title = AppResources.PageTitleToDo;
		}

        protected override void OnAppearing()
		{
			base.OnAppearing();

             ItemList.ItemsSource = App.DatabaseHandler.GetTodoItemList();
		}

        private async void TodoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as TodoItem;
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

            var accepted = await DisplayAlert(AppResources.Delete, AppResources.DeleteMessage + item.Title,
                                              AppResources.OK, AppResources.Cancel);

            if (accepted)
            {
                App.DatabaseHandler.DeleteItem(item);
                ItemList.ItemsSource = App.DatabaseHandler.GetTodoItemList();
            }
        }
    }
}
