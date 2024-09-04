using R00ster.Services.Interfaces.MainWindowServices;
using R00ster.ViewModels;
using System.Windows;
using System.Windows.Forms;

using MessageBox = System.Windows.Forms.MessageBox;

namespace R00ster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowVM mainWindowVM)
        {
            DataContext = mainWindowVM;

            InitializeComponent();

        }

    }
}