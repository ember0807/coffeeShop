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

namespace coffeeShop.Windows
{
    public partial class wndAdminPanel : Form
    {
        public string UserId { get; set; }
        public int UserRole { get; set; }

        public wndAdminPanel(string userId, int userRole)
        {
            InitializeComponent();
            UserId = userId;
            UserRole = userRole;

            this.Text = "Admin Panel - UserID: " + UserId + ", Role: " + UserRole;

            // Подписка на событие загрузки формы
            this.Load += wndAdminPanel_Load;
        }

        private void wndAdminPanel_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadTickets();
        }

        private void LoadUsers()
        {
            try
            {
                // Получаем список всех пользователей из базы данных
                List<User> users = DatabaseManager.Instance.GetAllUsers();

                // Привязываем список пользователей к dgUsers
                if (users != null)
                    dgUsers.DataSource = users;

                // Настройка отображения столбцов, при необходимости
                dgUsers.Columns["Password"].Visible = false;
                dgUsers.Columns["UserId"].HeaderText = "ID";
                dgUsers.Columns["PhoneNumber"].HeaderText = "Phone";
                dgUsers.Columns["Role"].HeaderText = "Role";
                dgUsers.Columns["Points"].HeaderText = "Points";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                dgTickets.Columns["TicketId"].HeaderText = "ID";
                dgTickets.Columns["Sum"].HeaderText = "Sum";
                dgTickets.Columns["Date"].HeaderText = "Date";
                dgTickets.Columns["UserId"].HeaderText = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки чеков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUserPhone_TextChanged(object sender, EventArgs e)
        {
            if(tbUserPhone.Text.Length>8)
            {
                CoffeeShop.User user = CoffeeShop.DatabaseManager.Instance.GetUserByPhone(tbUserPhone.Text);
                if(user != null)
                {
                    txtPointsCount.Text = "Баллов: " + user.Points;
                    if (user.Points >= 7)
                    {
                        txtPointsCount.BackColor = Color.Green;
                        cbCoffeeForFree.Visible = true;
                    }
                        
                    else
                    {
                        txtPointsCount.BackColor = Color.White;
                        cbCoffeeForFree.Visible = false;
                    }
                }
            }
            else
            {
                txtPointsCount.Text = "Баллов: 0";
                cbCoffeeForFree.Visible = false;
            }
        }

        private void MakeNewTicket()
        {
            string strUserPhone = tbUserPhone.Text;
            string strTicketPrice = tbTicketSum.Text.Replace(".",",");
            float fPrice = float.Parse(strTicketPrice);

            CoffeeShop.User user = CoffeeShop.DatabaseManager.Instance.GetUserByPhone(strUserPhone);
            if (user == null)
            {
                DialogResult dgRes = MessageBox.Show(string.Format("Пользователь не найден в базе. Предложите зарегистрироваться или чек будет создан без связи. \nПрервать - Отменить покупку.\nПовторить - если покупатель зарегистрировался.\nПродолжить - создать чек без привязки к покупателю."), "Внимание",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                if (dgRes == DialogResult.Retry)
                {
                    MakeNewTicket();

                    return;
                }
                else if (dgRes == DialogResult.Ignore)
                {
                    CoffeeShop.DatabaseManager.Instance.CreateTicket("nope", fPrice);
                }
                else
                {

                }


            }
            else
            {
                if(user.Points >= 7 && cbCoffeeForFree.Checked == true)
                {
                    CoffeeShop.DatabaseManager.Instance.CreateTicket(user.UserId, 0.0f);
                    CoffeeShop.DatabaseManager.Instance.AddPoints(user.UserId, -7);
                }
                else
                {
                    CoffeeShop.DatabaseManager.Instance.CreateTicket(user.UserId, fPrice);
                    CoffeeShop.DatabaseManager.Instance.AddPoints(user.UserId, 1);
                    if (user.Points + 1 >= 7)
                    {
                        MessageBox.Show(string.Format("Сообщите пользователю что следующая его покупка может быть бесплатная. "));
                    }
                }
                
                
            }

            tbUserPhone.Text = "";
            tbTicketSum.Text = "";
            cbCoffeeForFree.Visible = false;
            cbCoffeeForFree.Checked = false;
            txtPointsCount.BackColor = Color.White;
            LoadTickets();
            LoadUsers();
        }

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            MakeNewTicket();
        }
    }
}
