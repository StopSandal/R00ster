using GalaSoft.MvvmLight.Command;
using R00ster.Services.Interfaces.MainWindowServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace R00ster.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private const string ExcelFileFilter = "Excel files (*.xlsx)|*.xlsx";

        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IMainWindowService _mainWindowService;

        //commands
        public ICommand ReadAndSaveExcelFileCommand { get; }

        public MainWindowVM(IMainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;

            ReadAndSaveExcelFileCommand = new RelayCommand(async () => await ReadAndSaveExcelFile());
        }


        /// <summary>
        /// Asynchronously reads a Excel file and saves data into the database.
        /// </summary>
        private async Task ReadAndSaveExcelFile()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = ExcelFileFilter
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
