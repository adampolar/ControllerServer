using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IController
    {
        bool Initialised { get; }
        bool Init();
        string GetLiveInfo();
        void SendFeedback(string feedback);
        void Close();
    }
    public interface IControllerData
    {
        string Name { get; }
    }
}
