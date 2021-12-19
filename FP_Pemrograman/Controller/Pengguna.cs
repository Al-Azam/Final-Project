using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FP_Pemrograman.Controller
{
    internal class Pengguna
    {
        Model.PenggunaModel pengguna;
        View.LoginWindow login;


        public Pengguna()
        { 
            pengguna = new Model.PenggunaModel();
            this.login = login;   
        }

        public void Login()
        { 
            pengguna.username = login.txtUsername.Text;
            pengguna.password = login.txtPassword.Password;
            bool result = pengguna.CekLogin();
            if (result)
            {
                View.LoginWindow main = new View.LoginWindow();
                main.Show();
                login.Close();
            }
            else {
                MessageBox.Show("Maaf, username/password anda salah");
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
            }
        }
    }
}
