using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffeeShop.Windows
{
    public partial class wndStart : Form
    {
        public wndStart()
        {
            InitializeComponent();
#if DEBUG
            btnReqUserPass.Enabled = true;
            btnSignUpAdmin.Enabled = true;
#else
            btnReqUserPass.Enabled = false;
            btnSignUpAdmin.Enabled = false;
#endif
        }


        private void UserSignUp(CoffeeShop.DatabaseManager.eUserRole role)
        {
            string strUserName = tbUserName.Text;
            string strPassWord = tbPassWord.Text;
            string strUserID = "";

            bool bRegResult = CoffeeShop.DatabaseManager.Instance.RegisterUser(strUserName, strPassWord, out strUserID, CoffeeShop.DatabaseManager.eUserRole.ROLE_ADMIN);

            if (bRegResult == true)
            {
                MessageBox.Show(string.Format("Пользователь '{0}'::'{1}' успешно зарегистрирован как {2}. Назначенный уникальный ID: '{3}'. ",
                    strUserName, strPassWord, CoffeeShop.DatabaseManager.eUserRole.ROLE_ADMIN, strUserID));
            }
            else
            {
                MessageBox.Show(string.Format("Не удалось зарегистрировать пользователя  '{0}'::'{1}' как {2}. ",
                    strUserName, strPassWord, CoffeeShop.DatabaseManager.eUserRole.ROLE_ADMIN));
            }
        }
        private void btnSignUpAdmin_Click(object sender, EventArgs e)
        {
            UserSignUp(CoffeeShop.DatabaseManager.eUserRole.ROLE_ADMIN);
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            UserSignUp(CoffeeShop.DatabaseManager.eUserRole.ROLE_USER);
        }

        private void btnReqUserPass_Click(object sender, EventArgs e)
        {
            string strUserName = tbUserName.Text;
            CoffeeShop.User pUser = CoffeeShop.DatabaseManager.Instance.GetUserByPhone(strUserName);

            if (pUser == null)
                MessageBox.Show(string.Format("Пользователь с номером '{0}' не найден. ",
                    strUserName));
            else
            {
                MessageBox.Show(string.Format("Пароль пользователя '{0}':\n'{1}'. ",
                    strUserName,pUser.Password));
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string strUserName = tbUserName.Text;
            string strPassWord = tbPassWord.Text;

            int eRole = 0;
            string strUserID = "";

            bool bRet = CoffeeShop.DatabaseManager.Instance.AuthenticateUser(strUserName, strPassWord, out strUserID, out eRole);
            if (bRet == false)
                MessageBox.Show(string.Format("Пользователь с таким логином или паролем не найден. "));
            else
            {
                if((CoffeeShop.DatabaseManager.eUserRole)eRole == CoffeeShop.DatabaseManager.eUserRole.ROLE_USER)
                {
                    //Отображаем интерфейс для Пользователя
                    //1. Скрываем текущую форму.
                    this.Hide();
                    //2. Открываем форму Пользователя
                    wndUserPanel UserPanel = new wndUserPanel(strUserID, eRole);
                    UserPanel.ShowDialog();
                    //3. Восстанавливаем текущую форму после завершения работы с формой Пользователя
                    this.Show();
                }
                else
                {
                    //Отображаем интерфейс для Администратора
                    //1. Скрываем текущую форму.
                    this.Hide();
                    //2. Открываем форму Администратора
                    wndAdminPanel AdminPanel = new wndAdminPanel(strUserID, eRole);
                    AdminPanel.ShowDialog();
                    //3. Восстанавливаем текущую форму после завершения работы с формой Администратора
                    this.Show();

                }
            }

        }
    }
}
