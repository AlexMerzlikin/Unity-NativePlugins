package com.alexm.unitylogcat;

import android.util.Log;

public final class Logger
{
    private static final String TAG = "UnityLogcat";

    public static void LogInfo(String message)
    {
        Log.i(TAG, message);
    }

    public static void LogError(String message)
    {
        Log.e(TAG, message);
    }

    public static void LogWarn(String message)
    {
        Log.w(TAG, message);
    }
}