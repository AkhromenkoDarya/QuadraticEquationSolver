using System;

namespace QuadraticEquationSolver.Infrastructure.Attributes
{
    /// <summary>
    /// Атрибут, выражающий зависимость одного свойства от другого.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class DependencyOnAttribute : Attribute
    {
        /// <summary>
        /// Имя свойства, от которого зависит текущее свойство.
        /// </summary>
        public string Name { get; set; }

        public DependencyOnAttribute()
        {
            
        }

        public DependencyOnAttribute(string name) => this.Name = name;
    }
}
