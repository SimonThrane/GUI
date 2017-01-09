using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using GUIEksamen.Model;
using MvvmFoundation.Wpf;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace GUIEksamen.ViewModel
{
    //Læringsmål: Anvende data binding til at sammenknytte data i modellaget med deres præsentation i viewlaget.
    public class ViewModelClass : ObservableCollection<ImageClass>, INotifyPropertyChanged
    {
        string filePath = "";
        string filename = "";
        bool dirty = false;
        
        public ViewModelClass()
        {
            //Mulighed for data
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                

            }
        }

        #region Commands implementation

        ICommand _colorCommand;
        public ICommand ColorCommand
        {
            get { return _colorCommand ?? (_colorCommand = new RelayCommand<String>(ColorCommand_Execute)); }
        }

        private void ColorCommand_Execute(String colorStr)
        {
            SolidColorBrush newBrush = SystemColors.WindowBrush; // Default color

            try
            {
                if (colorStr != null)
                {
                    if (colorStr != "Default")
                    {
                        newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorStr));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown color name, default color is used", "Program error!");
            }

            Application.Current.MainWindow.Resources["BackgroundBrush"] = newBrush;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(
                    () => ++CurrentIndex,
                    () => CurrentIndex < (Count - 1)));
            }
        }

        ICommand _previusCommand;
        public ICommand PreviusCommand
        {
            get { return _previusCommand ?? (_previusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        }

        private void PreviusCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }
        
        ICommand _aboutCommand;
        public ICommand AboutCommand
        {
            get { return _aboutCommand ?? (_aboutCommand = new RelayCommand(AboutCommand_Execute)); }
        }

        private void AboutCommand_Execute()
        {
            //Anvende kontroller til opbygning af både modale og modeless dialoger, samt kunne anvende de forskellige layout panels.
            var window = new AboutWindow();
            if (window.ShowDialog() == true)
            {
                
            }
        }

        ICommand _openCommand;
        public ICommand OpenCommand => _openCommand ?? (_openCommand = new RelayCommand(OpenCommand_Execute));
        private void OpenCommand_Execute()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select image";
            fileDialog.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = true;
            fileDialog.RestoreDirectory = true;
            //Programmet husker seneste valgte mappe
            if (filePath == "")
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                fileDialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (fileDialog.ShowDialog(App.Current.MainWindow) == true)
            {
                foreach (var item in fileDialog.FileNames.ToList())
                {
                    AddPicture(Path.GetFileName(item),Path.GetDirectoryName(item));
                }

                filePath= Path.GetDirectoryName(fileDialog.FileName);
            }

        }

        ICommand _saveAsCommand;
        public ICommand SaveAsCommand => _saveAsCommand ?? (_saveAsCommand = new RelayCommand<string>(SaveAsCommand_Execute, SavePicture_CanExecute));

        private bool SavePicture_CanExecute(string obj)
        {
            if (Count > 0 && dirty!=false)
                return true;
            else
                return false;
        }

        private async void SaveAsCommand_Execute(string nameOfFile)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
           
            filePath = Path.GetDirectoryName(dialog.SelectedPath);

            //Brug af async/await
            await Task.Run(() => SaveFile(nameOfFile));
           
        }

        private void SaveFile(string fileName)
        {
            var i = 1;
            foreach (var image in this)
            {
                string nameToLoadFrom = image.ImagePath +"\\"+ image.FileName;
                string nameToSaveTo = filePath + "\\" + fileName + " - " + i + Path.GetExtension(image.FileName);
                File.Copy(nameToLoadFrom, nameToSaveTo);
                i++;
            }
            dirty = false;
            Application.Current.Dispatcher.BeginInvoke(new Action(Clear));
            MessageBoxResult res = MessageBox.Show("Tillykke billederne er gemt i " + filePath  +" med navne "+fileName);
            NotifyPropertyChanged("Count");
        }

        private void AddPicture(string FileName, string path)
        {
            Add(new ImageClass(FileName,path));
            NotifyPropertyChanged("Count");
            dirty = true;
        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeletePicture, DeletePicture_CanExecute)); }
        }

        private void DeletePicture()
        {
            MessageBoxResult res = MessageBox.Show("Are you sure you want to delete picture " + _currentDataClass.FileName +
                "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Remove(_currentDataClass);
                NotifyPropertyChanged("Count");
                dirty = true;
            }
        }

        private bool DeletePicture_CanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }



        ICommand _closeAppCommand;
        public ICommand CloseAppCommand => _closeAppCommand ?? (_closeAppCommand = new RelayCommand(CloseCommand_Execute));

        private void CloseCommand_Execute()
        {
            bool regret = false;

            if (dirty)
            {
                MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to close the application without saving data first?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (res == MessageBoxResult.No)
                {
                    regret = true;
                }
            }
            if (!regret)
                Application.Current.MainWindow.Close();
        }

        int _currentIndex = -1;

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                if (_currentIndex != value)
                {
                    _currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        ImageClass _currentDataClass = null;

        public ImageClass CurrentDataClass
        {
            get { return _currentDataClass; }
            set
            {
                if (_currentDataClass != value)
                {
                    _currentDataClass = value;
                    NotifyPropertyChanged();
                    
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
