using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace FaspBrowser.Tools
{
    /// <summary>
    /// JSON转化帮助类
    /// </summary>
    class JsonUtils
    {
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object o)
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception e)
            {
                // 解析过程中出现异常不处理，返回空字符串
                Debug.WriteLine(e.Message);
            }
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            T t = null;
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
                t = o as T;
            }
            catch (Exception e)
            {
                // 解析过程中出现异常不处理，返回null 
                Debug.WriteLine(e.Message);
            }
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合，有异常返回空字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            List<T> list = new List<T>();
            // 如果参数为空则返回空List
            if (string.IsNullOrEmpty(json))
            {
                return list;
            }
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
                list = o as List<T>;
            }
            catch (Exception e)
            {
                // 解析过程中出现异常不处理，返回空List       
                Debug.WriteLine(e.Message);
            }
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = default(T);
            try
            {
                t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return t;
        }
    }
}
