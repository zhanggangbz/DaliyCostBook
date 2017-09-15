using System;

namespace FA_WebCilent.Control.DB
{
    public partial class CostTypeInfo 
    {
        private string _Y_Id;
        public string Y_Id
        {
            get
            {
                return _Y_Id;
            }
            set
            {
                _Y_Id = value;
            }
        }
        private string _Y_Name;
        public string Y_Name
        {
            get
            {
                return _Y_Name;
            }
            set
            {
                _Y_Name = value;
            }
        }
        private int _Y_IsIncome;
        public int Y_IsIncome
        {
            get
            {
                return _Y_IsIncome;
            }
            set
            {
                _Y_IsIncome = value;
            }
        }
        private string _F_U_Id;
        public string F_U_Id
        {
            get
            {
                return _F_U_Id;
            }
            set
            {
                _F_U_Id = value;
            }
        }
        private string _P_Y_Id;
        public string P_Y_Id
        {
            get
            {
                return _P_Y_Id;
            }
            set
            {
                _P_Y_Id = value;
            }
        }
    }
}
