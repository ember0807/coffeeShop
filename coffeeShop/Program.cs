using System;
using System.Windows.Forms;

namespace StylishLoginForm
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LoginForm()); // Запуск формы авторизации
		}
	}
}