using Logger;
using UnityEngine;

namespace Example
{
    public class LogCatExample : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(Log), 0, 3);
            InvokeRepeating(nameof(LogError), 1, 3);
            InvokeRepeating(nameof(LogWarn), 2, 3);
        }

        private void Log()
        {
            LogCatLogger.LogInfo("Native Info");
        }

        private void LogWarn()
        {
            LogCatLogger.LogWarn("Native Warn");
        }

        private void LogError()
        {
            LogCatLogger.LogError("Native Error");
        
        }
    }
}