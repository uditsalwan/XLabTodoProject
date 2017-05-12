using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private DateTime dueDateTime = DateTime.Now;
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
                SavingResult = "Please enter the TODO title.";
            }
            else if (String.IsNullOrEmpty(description))
            {
                SavingResult = "Please enter the TODO description.";
            }
            else
            {
                ShowSuccessDialog(title, description, dueDateTime, currentLocation);
            }
        }

        private async void ShowSuccessDialog(string title, string description, DateTime dueDateTime, string currentLocation)
        {
            string savingResult = "Title : " + title + "\n" +
                                  "Description : " + description + "\n" +
                                  "Date : " + dueDateTime.ToString() + "\n" +
                                  "Location : " + currentLocation;
            var answer = await toDoDetailInputPage.DisplayAlert("Hurray!", savingResult, "OK", "Cancel");
            if (answer)
            {
                var todoItem = new TodoItem()
                {
                    title = title,
                    details = description,
                    dueDate = dueDateTime,
                    locationCoordinates = currentLocation
                };
                saveItem(todoItem);
            }
        }

        private async void saveItem(TodoItem todoItem)
        {
            await App.DatabaseHandler.SaveItem(todoItem);
            await toDoDetailInputPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}
