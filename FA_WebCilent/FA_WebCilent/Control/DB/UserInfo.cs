using System;

namespace FA_WebCilent.Control.DB
{
    public partial class UserInfo
 
    {
        private string _U_Id;
        public string U_Id
        {
            get
            {
                return _U_Id;
            }
            set
            {
                _U_Id = value;
            }
        }
        private string _U_Name;
        public string U_Name
        {
            get
            {
                return _U_Name;
            }
            set
            {
                _U_Name = value;
            }
        }
        private string _U_PassWord;
        public string U_PassWord
        {
            get
            {
                return _U_PassWord;
            }
            set
            {
                _U_PassWord = value;
            }
        }
        private string _U_NickName;
        public string U_NickName
        {
            get
            {
                return _U_NickName;
            }
            set
            {
                _U_NickName = value;
            }
        }
    }
}
