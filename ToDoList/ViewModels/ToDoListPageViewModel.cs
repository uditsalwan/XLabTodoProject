using System.Collections.Generic;

namespace ToDoList
{
    class ToDoListPageViewModel : BaseViewModel
    {
        private List<TodoItem> itemList;

        public List<TodoItem> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
                OnPropertyChanged();
            }
        }
    }
}
