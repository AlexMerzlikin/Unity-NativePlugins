using System;
using UnityEngine;

namespace NativeUtils
{
    public static class JniUtils
    {
        /// <summary>
        /// StaticCall - Call a static Java method in a class using Jni
        /// </summary>
        /// <typeparam name="TArg">The type of argument</typeparam>
        /// <typeparam name="TResult">The return type of the method in the class you are calling</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="data"></param>
        /// <param name="defaultValue">The value you want to return if there was a problem</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        /// <returns>Generic</returns>
        public static TResult CallStatic<TArg, TResult>(string methodName, TArg data, TResult defaultValue, string androidJavaClass)
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
                    result = androidClass.CallStatic<TResult>(methodName, data);
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
        /// StaticCall - Call a static Java method in a class using Jni
        /// </summary>
        /// <typeparam name="T">The type of the argument</typeparam>
        /// <param name="methodName">The name of the method you want to call</param>
        /// <param name="parameter">Argument to pass</param>
        /// <param name="androidJavaClass">The name of the Package and Class eg, packagename.myClassName or com.yourandroidlib.example.ClassName</param>
        public static void CallStatic<T>(string methodName, T parameter, string androidJavaClass)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return;
            }

            try
            {
                using (var androidClass = new AndroidJavaClass(androidJavaClass))
                {
                    androidClass.CallStatic(methodName, parameter);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"{androidJavaClass}.{methodName} Exception:{ex}");
            }
        }
    
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