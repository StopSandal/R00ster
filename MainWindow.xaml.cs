using R00ster.Services.Interfaces.MainWindowServices;
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
        private IMainWindowService _mainWindowService;
        public MainWindow(IMainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;

            InitializeComponent();

        }

        private async void ReadAndSaveExcelFile(object sender, EventArgs e)
        {
            //I know that broke Solid principle, that for test
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel files (*.xlsx)|*.xlsx"
            };

            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                try
                {

                    var handledCount = await _mainWindowService.ReadExcelFileWithDbSaveAsync(filePath);

                    MessageBox.Show($"Total readed : {handledCount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred {ex.Message}", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}