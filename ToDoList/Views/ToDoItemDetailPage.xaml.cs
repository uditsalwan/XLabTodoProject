
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
