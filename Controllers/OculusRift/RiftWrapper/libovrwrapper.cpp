// RiftWrapper.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#define OVR_D3D_VERSION 10

    #include "libovrwrapper.h"
	#include "OVR_CAPI.h"
    #include "OVR_CAPI_D3D.h"
	ovrHmd             HMD;


    LIBOVRWRAPPER_API int OVR_Init()
    {
	   // Initializes LibOVR, and the Rift
	   ovr_Initialize();
	   HMD = ovrHmd_Create(0);

	   // Start the sensor which informs of the Rift's pose and motion
	   ovrHmd_ConfigureTracking(HMD, ovrTrackingCap_Orientation | ovrTrackingCap_MagYawCorrection |
		   ovrTrackingCap_Position, 0);

       return (HMD?1:0);
    }


    LIBOVRWRAPPER_API void OVR_Exit()
    {
		ovrHmd_Destroy(HMD);
		ovr_Shutdown();
    }

    LIBOVRWRAPPER_API int OVR_Peek(float* w, float* x, float* y,float * z, float* px, float* py, float* pz)
    {

		ovrPosef            EyeRenderPose[2];
		ovrEyeRenderDesc    EyeRenderDesc[2];

		if (!HMD)
		{
			return 0;
		}
		ovrTrackingState hmdState;
		ovrVector3f hmdToEyeViewOffset[2] = { EyeRenderDesc[0].HmdToEyeViewOffset, EyeRenderDesc[1].HmdToEyeViewOffset };
		ovrHmd_GetEyePoses(HMD, 0, hmdToEyeViewOffset, EyeRenderPose, &hmdState);

	   
		*w = hmdState.HeadPose.ThePose.Orientation.w;
		*x = hmdState.HeadPose.ThePose.Orientation.x;
		*y = hmdState.HeadPose.ThePose.Orientation.y;
		*z = hmdState.HeadPose.ThePose.Orientation.z;
		*px = hmdState.HeadPose.ThePose.Position.x;
		*py = hmdState.HeadPose.ThePose.Position.y;
		*pz = hmdState.HeadPose.ThePose.Position.z;

       return 1;
    }

	LIBOVRWRAPPER_API void OVR_Recenter()
	{
		ovrHmd_RecenterPose(HMD);
	}

	LIBOVRWRAPPER_API int OVR_Detect()
	{
		return ovrHmd_Detect();
	}

 