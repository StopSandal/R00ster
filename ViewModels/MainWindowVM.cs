using Microsoft.Extensions.Configuration;
using R00ster.Commands;
using R00ster.Services.Interfaces.MainWindowServices;
using R00ster.Services.Interfaces.Other;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace R00ster.ViewModels
{
    /// <summary>
    /// View model class for data context of main window
    /// </summary>
    public class MainWindowVM : INotifyPropertyChanged
    {
        private const string ExcelFileFilter = "Excel files (*.xlsx)|*.xlsx";
        private const string PathToUserEmail = "EmailSettings:UserEmail";

        public event PropertyChangedEventHandler PropertyChanged;


        private readonly IMainWindowService _mainWindowService;
        private readonly IUnitOfWork _unitOfWork;

        public string _totalRecordsLabelText = "0";
        public string TotalRecordsLabelText
        {
            get { return _totalRecordsLabelText; }
            set
            {
                if (_totalRecordsLabelText != value)
                {
                    _totalRecordsLabelText = value;
                    OnPropertyChanged(nameof(TotalRecordsLabelText));
                }
            }
        }

        //commands
        public ICommand ReadAndSaveExcelFileCommand { get; }
        public ICommand NotifyByEmailCommand { get; }


        public MainWindowVM(IMainWindowService mainWindowService, IUnitOfWork unitOfWork)
        {
            _mainWindowService = mainWindowService;
            _unitOfWork = unitOfWork;

            RefreshUIElementsAfterDbChanges();

            ReadAndSaveExcelFileCommand = new RelayCommand(async _ => await ReadAndSaveExcelFile());
            NotifyByEmailCommand = new RelayCommand(async _ => await NotifyUser());
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

            var result = openFileDialog.ShowDialog() == DialogResult.OK;
            if (result)
            {
                var filePath = openFileDialog.FileName;
                try
                {

                    var handledCount = await _mainWindowService.ReadExcelFileWithDbSaveAsync(filePath);

                    MessageBox.Show($"Total read : {handledCount}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred {ex.Message}", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    RefreshUIElementsAfterDbChanges();
                }
            }
        }

        private async Task NotifyUser()
        {
            try
            {
                var countResult = await _unitOfWork.JokesRepository.GetCountAsync();

                var userEmail = Program.Config.GetValue<string>(PathToUserEmail);

                await _mainWindowService.SendEmailMessage(
                    userEmail
                    , "Daily report"
                    , $"Total row on {DateTime.Now} is {countResult}");
                MessageBox.Show($"Message was successfully delivered to Email {userEmail}. Check spam folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error occurred {ex.Message}", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Refresh UI of app after database changes
        /// </summary>
        private async void RefreshUIElementsAfterDbChanges()
        {
            TotalRecordsLabelText = (await _unitOfWork.JokesRepository.GetCountAsync()).ToString();

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
