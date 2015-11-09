using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDLL_Loader
{
    //DLL 동적 로딩
    class DLLLoader
    {
        private IDictionary<string, Type> dicDLLProperties { get; set; }
        private Assembly assembly { get; set; }
        public bool LoadDLL(string FileName)
        {
            dicDLLProperties = new Dictionary<string, Type>();
            //Dll존재여부 검증
            if (!File.Exists(FileName))
            {
                return false;
            }
            try
            {
                //Dll로드
                assembly = Assembly.LoadFrom(FileName);
                //Dll구성요소 리스트 갱신
                Type[] DLLProperties = assembly.GetExportedTypes();
                foreach (Type type in DLLProperties)
                {
                    dicDLLProperties.Add(type.Name, type);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 로드한 DLL파일 안의 클래스에 대한 instance 반환
        /// </summary>
        /// <returns></returns>
        public object getInstance(string ClassName)
        {
            Type t = dicDLLProperties[ClassName];
            string FullClassName = t.FullName;
            object inst = Activator.CreateInstance(t) as object;//assembly.CreateInstance(FullClassName);           
            return inst;
        }
    }
}
