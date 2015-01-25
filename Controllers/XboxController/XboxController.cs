using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using XInputDotNetPure;
using System.Web.Script.Serialization;

namespace Server
{
    [Export(typeof(IController))]
    [ExportMetadata("Name", "Xbox360Controller")]
    public class XboxController :IController
    {
        GamePadState gamePadState;
        uint lastPacketNumber;
        public GamePadDeadZone DeadZone
        {
            get
            {
                return GamePadDeadZone.IndependentAxes;
            }
        }

        public bool Initialised
        {
            get
            {
                gamePadState = GamePad.GetState(PlayerIndex.One, DeadZone);
                if (gamePadState.PacketNumber != lastPacketNumber && gamePadState.IsConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Init()
        {
            return Initialised;
        }

        public string GetLiveInfo()
        {
            gamePadState = GamePad.GetState(PlayerIndex.One, DeadZone);
            return new JavaScriptSerializer().Serialize(gamePadState);
        }

        public void SendFeedback(string feedback)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
        }
    }
}
