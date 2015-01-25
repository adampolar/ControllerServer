using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel.Composition;
using System.Threading;

namespace Server
{
    [Export(typeof(IController))]
    [ExportMetadata("Name", "OculusRiftDK2")]
    unsafe public class OculusRift : IController
    {
        [DllImport(@"RiftWrapper\RiftWrapper.dll")]
        static extern int OVR_Init();

        [DllImport(@"RiftWrapper\RiftWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int OVR_Peek(float* w, float* x, float* y, float* z, float* px, float* py, float* pz);

        [DllImport(@"RiftWrapper\RiftWrapper.dll")]
        static extern void OVR_Exit();

        [DllImport(@"RiftWrapper\RiftWrapper.dll")]
        static extern void OVR_Recenter();

        [DllImport(@"RiftWrapper\RiftWrapper.dll")]
        static extern int OVR_Detect();

        public bool Initialised
        {
            get
            {
                return OVR_Detect() == 1 ? true : false;

            }
        }

        public bool Init()
        {
           return OVR_Init() == 1 ? true : false;
        }

        unsafe public string GetLiveInfo()
        {
            float w, x, y, z, px, py, pz;
            OVR_Peek(&w, &x, &y, &z, &px, &py, &pz);
            return string.Format("{{\"w\":{0},\"x\":{1},\"y\":{2},\"z\":{3},\"px\":{4},\"py\":{5},\"pz\":{6}}}", w, x, y, z, px, py, pz);
        }

        public void Close()
        {
            OVR_Exit();
        }

        public void SendFeedback(string feedback)
        {
            if (feedback == "recenter")
            {
                OVR_Recenter();
            }
        }
        
    }
}
