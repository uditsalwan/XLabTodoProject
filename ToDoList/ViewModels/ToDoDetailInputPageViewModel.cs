using System;
using Xamarin.Forms;

namespace ToDoList
{
    class ToDoDetailInputPageViewModel : BaseViewModel
    {
        #region fields
        private string savingResult;
        private string title;
        private string description;
        private string currentLocation;
        private DateTime dueDateTime = DateTime.Today;
        private ToDoDetailInputPage toDoDetailInputPage;
        #endregion

        #region constructor
        public ToDoDetailInputPageViewModel(ToDoDetailInputPage toDoDetailInputPage)
        {
            this.toDoDetailInputPage = toDoDetailInputPage;
            SaveCommand = new Command(SaveCommandAction);
        }
        #endregion

        #region properties
        public string SavingResult
        {
            get { return savingResult; }

            set { savingResult = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get { return title; }

            set { title = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        public string CurrentLocation
        {
            get { return currentLocation; }
            set
            {
                currentLocation = value;
                OnPropertyChanged();
            }
        }

        public DateTime DueDateTime
        {
            get { return dueDateTime; }
            set
            {
                dueDateTime = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand { get; }
        #endregion

        #region UI methods
        private void SaveCommandAction()
        {
            if (String.IsNullOrEmpty(title))
            {
                SavingResult = AppResources.TitleValidationMessage;
            }
            else if (String.IsNullOrEmpty(description))
            {
                SavingResult = AppResources.DescriptionValidationMessage;
            }
            else
            {
                ShowSuccessDialog(title, description, dueDateTime, currentLocation);
            }
        }

        private async void ShowSuccessDialog(string title, string description, DateTime dueDateTime, string currentLocation)
        {
            string savingResult = AppResources.Title + title + Constants.LineChange +
                                  AppResources.Description + description + Constants.LineChange +
                AppResources.Date + dueDateTime.Date.ToString("d") + Constants.LineChange +
                                  AppResources.Location + currentLocation;
            var answer = await toDoDetailInputPage.DisplayAlert(AppResources.ReviewDialogTitle, savingResult, AppResources.OK, AppResources.Cancel);
            if (answer)
            {
                var todoItem = new TodoItem()
                {
                    Title = title,
                    Details = description,
                    DueDate = dueDateTime.Date,
                    LocationCoordinates = currentLocation
                };
                SaveItem(todoItem);
            }
        }

        private async void SaveItem(TodoItem todoItem)
        {
            App.DatabaseHandler.SaveItem(todoItem);
            await toDoDetailInputPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}
