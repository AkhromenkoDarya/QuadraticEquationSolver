using QuadraticEquationSolver.ViewModels.Base;

namespace QuadraticEquationSolver.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        private string _title = "Finding the roots of a quadratic equation";

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string Title
        {
            get => _title;

            set
            {
                if (Set(ref _title, value))
                {
                    OnPropertyChanged(nameof(TitleLength));
                }
            }
        }

        #endregion

        public int TitleLength => Title.Length;
    }
}
