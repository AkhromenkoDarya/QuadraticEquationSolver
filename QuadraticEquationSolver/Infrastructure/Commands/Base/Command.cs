﻿using System;
using System.Windows.Input;

namespace QuadraticEquationSolver.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        private bool _executable = true;

        public bool Executable
        {
            get => _executable;

            set
            {
                if (_executable == value)
                {
                    return;
                }

                _executable = value;
                ExecutableChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler ExecutableChanged;

        event EventHandler ICommand.CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => Executable && CanExecute(parameter);

        void ICommand.Execute(object parameter)
        {
            if (!((ICommand)this).CanExecute(parameter))
            {
                return;
            }

            Execute(parameter);
        }

        protected virtual bool CanExecute(object parameter) => true;

        protected abstract void Execute(object parameter);
    }
}
