using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace certMakerLib
{
    public class main
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expireDate"></param>
        /// <param name="provider">
        /// provider는 보통 HTTPS URL 의 도메인 이름을 주게 됩니다. 
        /// 예를 들어 "https://myserver/test.aspx" 라고 접근하고 싶은 경우에는 반드시 "CN=myserver"라고 주어야 합니다. 
        /// (그렇지 않으면 웹 브라우저에서 인증서 경고가 나오게 됩니다.)
        /// </param>
        /// <param name="certName"></param>
        /// <returns></returns>
        public string MakeCert(DateTime expireDate,string provider,string certName) 
        {
            string exDate = string.Format("{0}/{1}/{2}", expireDate.Month.ToString().PadLeft(2, '0'), expireDate.Day.ToString().PadLeft(2, '0'), expireDate.Year.ToString().PadLeft(4, '0'));
            using (Process p= new Process())
            {
                try
                {
                    p.StartInfo =new ProcessStartInfo
                    (
                    string.Format("{0}\\LibCert\\makecert.exe",Environment.CurrentDirectory),
                    string.Format("-sr LocalMachine -pe -e {0} -n \"CN={1}\" -r -sky exchange -sv {2}.pvk {2}.cer ", exDate, provider, certName));
                    p.Start();
                    p.WaitForExit();

                    p.StartInfo = new ProcessStartInfo
                        (
                        string.Format("{0}\\LibCert\\Cert2Spc.exe",Environment.CurrentDirectory), 
                        string.Format("{0}.cer {0}.spc", certName));
                    p.Start();
                    p.WaitForExit();

                    p.StartInfo = new ProcessStartInfo
                        (
                        string.Format("{0}\\LibCert\\PVKIMPRT.EXE",Environment.CurrentDirectory), 
                        string.Format("-pfx {0}.spc {0}.pvk", certName));
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            return string.Format("{0}\\{1}.pfx",Environment.CurrentDirectory,certName);
        }
    }
}
