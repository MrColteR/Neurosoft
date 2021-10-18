using System.ComponentModel;

namespace Neurosoft.Views
{
    class MainWindowViewModel : INotifyPropertyChange
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number3"); // уведомление View о том, что изменилась сумма
            }
        }

        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set { _number1 = value; OnPropertyChanged("Number3"); }
        }
        public int Number3 { get; } => Math.GetSumOf(Number1, Number2);
    }
}
