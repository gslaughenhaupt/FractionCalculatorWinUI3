using FractionCalculatorWinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FractionCalculatorWinUI3.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
