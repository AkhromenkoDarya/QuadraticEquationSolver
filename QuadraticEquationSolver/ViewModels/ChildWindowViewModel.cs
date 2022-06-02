using QuadraticEquationSolver.ViewModels.Base;

namespace QuadraticEquationSolver.ViewModels
{
    internal class ChildWindowViewModel : ViewModel
    {
        private readonly MainWindowViewModel _baseViewModel;

        #region StringValue : string - Некоторое строковое значение

        /// <summary>
        /// Некоторое строковое значение.
        /// </summary>
        private string _stringValue;

        /// <summary>
        /// Некоторое строковое значение.
        /// </summary>
        public string StringValue
        {
            get => _stringValue;

            set => SetValue(ref _stringValue, value)
                .UpdateProperty(nameof(StringValueLength))
                .Then(v => _baseViewModel.StringValue = value);
        }

        #endregion

        public int StringValueLength => StringValue?.Length ?? -1;

        public string BaseViewModelValue
        {
            get;
            set;
        }

        public void UpdateBaseViewModelValue(string value)
        {
            if (Equals(BaseViewModelValue, value))
            {
                return;
            }

            BaseViewModelValue = value;
            OnPropertyChanged(nameof(BaseViewModelValue));
        }

        public ChildWindowViewModel()
        {
            
        }

        public ChildWindowViewModel(MainWindowViewModel baseViewModel)
        {
            _baseViewModel = baseViewModel;
        }
    }
}
