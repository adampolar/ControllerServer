    #ifdef LIBOVRWRAPPER_EXPORTS
       #if defined __cplusplus
          #define LIBOVRWRAPPER_API extern "C" __declspec(dllexport)
       #else
          #define LIBOVRWRAPPER_API __declspec(dllexport)
       #endif
    #else
       #if defined __cplusplus
          #define LIBOVRWRAPPER_API extern "C" __declspec(dllimport)
       #else
          #define LIBOVRWRAPPER_API __declspec(dllimport)
       #endif
    #endif


    LIBOVRWRAPPER_API int   OVR_Init();
    LIBOVRWRAPPER_API void  OVR_Exit();
    LIBOVRWRAPPER_API int   OVR_Peek(float* w, float* x, float* y,float * z, float* px, float* py, float* pz);
	LIBOVRWRAPPER_API void  OVR_Recenter();
	LIBOVRWRAPPER_API int   OVR_Detect();
