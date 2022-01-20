using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GoldenToolKit.Interfaces
{
    public interface INavigationPage
    {
        void Navegar(IUserControlInterface usercontrol); //Push
        IUserControlInterface GoBack(); // -1
        IUserControlInterface GoFoward(); // +1
        void SendMessage(IUserControlInterface control, string json);
        void SendMessage<T>(string json) where T : IUserControlInterface;
        void Navegar<T>(object parameter=null) where T : IUserControlInterface;
        IUserControlInterface GetCurrentControl();
    }
}
