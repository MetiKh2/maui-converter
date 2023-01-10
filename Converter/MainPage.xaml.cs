using Converter.MVVM.ViewModels;
using Converter.MVVM.Views;

namespace Converter;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var stack = (VerticalStackLayout)sender;

        var option = ((Label)stack.Children.LastOrDefault()).Text;

        var converterView = new ConverterView()
        {
            BindingContext = new ConverterViewModel(option)
        };

        Navigation.PushAsync(converterView);
    }
}

