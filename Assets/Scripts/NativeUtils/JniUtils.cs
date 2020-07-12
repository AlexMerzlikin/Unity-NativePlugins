using System;
using UnityEngine;

namespace NativeUtils
{
    public static class JniUtils
    {
        private const string UnityAndroidClassName = "com.unity3d.player.UnityPlayer";
        private const string UnityActivityFieldName = "currentActivity";

        /// <summary>
        /// Call a non-static Java method in a class that accepts the Unity activity in a constructor using Jni
        /// Should be used when native plugin requires a context
        /// </summary>
        /// <typeparam name="T">The type of the argument</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="arg">The first argument</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        public static void CallWithUnityActivity<T>(string methodName, T arg, string androidJavaClass)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            using (var javaUnityPlayer = new AndroidJavaClass(UnityAndroidClassName))
            using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(UnityActivityFieldName))
            using (var androidPlugin = new AndroidJavaObject(androidJavaClass, currentActivity))
            {
                androidPlugin.Call(methodName, arg);
            }
        }

        /// <summary>
        /// Call a non-static Java method in a class that accepts the Unity activity in a constructor using Jni
        /// Should be used when native plugin requires a context
        /// </summary>
        /// <typeparam name="T1">The type of the first argument</typeparam>
        /// <typeparam name="T2">The type of the second argument</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="arg">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        public static void CallWithUnityActivity<T1, T2>(string methodName, T1 arg, T2 arg2, string androidJavaClass)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            using (var javaUnityPlayer = new AndroidJavaClass(UnityAndroidClassName))
            using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(UnityActivityFieldName))
            using (var androidPlugin = new AndroidJavaObject(androidJavaClass, currentActivity))
            {
                androidPlugin.Call(methodName, arg, arg2);
            }
        }
        
        /// <summary>
        /// Call a static Java method in a class using Jni
        /// </summary>
        /// <typeparam name="TArg">The type of argument</typeparam>
        /// <typeparam name="TResult">The return type of the method in the class you are calling</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="arg"></param>
        /// <param name="defaultValue">The value you want to return if there was a problem</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        /// <returns>Generic</returns>
        public static TResult CallStatic<TArg, TResult>(string methodName,
            TArg arg,
            TResult defaultValue,
            string androidJavaClass)
        {
            TResult result;

            if (Application.platform != RuntimePlatform.Android)
            {
                return defaultValue;
            }

            try
            {
                using (var androidClass = new AndroidJavaClass(androidJavaClass))
                {
                    result = androidClass.CallStatic<TResult>(methodName, arg);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{androidJavaClass}.{methodName} Exception:{ex}");
                return defaultValue;
            }

            return result;
        }

        /// <summary>
        /// Call a static Java method in a class using Jni
        /// </summary>
        /// <typeparam name="T">The type of the argument</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="arg">Argument to pass</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        public static void CallStatic<T>(string methodName, T arg, string androidJavaClass)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            try
            {
                using (var androidClass = new AndroidJavaClass(androidJavaClass))
                {
                    androidClass.CallStatic(methodName, arg);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{androidJavaClass}.{methodName} Exception:{ex}");
            }
        }

        /// <summary>
        /// Call a static Java method in a class using Jni
        /// </summary>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        public static void CallStatic(string methodName, string androidJavaClass)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            try
            {
                using (var androidClass = new AndroidJavaClass(androidJavaClass))
                {
                    androidClass.CallStatic(methodName);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{androidJavaClass}.{methodName} Exception:{ex}");
            }
        }
    }
}