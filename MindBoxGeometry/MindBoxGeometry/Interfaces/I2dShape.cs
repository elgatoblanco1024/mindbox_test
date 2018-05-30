using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxGeometry
{
    /// <summary>
    /// Интерфейс определяет двумерную фигуру на плоскости
    /// </summary>
    public interface I2dShape
    {
        /// <summary>
        /// Вычисляет площадь фигуры. Для фигур, не имеющих площади, должен возвращать 0.
        /// </summary>
        /// <returns></returns>
        double GetSquare();
    }
}
