using System.Linq;
using System.Windows;

namespace QuadraticEquationSolver
{
    public partial class App
    {
        public static Window ActiveWindow => Current.Windows.Cast<Window>()
            .FirstOrDefault(w => w.IsActive);

        public static Window FocusedWindow => Current.Windows.Cast<Window>()
            .FirstOrDefault(w => w.IsFocused);
    }
}
