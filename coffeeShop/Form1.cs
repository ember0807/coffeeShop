using System;
using System.Drawing;
using System.Windows.Forms;

namespace StylishLoginForm
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
			CustomizeDesign();
		}

		private void CustomizeDesign()
		{
			// Настройка фона формы
			this.BackColor = Color.White;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.StartPosition = FormStartPosition.CenterScreen;

			// Настройка стилей полей ввода
			txtUsername.BackColor = Color.LightGray;
			txtUsername.BorderStyle = BorderStyle.None;

			txtPassword.BackColor = Color.LightGray;
			txtPassword.BorderStyle = BorderStyle.None;

			// Настройка стилей для кнопок
			btnLogin.BackColor = Color.DodgerBlue;
			btnLogin.ForeColor = Color.White;
			btnLogin.FlatStyle = FlatStyle.Flat;

			btnCancel.BackColor = Color.Gray;
			btnCancel.ForeColor = Color.White;
			btnCancel.FlatStyle = FlatStyle.Flat;

			// Настройка заголовка
			lblTitle.Font = new Font("Arial", 14, FontStyle.Bold);
			lblTitle.ForeColor = Color.DodgerBlue;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text;
			string password = txtPassword.Text;

			// Проверка учетных данных
			if (AuthenticateUser(username, password))
			{
				MessageBox.Show("Добро пожаловать!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool AuthenticateUser(string username, string password)
		{
			// Заглушка для проверки учетных данных
			return username == "admin" && password == "password";
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}