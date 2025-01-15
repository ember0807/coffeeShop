using coffeeShop.Windows;
using System;
using System.Windows.Forms;

namespace StylishLoginForm
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			//Init DB
			new CoffeeShop.DatabaseManager("ShopDataBase.db");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            CoffeeShop.DatabaseManager.Instance.PrintShortData();
            Application.Run(new wndStart()); // Запуск формы авторизации
#endif

        }
	}
}