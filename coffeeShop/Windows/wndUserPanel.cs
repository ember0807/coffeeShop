using CoffeeShop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoffeeShop.DatabaseManager;

namespace coffeeShop.Windows
{
    public partial class wndUserPanel : Form
    {
        public string UserId { get; set; }
        public int UserRole { get; set; }
        public wndUserPanel(string userId, int userRole)
        {
            InitializeComponent();
            UserId = userId;
            UserRole = userRole;

            this.Text = "User Panel - UserID: " + UserId + ", Role: " + UserRole;

            // Подписка на событие загрузки формы
            this.Load += wndUserPanel_Load;
        }
        private void wndUserPanel_Load(object sender, EventArgs e)
        {
            txtPrize.Visible = false;

            LoadTickets();
            CoffeeShop.User pCurUser = CoffeeShop.DatabaseManager.Instance.GetUserById(UserId);

            if(pCurUser.Points>=7)
                txtPrize.Visible=true;
            txtPoints.Text = string.Format("Ваши баллы: {0}.",pCurUser.Points);
            
        }
        private void LoadTickets()
        {
            try
            {
                // Получаем список всех билетов из базы данных
                List<Ticket> tickets = DatabaseManager.Instance.GetAllTickets();
                // Привязываем список билетов к dgTickets
                if (tickets != null)
                    dgTickets.DataSource = tickets;
                // Настройка отображения столбцов, при необходимости
                if (dgTickets.Columns.Contains("TicketId"))
                    dgTickets.Columns["TicketId"].Visible = false;

                if (dgTickets.Columns.Contains("Sum"))
                    dgTickets.Columns["Sum"].HeaderText = "Sum";

                if (dgTickets.Columns.Contains("Date"))
                    dgTickets.Columns["Date"].HeaderText = "Date";

                if (dgTickets.Columns.Contains("UserId"))
                    dgTickets.Columns["UserId"].Visible = false;

                if (dgTickets.Columns.Contains("Date"))
                {
                    // Выравнивание даты по левому краю
                    dgTickets.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgTickets.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                if (dgTickets.Columns.Contains("Sum"))
                {
                    dgTickets.Columns["Sum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                dgTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; //Отключаем автоматическое изменение размера, что бы скролл был
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки чеков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
