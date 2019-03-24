using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DAL.DapperRepositories;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Services;
using System.Data.SqlClient;
using DAL.Interfaces;
using DAL.EFRepositories;
using System.IO;
using DAL.ADORepositories;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        UserManager userManager;
        ProductManager productManager;
        EntryForm entry = new EntryForm();
        User currentUser;
        SqlConnectionStringBuilder stringBuilder;
        IRepository<User> users;
        IRepository<DailyCalories> dailyCalories;
        Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            string dir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName).FullName;
            stringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "WeightLoss",
                DataSource = @"(localdb)\mssqllocaldb",
                AttachDBFilename = dir + @"\DAL\App_Data\WeightLoss.mdf",
                IntegratedSecurity = true
            };
            users = new ADOUserRepository(stringBuilder.ConnectionString);
            dailyCalories = new EFCaloriesRepository(stringBuilder.ConnectionString);
            userManager = new UserManager(users, dailyCalories);
            productManager = new ProductManager(new ADOProductRepository(stringBuilder.ConnectionString));
            dataGridView1.RowTemplate.Height = 25;
            ChooseDgv();
            Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = entry.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (!userManager.Validate(entry.Login, entry.Password))
                {
                    entry.ErrorMessage = "Error data!";
                    Form1_Load(this, e);
                }
                else
                {
                    currentUser = userManager.FindByLogin(entry.Login);
                    this.Visible = true;
                    this.Text = currentUser.Login;
                    CalorieRange range = userManager.GetNorm(currentUser);
                    label4.Text = range.Min + " - " + range.Max+ " kcal";
                }
            }
            else
            {
                if (dialogResult == DialogResult.Yes)
                {
                    RegistrationForm form = new RegistrationForm();
                    dialogResult = form.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (userManager.IsExists(form.User.Login))
                        {
                            entry.ErrorMessage = "This user already exist";
                        }
                        else
                        {
                            try
                            {
                                userManager.Create(form.User);
                            }
                            catch (Exception ex)
                            {
                                entry.ErrorMessage = "Wrong data:" + ex.Message;
                            }
                        }
                        Form1_Load(this, e);
                    }
                    else
                    {
                        userManager.Dispose();
                        this.Close();
                    }
                }
                userManager.Dispose();
                this.Close();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            stopWatch.Restart();
            List<Product> products = productManager.GetAll().ToList();
            stopWatch.Stop();
            labelTime.Text = "Time = " + stopWatch.Elapsed.TotalMilliseconds.ToString("f2") + " ms";
            int kcal = 0;
            int baseKcal = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    if ((int)dataGridView1[0, i].Value != 0 && int.TryParse(dataGridView1[1, i].Value.ToString(), out baseKcal))
                    {
                        int energy = products[(int)dataGridView1[0, i].Value-1].EnergyValue;
                        kcal += (baseKcal / 100) * energy;
                    }
                }
                catch (NullReferenceException) { }
            }
            label5.Text = kcal + " kcal";
        }

        private void ChooseDgv()
        {
            buttonCalculate.Enabled = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
            stopWatch.Restart();
            List<Product> products = productManager.GetAll().ToList();
            stopWatch.Stop();
            labelTime.Text = "Time = " + stopWatch.Elapsed.TotalMilliseconds.ToString("f2") + " ms";
            cbc.Name = "ProductList";
            cbc.HeaderText = "Foods";
            cbc.DataSource = products;
            cbc.DataPropertyName = "Name";
            cbc.DisplayMember = "Name";
            cbc.ValueMember = "Id";
            dataGridView1.Columns.Add(cbc);
            DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
            tbc.Name = "Weight";
            tbc.HeaderText = "Weight(gr)";
            dataGridView1.Columns.Add(tbc);
            dataGridView1.Font = new Font("Arial", 10);
            dataGridView1.RowCount = 1;
        }

        private void caloriesProductTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCalculate.Enabled = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns.Clear();
            stopWatch.Restart();
            dataGridView1.DataSource = productManager.GetAll().ToList().Select(p => new { ProductName = p.Name, p.EnergyValue }).ToList();
            stopWatch.Stop();
            labelTime.Text = "Time = " + stopWatch.Elapsed.TotalMilliseconds.ToString("f2") + " ms";
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseDgv();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCalculate.Enabled = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns.Clear();
            stopWatch.Restart();
            dataGridView1.DataSource = userManager.GetAll().ToList().Select(u => new { u.Login, u.Sex, u.Age, u.ActivityLevel }).ToList();
            stopWatch.Stop();
            labelTime.Text = "Time = " + stopWatch.Elapsed.TotalMilliseconds.ToString("f2") + " ms";
        }

        private void radioButtonADO_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonADO.Checked)
            {
                users = new ADOUserRepository(stringBuilder.ConnectionString);
                userManager = new UserManager(users, dailyCalories);
                productManager = new ProductManager(new ADOProductRepository(stringBuilder.ConnectionString));
            }
        }

        private void radioButtonEntity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEntity.Checked)
            {
                users = new EFUserRepository(stringBuilder.ConnectionString);
                userManager = new UserManager(users, dailyCalories);
                productManager = new ProductManager(new EFProductRepository(stringBuilder.ConnectionString));
            }
        }

        private void radioButtonDapper_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDapper.Checked)
            {
                users = new DapperUserRepository(stringBuilder.ConnectionString);
                userManager = new UserManager(users, dailyCalories);
                productManager = new ProductManager(new DapperProductRepository(stringBuilder.ConnectionString));
            }
        }
    }
}
