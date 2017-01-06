using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MvvmFoundation.Wpf;

namespace GUIEksamen
{
    //Læringsmål: Anvende data binding til at sammenknytte data i modellaget med deres præsentation i viewlaget.
    class ViewModelClass : ObservableCollection<DataClass>, INotifyPropertyChanged
    {
        string filename = "";
        string filePath = "";
        string filter;
        bool dirty = false;
        
        public ViewModelClass()
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                // In Design mode
                //Add(new Agent("001", "Nina", "Assassination", "UpperVolta"));
                //Add(new Agent("007", "James Bond", "Martinis", "North Korea"));               
            }
        }


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

        //Skal ændres
        ViewModelClass _currentJoke = null;

        public ViewModelClass CurrentJoke
        {
            get { return _currentJoke; }
            set
            {
                if (_currentJoke != value)
                {
                    _currentJoke = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
