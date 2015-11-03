using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace libHitpan5.Model.EncryptionModel
{
    internal class EncryptionService
    {
        internal string GetEncryptedKey(string InputText, DateTime time)
        {
            int keyYear = Convert.ToInt32(time.Year) + 1;
            int keyMonth = Convert.ToInt32(time.Month) + 2;
            int keyDay = Convert.ToInt32(time.Day) + 3;
            int keyHour = Convert.ToInt32(time.Hour) + 4;
            int keyMinute = (Convert.ToInt32(time.Minute) / 5) + 5;
            string key = Convert.ToString(keyYear * keyMonth * keyDay * keyHour * keyMinute * 1108);
            //암호화 키 얻기
            string Password = key;
            // 입력받은 문자열을 바이트 배열로 변환
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

            // 최종 결과를 리턴
            return EncryptedData;
        }
    }
}
