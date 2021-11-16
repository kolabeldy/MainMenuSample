using MyServicesLibrary.SideMenu;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

namespace MainMenuSample;
public class MainWindowViewModel : BaseViewModel
{
    public SideMenu? SideMenu { get; set; }


    private UserControl _ContentPanel = new();
    public UserControl ContentPanel
    {
        get => _ContentPanel;
        set
        {
            Set(ref _ContentPanel, value);
        }
    }

    public MainWindowViewModel()
    {
        SideMenu = new SideMenu(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.db"));
        SideMenu.OnMenuChoise += MainMenuChoiseCommand;
    }

    private void MainMenuChoiseCommand(string methodName)
    {
        if (methodName != null)
        {
            MethodInfo? method = typeof(MainWindowViewModel).GetMethod(methodName);
            if (method != null) method.Invoke(this, null);
        }

    }
    //public void AnalysisForCCShow() => mw.MainMenuPanel.Content = AnalysisForCC.GetInstance();
    public void AnalysisForCCShow() => ContentPanel = new AnalysisForCC();
    public void AboutShow() => new About().ShowDialog();
    //public void SettingsShow() => new Setting().ShowDialog();

}
