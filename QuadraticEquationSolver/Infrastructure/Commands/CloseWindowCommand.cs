using System.Windows;
using QuadraticEquationSolver.Infrastructure.Commands.Base;

namespace QuadraticEquationSolver.Infrastructure.Commands
{
    internal class CloseWindowCommand : Command
    {
        private static Window GetWindow(object parameter) => parameter as Window ?? 
                                                             App.FocusedWindow ?? App.ActiveWindow;

        protected override bool CanExecute(object parameter) => GetWindow(parameter) != null;

        protected override void Execute(object parameter) => GetWindow(parameter)?.Close();
    }
}
