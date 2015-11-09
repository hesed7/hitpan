using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDLL_Loader
{
    //DLL동적로딩 관리자 클래스
    public class DllManager
    {
        bool boolDispose = false;

        private DLLLoader Loader { get; set; }
        #region 싱글턴
        public string DLLPath { get; set; }
        private static DllManager instance { get; set; }
        private DllManager(string FileDirectoryPath, string DLLPath)
        {
            this.DLLPath = DLLPath;
            new DynamicCompiler(FileDirectoryPath, DLLPath);
            Loader = new DLLLoader();
            Loader.LoadDLL(DLLPath);
        }
        public static DllManager getInstance(string FileDirectoryPath, string DLLPath)
        {
            if (instance == null)
            {
                instance = new DllManager(FileDirectoryPath, DLLPath);
            }
            return instance;
        }
        #endregion

        public void Dispose()
        {
            if (boolDispose)
            {
                return;
            }
            boolDispose = true;
            File.Delete(DLLPath);
        }


        public object OperateMethod_WithReturn(string className, String methodName, object[] param)
        {
            if (boolDispose)
            {
                return null;
            }
            //Type t= Loader.dicDLLProperties[className];
            //해당 클래스의 인스턴스 만들기
            object inst = Loader.getInstance(className);//Activator.CreateInstance(t,param);
            //해당 클래스에서 특정 메서드 찾기
            MethodInfo mi = inst.GetType().GetMethod(methodName);
            //해당 메서드에서 반환값 받기       
            if (mi == null)
            {
                throw new MethodAccessException(string.Format("{0} 클래스에서 이름이 {1}인 메서드가 없습니다", className, methodName));
            }
            string obj = mi.Invoke(inst, param).ToString();
            return obj;
        }
        public void OperateMethod(string className, String methodName, object[] param)
        {
            if (boolDispose)
            {
                return;
            }
            //해당 클래스의 인스턴스 만들기
            //Type t = Loader.dicDLLProperties[ClassName];
            object inst = Loader.getInstance(className);//object inst = Activator.CreateInstance(t);
            //해당 클래스에서 특정 메서드 찾기
            MethodInfo mi = inst.GetType().GetMethod(methodName);
            //해당 메서드 실행
            if (mi == null)
            {
                throw new MethodAccessException(string.Format("{0} 클래스에서 이름이 {1}인 메서드가 없습니다", className, methodName));
            }
            mi.Invoke(inst, param);
        }
    }
}
