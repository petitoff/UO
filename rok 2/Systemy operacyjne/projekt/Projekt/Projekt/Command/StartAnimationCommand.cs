using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Projekt.ViewModel;

namespace Projekt.Command
{
    public class StartAnimationCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public StartAnimationCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.CreateCar();
        }

        public event EventHandler CanExecuteChanged;
    }
}
