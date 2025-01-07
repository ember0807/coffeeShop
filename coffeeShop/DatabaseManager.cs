using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

using System.Collections.Generic;

namespace StylishLoginForm
{
	public class DatabaseManager
	{
		private Dictionary<string, string> users = new Dictionary<string, string>();

		public bool AuthenticateUser(string username, string password)
		{
			// Имитация проверки пользователя
			return users.TryGetValue(username, out var storedPassword) && storedPassword == password;
		}

		public bool RegisterUser(string username, string password)
		{
			// Проверка на существование пользователя
			if (users.ContainsKey(username))
			{
				return false; // Пользователь уже существует
			}
			users[username] = password; // Добавление пользователя
			return true; // Регистрация была успешна
		}
	}
}