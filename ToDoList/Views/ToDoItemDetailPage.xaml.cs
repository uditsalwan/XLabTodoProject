using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItemDetailPage : ContentPage
    {
        public ToDoItemDetailPage()
        {
            InitializeComponent();
        }

        public ToDoItemDetailPage(TodoItem todoItem)
        {
            InitializeComponent();
            BindingContext = new ToDoItemDetailPageViewModel(todoItem);
            Title = todoItem.Title;
        }
    }
}
