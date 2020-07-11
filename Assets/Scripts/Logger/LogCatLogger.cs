using NativeUtils;

namespace Logger
{
    public static class LogCatLogger
    {
        public static void LogInfo(string message)
        {
            JniUtils.CallStatic("LogInfo", message, "com.alexm.unitylogcat.Logger");
        }

        public static void LogWarn(string message)
        {
            JniUtils.CallStatic("LogWarn", message, "com.alexm.unitylogcat.Logger");
        }

        public static void LogError(string message)
        {
            JniUtils.CallStatic("LogError", message, "com.alexm.unitylogcat.Logger");
        }
    }
}