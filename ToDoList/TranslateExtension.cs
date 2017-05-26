using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {

		public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
			if (Text == null)
				return null;

			return AppResources.ResourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
