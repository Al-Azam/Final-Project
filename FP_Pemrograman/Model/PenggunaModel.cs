using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FP_Pemrograman.Model
{
    internal class PenggunaModel
    {
        ModelTemplate temp;
        
        public string username{ get; set; }
        public string nama { get; set; }
        public string jk { get; set; }
        public string telp { get; set; }
        public string password { get; set; }

        public PenggunaModel()
        { 
        temp = new ModelTemplate();        
        }

        public Boolean CekLogin()
        {
            bool result;
            DataSet ds = new DataSet();
            ds = temp.Select("test", "username = '" + username + "' AND password = '" + password + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            else 
            {
                result = false;
            }
            return result;
        }
    }
}
