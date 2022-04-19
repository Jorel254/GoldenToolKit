using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GoldenToolKit.Interfaces
{
public interface IUserControlInterface
    {
        /// <summary>
        /// Indica que este control ha salido del primer plano de navegación
        /// </summary>
        void OnHidden();
        /// <summary>
        /// Indica que este control ha tomado el primer plano de navegacion
        /// </summary>
        void OnShown();
        /// <summary>
        /// Indica que este control ha recibido un mensaje
        /// </summary>
        /// <param name="json"></param>
        void OnMessageReceived(string json);
        /// <summary>
        /// Indica que este control ha recibido un mensaje
        /// </summary>
        /// <param name="json"></param>
        void OnMessageReceived(object obj);
    }
}
