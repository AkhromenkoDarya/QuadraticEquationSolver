#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base
{
    internal abstract partial class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, 
            [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual bool Set<T>(ref T field, T value, Func<T, bool> validator,
            [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value) || !validator(value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual bool Set<T>(ref T field, T value, string? validationErrorMessage, 
            Func<T, bool> validator, [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
            {
                return false;
            }

            if (!validator(value))
            {
                throw new ArgumentException(
                    validationErrorMessage ?? $"{propertyName} property data validation error", 
                    nameof(value));
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual bool Set<T>(T value, T oldValue, Action<T> setter, 
            [CallerMemberName] string propertyName = null!)
        {
            if (Equals(oldValue, value))
            {
                return false;
            }

            setter(value);
            OnPropertyChanged(propertyName);

            return true;
        }

        private readonly Dictionary<string, object?> _values = new();

        protected T? Get<T>([CallerMemberName] string propertyName = null!) => _values
            .TryGetValue(propertyName, out object? value) ? (T?)value : default;

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null!)
        {
            if (_values.TryGetValue(propertyName, out object? oldValue) && Equals(oldValue, value))
            {
                return false;
            }

            _values[propertyName] = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
