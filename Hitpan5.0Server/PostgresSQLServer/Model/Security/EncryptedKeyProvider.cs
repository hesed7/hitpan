using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PostgresSQLServer.Model.Security
{
    class EncryptedKeyProvider
    {
        /// <summary>
        /// 입력받은 문자열을 5분마다 다르게 암호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        internal string GetEncryptedKey(string InputText)
        {
            //암호화 키 얻기
            string Password = GetEncryptKey();
            // 입력받은 문자열을 암호화
            string EncryptedData = GetEncryptedString(InputText, Password);

            // 최종 결과를 리턴
            return EncryptedData;
        }
        /// <summary>
        /// 입력받은 문자열(GetEncryptedKey에 의해 암호화된 문자열)을  복호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        internal string GetDecryptedKey(string InputText)
        {
            //복호화 키 얻기
            string Password = GetEncryptKey();
            // 입력받은 문자열을 복호화
            string DecryptedData = GetDecryptedString(InputText, Password);
            // 최종 결과 리턴
            return DecryptedData;
        }
        /// <summary>
        /// 문자열을 입력받은 키로 암호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        internal string GetEncryptedString(string InputText, string Password)
        {
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);

            #region 암호화 키 객체 생성
            // Rihndael class를 선언하고, 초기화 합니다
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            // 딕셔너리 공격을 대비해서 키를 더 풀기 어렵게 만들기 위해서
            // Salt를 사용합니다.
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            // PasswordDeriveBytes 클래스를 사용해서 SecretKey를 얻습니다.
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            /* Create a encryptor from the existing SecretKey bytes.
               encryptor 객체를 SecretKey로부터 만듭니다.
               Secret Key에는 32바이트
               (Rijndael의 디폴트인 256bit가 바로 32바이트입니다)를 사용하고,
               Initialization Vector로 16바이트
               (역시 디폴트인 128비트가 바로 16바이트입니다)를 사용합니다
             */
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            #endregion

            #region 암호화
            byte[] CipherBytes = null;
            // 메모리스트림 객체를 선언,초기화 
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // CryptoStream객체를 암호화된 데이터를 쓰기 위한 용도로 선언
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write))
                {
                    // 암호화 프로세스가 진행됩니다.
                    cryptoStream.Write(PlainText, 0, PlainText.Length);
                    // 암호화 종료
                    cryptoStream.FlushFinalBlock();
                    // 암호화된 데이터를 바이트 배열로 담습니다.
                    CipherBytes = memoryStream.ToArray();
                }
            }
            // 암호화된 데이터를 Base64 인코딩된 문자열로 변환합니다.
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            //암호키 객체 해제
            Encryptor.Dispose();
            #endregion
            return EncryptedData;
        }

        
        /// <summary>
        /// 문자열을 복호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        internal  string GetDecryptedString(string InputText, string Password)
        {
            byte[] EncryptedData = Convert.FromBase64String(InputText);
            #region 복호화 키 객체 만들기
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            // Decryptor 객체를 만듭니다.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            #endregion
            #region 복호화
            byte[] PlainText = null;
            int DecryptedCount = 0;
            using (MemoryStream memoryStream = new MemoryStream(EncryptedData))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read))
                {
                    /*
                     * 복호화된 데이터를 담을 바이트 배열을 선언합니다.
                       길이는 알 수 없지만, 일단 복호화되기 전의 데이터의 길이보다는
                       길지 않을 것이기 때문에 그 길이로 선언합니다
                     */
                    PlainText = new byte[EncryptedData.Length];

                    // 복호화 시작
                    DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                }
            }
            // 복호화된 데이터를 문자열로 바꿉니다.
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            //복호화 키 객체 해제
            Decryptor.Dispose();
            #endregion
            return DecryptedData;
        }


        /// <summary>
        /// 시간을 기반으로 한 공개키 제공
        /// </summary>
        /// <returns></returns>
        private static string GetEncryptKey()
        {
            int keyYear = Convert.ToInt32(DateTime.Now.Year) + 1;
            int keyMonth = Convert.ToInt32(DateTime.Now.Month) + 2;
            int keyDay = Convert.ToInt32(DateTime.Now.Day) + 3;
            int keyHour = Convert.ToInt32(DateTime.Now.Hour) + 4;
            int keyMinute = (Convert.ToInt32(DateTime.Now.Minute) / 5) + 5;
            string key = Convert.ToString(keyYear * keyMonth * keyDay * keyHour * keyMinute * 1108);
            return key;
        }

        internal string GetEncryptedString()
        {
            throw new NotImplementedException();
        }
    }
}
