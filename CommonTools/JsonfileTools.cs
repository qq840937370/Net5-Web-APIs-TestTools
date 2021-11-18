using Newtonsoft.Json;
using System.IO;

namespace WMSTOMESTT.Common
{

    public class JsonfileTools
    {
        /// <summary>
        /// 读取同目录下JSON文件
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="fileName">打开的文件名</param>
        /// <returns>实体类</returns>
        public static T ReadjsonT<T> (string fileName)
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + fileName))
            {
                return JsonConvert.DeserializeObject<T>(file.ReadToEnd());
            }
        }

        /// <summary>
        /// 写入同目录下JSON文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">保存使用的文件名</param>
        /// <param name="tParameter">实体类</param>
        /// <returns>成功状态</returns>
        public static bool WritejsonT<T>(string fileName, T tParameter)
        {
            string fp = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + fileName;
            try
            {
                File.WriteAllText(fp, JsonConvert.SerializeObject(tParameter));  // 覆盖写入
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
