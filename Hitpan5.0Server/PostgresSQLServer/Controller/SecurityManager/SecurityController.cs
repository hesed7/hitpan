using PostgresSQLServer.Model.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace PostgresSQLServer.Controller.SecurityManager
{
    class SecurityController
    {
        public string securityTokenSeed { get; set; }
        public SecurityController()
        {
            try
            {
                string EncryptionPassword = ServerMain.getInstance().EncryptionPassword;
                this.securityTokenSeed = File.ReadAllText(string.Format("{0}\\securityTokenSeed.seed", Environment.CurrentDirectory),Encoding.UTF8);
                this.securityTokenSeed = new EncryptedKeyProvider().GetDecryptedString(securityTokenSeed, EncryptionPassword);
            }
            catch (Exception)
            {
                this.securityTokenSeed = "!@#$4321$#@!";

            }
        }


        public static void  SetSecurityTokenSeed(string seed)
        {
            string EncryptionPassword = ServerMain.getInstance().EncryptionPassword;
            string SecurityTokenSeed = new EncryptedKeyProvider().GetEncryptedString(seed, EncryptionPassword);
            File.AppendAllText(string.Format("{0}\\securityTokenSeed.seed", Environment.CurrentDirectory), SecurityTokenSeed);
        }


        internal bool CheckSecurityToken(string token) 
        {
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
