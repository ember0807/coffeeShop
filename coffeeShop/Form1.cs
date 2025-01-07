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
			this.BackColor = Color.FromArgb(240, 240, 240);
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Padding = new Padding(10, 20, 10, 10); // Добавить отступы

			// Настройка стилей полей ввода
			txtUsername.BackColor = Color.White;
			txtUsername.BorderStyle = BorderStyle.FixedSingle;
			txtUsername.Font = new Font("Segoe UI", 12);
			txtUsername.ForeColor = Color.Gray;

			txtPassword.BackColor = Color.White;
			txtPassword.BorderStyle = BorderStyle.FixedSingle;
			txtPassword.Font = new Font("Segoe UI", 12);
			txtPassword.ForeColor = Color.Gray;

			// Настройка стилей для кнопок
			btnLogin.BackColor = Color.DodgerBlue;
			btnLogin.ForeColor = Color.White;
			btnLogin.FlatStyle = FlatStyle.Flat;
			btnLogin.Font = new Font("Segoe UI", 12);
			btnLogin.FlatAppearance.BorderSize = 0;
			btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.CornflowerBlue; // Эффект наведения
			btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.DodgerBlue;

			btnCancel.BackColor = Color.Gray;
			btnCancel.ForeColor = Color.White;
			btnCancel.FlatStyle = FlatStyle.Flat;
			btnCancel.Font = new Font("Segoe UI", 12);
			btnCancel.FlatAppearance.BorderSize = 0;
			btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.DarkGray; // Эффект наведения
			btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.Gray;

			// Настройка заголовка
			lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
			lblTitle.ForeColor = Color.DodgerBlue;
			lblTitle.TextAlign = ContentAlignment.MiddleCenter;
			lblTitle.Dock = DockStyle.Top; // Выравнивание заголовка
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