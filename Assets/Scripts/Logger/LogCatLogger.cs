using NativeUtils;

namespace Logger
{
    public static class LogCatLogger
    {
        private const string LoggerPluginClass = "com.alexm.unitytoast.ToastPlugin";
        private const string LogInfoMethod = "LogInfo";
        private const string LogWarnMethod = "LogWarn";
        private const string LogErrorMethod = "LogError";

        public static void LogInfo(string message)
        {
            JniUtils.CallStatic(LogInfoMethod, message, LoggerPluginClass);
        }

        public static void LogWarn(string message)
        {
            JniUtils.CallStatic(LogWarnMethod, message, LoggerPluginClass);
        }

        public static void LogError(string message)
        {
            JniUtils.CallStatic(LogErrorMethod, message, LoggerPluginClass);
        }
    }
}