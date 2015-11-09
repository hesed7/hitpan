using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libHitpan5._Exception
{
    /// <summary>
    /// 권한없이 작업할 경우
    /// </summary>
    public class NotAuthException : Exception
    {
        private string message { get; set; }
        public NotAuthException(string message)
        {
            this.message = message;
        }
        public NotAuthException()
        {

        }
    }
    /// <summary>
    /// 로그인 안하고 작업할 경우
    /// </summary>
    public class NotLoginException : Exception
    {
        private string message { get; set; }
        public NotLoginException(string message)
        {
            this.message = message;
        }
        public NotLoginException()
        {

        }
    }
    /// <summary>
    /// 로그인 안하고 작업할 경우
    /// </summary>
    public class InvalidLogin : Exception
    {
        private string message { get; set; }
        public InvalidLogin(string message)
        {
            this.message = message;
        }
        public InvalidLogin()
        {

        }
    }
}
