using WebService.Model.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace WebService.Controller.SecurityManager
{
    class SecurityController
    {
        internal string securityTokenSeed { get; set; }
        internal SecurityController()
        {
            try
            {
                this.securityTokenSeed = ServerMain.getInstance().SecurityTokenSeed;

            }
            catch (Exception)
            {
                this.securityTokenSeed = "12344321";

            }
        }


        internal static string GetEncryptedString(string plainText)
        {
            string EncryptionPassword = ServerMain.getInstance().EncryptionPassword;
            string EncryptedText = new EncryptedKeyProvider().GetEncryptedString(plainText, EncryptionPassword);
            return EncryptedText;
        }
        internal static string GetDecryptedString(string EncryptedText)
        {
            string DecryptionPassword = ServerMain.getInstance().EncryptionPassword;
            string DecryptedText = new EncryptedKeyProvider().GetDecryptedString(EncryptedText, DecryptionPassword);
            return DecryptedText;
        }

        internal bool CheckSecurityToken(string token) 
        {
            if (securityTokenSeed==string.Empty)
	        {
		        return false;
	        }
            string value = new EncryptedKeyProvider().GetEncryptedKey(securityTokenSeed);
            if (value==token)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
