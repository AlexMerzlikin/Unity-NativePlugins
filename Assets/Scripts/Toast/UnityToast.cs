using NativeUtils;

namespace Toast
{
    public static class UnityToast
    {
        private const string ToastPluginClass = "com.alexm.unitytoast.ToastPlugin";
        private const string ShowToastMethod = "ShowToast";
        
        public static void ShowToast(string message, ToastLength toastLength = ToastLength.Short)
        {
            JniUtils.CallWithUnityActivity(ShowToastMethod, message, (int) toastLength, ToastPluginClass);
        } 
    }
}