﻿using R00ster.Commands;
using R00ster.Services.Interfaces.MainWindowServices;
using R00ster.Services.Interfaces.Other;
using R00ster.Services.Realization.Other;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace R00ster.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private const string ExcelFileFilter = "Excel files (*.xlsx)|*.xlsx";

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


        public MainWindowVM(IMainWindowService mainWindowService, IUnitOfWork unitOfWork)
        {
            _mainWindowService = mainWindowService;
            _unitOfWork = unitOfWork;

            RefreshUIElementsAfterDbChanges();

            ReadAndSaveExcelFileCommand = new RelayCommand(async _ => await ReadAndSaveExcelFile());
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
