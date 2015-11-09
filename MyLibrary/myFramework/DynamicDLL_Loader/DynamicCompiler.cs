using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDLL_Loader
{
    /// <summary>
    /// 텍스트문서를 읽어서 C#DLL로 동적 컴파일링 수행
    /// </summary>
    class DynamicCompiler
    {
        public string[] Classes { get; set; }
        /// <summary>
        /// 생성자(텍스트문서를 읽어서 C#DLL로 동적 컴파일링 수행)
        /// </summary>
        /// <param name="DirectoryPath">하나의DLL로 만들 클래스정보가 담긴 텍스트파일이 모여있는 디렉토리 경로</param>
        /// <param name="DLLName">DLL파일경로</param>
        public DynamicCompiler(string FilesDirectoryPath, string DLLName)
        {
            string[] files = Directory.GetFiles(FilesDirectoryPath);
            Classes = new string[files.Length];

            int i = 0;
            foreach (string file in files)
            {
                string cls = File.ReadAllText(file, Encoding.UTF8);
                Classes[i] = cls;
                i++;
            }
            // C# 컴파일러 객체 생성
            CodeDomProvider codeDom = CodeDomProvider.CreateProvider("CSharp");
            // 컴파일러 파라미터 옵션 지정
            CompilerParameters cparams = new CompilerParameters();
            cparams.GenerateExecutable = true;
            cparams.OutputAssembly = DLLName;
            // 소스코드를 컴파일해서 DLL 생성
            CompilerResults results = codeDom.CompileAssemblyFromSource(cparams, Classes);
            // 컴파일 에러 있는 경우 표시
            if (results.Errors.Count > 0)
            {
                foreach (var err in results.Errors)
                {
                    throw new Exception(err.ToString());
                }
                return;
            }
        }
    }
}
