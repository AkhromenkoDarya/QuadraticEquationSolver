using QuadraticEquationSolver.Models;
using QuadraticEquationSolver.ViewModels.Base;

namespace QuadraticEquationSolver.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly QuadraticEquation _quadraticEquation = new();

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
                if (Set(ref _title, value, title => !string.IsNullOrWhiteSpace(title)))
                {
                    OnPropertyChanged(nameof(TitleLength));
                }
            }
        }

        #endregion

        public int TitleLength => Title.Length;

        public string UserName
        {
            get => Get<string>();
            set => Set(value);
        }

        private double _a;

        public double A 
        { 
            get => _a;

            set
            {
                if (!Set(ref _a, value, "The value must be greater than or equal to zero", 
                        a => a >= 0))
                {
                    return;
                }

                _quadraticEquation.A = value;
                OnPropertyChanged(nameof(FirstRoot));
                OnPropertyChanged(nameof(SecondRoot));
            }
        }

        public double B
        {
            get => _quadraticEquation.B;

            set
            {
                if (Equals(_quadraticEquation.B, value))
                {
                    return;
                }

                _quadraticEquation.B = value;
                OnPropertyChanged(nameof(FirstRoot));
                OnPropertyChanged(nameof(SecondRoot));
            }
        }

        public double C
        {
            get => _quadraticEquation.C;

            set
            {
                if (!Set(value, _quadraticEquation.C, v => _quadraticEquation.C = v))
                {
                    return;
                }

                OnPropertyChanged(nameof(FirstRoot));
                OnPropertyChanged(nameof(SecondRoot));
            }
        }

        public double FirstRoot => _quadraticEquation.FirstRoot;

        public double SecondRoot => _quadraticEquation.SecondRoot;
    }
}
