using System.Windows;

namespace MainMenuSample;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        MainWindowViewModel model = new();
        DataContext = model;
        InitializeComponent();
    }
}
