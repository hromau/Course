using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkForDB
{
    public partial class ViewTable : Form
    {
        public static ModelContext model = new ModelContext();
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\C#\CourseworkForDB\CourseworkForDB\Coursework.mdf;Integrated Security=True;Connect Timeout=30");
        Thread AppExit = new Thread(CloseAndExit);

        public ViewTable()
        {
            InitializeComponent();
        }
        

        private void ViewTable_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.Width = this.Width;
            dataGridView1.Height = this.Height - 24;
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            отключеноToolStripMenuItem.Enabled = false;
            using (SqlCommand comm = new SqlCommand("SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE LIKE '%TABLE%'", connection))
            {
                //try
                //{
                connection.Open();

                var reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    toolStripComboBox1.Items.Add(reader.GetString(0));
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK);
                //    this.Enabled = true;
                //    this.Cursor = Cursors.Default;
                //    return;
                //}
                connection.Close();
            }
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        public Contract tempContract;
        public Writer tempWriter;
        public Books tempBooks;
        public Orders tempOrders;
        public Customers tempCustomers;

        private void ToolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from " + toolStripComboBox1.SelectedItem.ToString(), connection);
            //try
            //{
            dataAdapter.Fill(ds, toolStripComboBox1.SelectedItem.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Enabled = true;
            //    this.Cursor = Cursors.Default;
            //    connection.Close();
            //    return;
            //}

            //try
            //{
            dataGridView1.DataSource = ds.Tables[toolStripComboBox1.SelectedItem.ToString()].DefaultView;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Enabled = true;
            //    this.Cursor = Cursors.Default;
            //    connection.Close();
            //    return;
            //}
            connection.Close();
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppExit.Start();
        }

        static void CloseAndExit()
        {
            connection.Close();
            Application.Exit();
        }

        private void ВключеноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            включеноToolStripMenuItem.Enabled = false;
            отключеноToolStripMenuItem.Enabled = true;
        }

        private void ОтключеноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            включеноToolStripMenuItem.Enabled = true;
            отключеноToolStripMenuItem.Enabled = false;
        }

        static string GetValueCell(ref DataGridView dataGrid)
        {
            //string a = dataGrid.SelectedColumns[0].HeaderText;

            //string b = dataGrid.SelectedRows[0].Cells

            Dictionary<string, string> dic = new Dictionary<string, string>();

            List<string> lKey = new List<string>();
            List<string> lValue = new List<string>();

            for (int i=0;i<dataGrid.ColumnCount;i++)
            {
                dic.Add(dataGrid.Columns[i].HeaderText, dataGrid.CurrentRow.Cells[i].Value.ToString());
            }

            return null;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.ReadOnly == false)
            {
                switch (e.KeyData)
                {
                    case (Keys.Enter):
                        {
                            
                            GetValueCell(ref dataGridView1);
                            //switch (toolStripComboBox1.SelectedItem.ToString())
                            //{
                            //    case "Contract":
                            //        {
                            //            tempContract = new Contract
                            //            {
                            //                ContractTerminationDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4]),
                            //                IdContract = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0]),
                            //                DateOfContract = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1]),
                            //                LengthOfContract = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2]),
                            //                StateContract = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[3])
                            //            };
                            //            if (entities.Contract.Contains(tempContract))
                            //            {
                            //                entities.Contract.Attach(tempContract);
                            //                var entry = entities.Entry(tempContract);
                            //                entry.Property(t => t.ContractTerminationDate).IsModified = true;
                            //                entry.Property(t => t.IdContract).IsModified = true;
                            //                entry.Property(t => t.DateOfContract).IsModified = true;
                            //                entry.Property(t => t.LengthOfContract).IsModified = true;
                            //                entry.Property(t => t.StateContract).IsModified = true;
                            //                entities.SaveChanges();
                            //            }
                            //            else
                            //            {
                            //                entities.Contract.Add(tempContract);
                            //                entities.SaveChanges();
                            //            }
                            //            break;
                            //        }
                            //    case "Writer":
                            //        {
                            //            tempWriter = new Writer
                            //            {
                            //                FirstName = dataGridView1.SelectedRows[0].Cells[0].ToString(),
                            //                LastName = dataGridView1.SelectedRows[0].Cells[1].ToString(),
                            //                Patronymic = dataGridView1.SelectedRows[0].Cells[2].ToString(),
                            //                Address = dataGridView1.SelectedRows[0].Cells[3].ToString(),
                            //                Telephone = dataGridView1.SelectedRows[0].Cells[4].ToString()
                            //            };
                            //            if (entities.Writer.Contains(tempWriter))
                            //            {
                            //                entities.Writer.Attach(tempWriter);
                            //                var entry = entities.Entry(tempWriter);
                            //                entry.Property(t => t.FirstName).IsModified = true;
                            //                entry.Property(t => t.LastName).IsModified = true;
                            //                entry.Property(t => t.Patronymic).IsModified = true;
                            //                entry.Property(t => t.Address).IsModified = true;
                            //                entry.Property(t => t.Telephone).IsModified = true;
                            //                entities.SaveChanges();
                            //            }
                            //            else
                            //            {
                            //                entities.Writer.Add(tempWriter);
                            //                entities.SaveChanges();
                            //            }
                            //        }
                            //        break;
                            //    case "Books":
                            //        {
                            //            tempBooks = new Books
                            //            {
                            //                BookChiper = dataGridView1.SelectedRows[0].Cells[0].ToString(),
                            //                Name = dataGridView1.SelectedRows[0].Cells[1].ToString(),
                            //                Printing = int.Parse(dataGridView1.SelectedRows[0].Cells[2].ToString()),
                            //                PrintDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3]),
                            //                CostPrice = int.Parse(dataGridView1.SelectedRows[0].Cells[4].ToString()),
                            //                SellingPrice = int.Parse(dataGridView1.SelectedRows[0].Cells[5].ToString()),
                            //                Fee = int.Parse(dataGridView1.SelectedRows[0].Cells[6].ToString())
                            //            };
                            //            if (entities.Books.Contains(tempBooks))
                            //            {
                            //                entities.Books.Attach(tempBooks);
                            //                var entry = entities.Entry(tempBooks);
                            //                entry.Property(t => t.BookChiper).IsModified = true;
                            //                entry.Property(t => t.Name).IsModified = true;
                            //                entry.Property(t => t.Printing).IsModified = true;
                            //                entry.Property(t => t.PrintDate).IsModified = true;
                            //                entry.Property(t => t.CostPrice).IsModified = true;
                            //                entry.Property(t => t.SellingPrice).IsModified = true;
                            //                entry.Property(t => t.Fee).IsModified = true;
                            //                entities.SaveChanges();
                            //            }
                            //            else
                            //            {
                            //                entities.Books.Add(tempBooks);
                            //                entities.SaveChanges();
                            //            }
                            //        }
                            //        break;
                            //    case "Orders":
                            //        {
                            //            tempOrders = new Orders
                            //            {
                            //                IDOrder = int.Parse(dataGridView1.SelectedRows[0].Cells[0].ToString()),
                            //                OrderDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1]),
                            //                OrderExecutionDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[2]),
                            //                BookCount = int.Parse(dataGridView1.SelectedRows[0].Cells[3].ToString())
                            //            };
                            //            if (entities.Orders.Contains(tempOrders))
                            //            {
                            //                entities.Orders.Attach(tempOrders);
                            //                var entry = entities.Entry(tempOrders);
                            //                entry.Property(t => t.IDOrder).IsModified = true;
                            //                entry.Property(t => t.OrderDate).IsModified = true;
                            //                entry.Property(t => t.OrderExecutionDate).IsModified = true;
                            //                entry.Property(t => t.BookCount).IsModified = true;
                            //                entities.SaveChanges();
                            //            }
                            //            else
                            //            {
                            //                entities.Orders.Add(tempOrders);
                            //                entities.SaveChanges();
                            //            }
                            //        }
                            //        break;
                            //    case "Customers":
                            //        {
                            //            tempCustomers = new Customers
                            //            {
                            //                CustomerName = dataGridView1.SelectedRows[0].Cells[0].ToString(),
                            //                Address = dataGridView1.SelectedRows[0].Cells[1].ToString(),
                            //                Tel = dataGridView1.SelectedRows[0].Cells[2].ToString(),
                            //                FirstLastName = dataGridView1.SelectedRows[0].Cells[3].ToString()
                            //            };
                            //            if (entities.Customers.Contains(tempCustomers))
                            //            {
                            //                entities.Customers.Attach(tempCustomers);
                            //                var entry = entities.Entry(tempCustomers);
                            //                entry.Property(t => t.CustomerName).IsModified = true;
                            //                entry.Property(t => t.Address).IsModified = true;
                            //                entry.Property(t => t.Tel).IsModified = true;
                            //                entry.Property(t => t.FirstLastName).IsModified = true;
                            //                entities.SaveChanges();
                            //            }
                            //            else
                            //            {
                            //                entities.Customers.Add(tempCustomers);
                            //                entities.SaveChanges();
                            //            }
                            //        }
                            //        break;
                            //}
                            break;
                        }
                    case (Keys.F1): MessageBox.Show("Для добавления или обновления записи нажмите Enter", "F1", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                }
            }
        }

        private void УдалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}