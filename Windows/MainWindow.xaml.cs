using R00ster.ViewModels;
using System.Windows;

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