using System.Runtime.CompilerServices;

namespace QuadraticEquationSolver.ViewModels.Base
{
    internal partial class ViewModel
    {
        protected SetValueResult<T> SetValue<T>(ref T field, T value, 
            [CallerMemberName] string propertyName = null!)
        {
            if (Equals(field, value))
            {
                return new SetValueResult<T>(false, field, value, this);
            }

            T oldValue = field;
            field = value;
            OnPropertyChanged(propertyName!);

            return new SetValueResult<T>(true, oldValue, value, this);
        }
    }

    internal class SetValueResult<T>
    {
        private readonly bool _result;

        private readonly T _oldValue;

        private readonly T _newValue;

        private readonly ViewModel _viewModel;

        public SetValueResult(bool result, in T oldValue, in T newValue, ViewModel viewModel)
        {
            _result = result;
            _oldValue = oldValue;
            _newValue = newValue;
            _viewModel = viewModel;
        }
    }
}
