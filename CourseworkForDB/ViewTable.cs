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
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\C#\CourseworkForDB\CourseworkForDB\CourseWork.mdf;Integrated Security=True;Connect Timeout=30");
        Thread AppExit = new Thread(CloseAndExit);

        public DataGridViewComboBoxCell boxCell;

        public Contract tempContract;
        public Writer tempWriter;
        public Books tempBooks;
        public Orders tempOrders;
        public Customers tempCustomers;

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
                    if (reader.GetString(0).Contains("sys"))
                        continue;
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
            SetBoxCell(toolStripComboBox1.SelectedItem.ToString(), ref dataGridView1, ref boxCell);
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
            Enabled = false;
            Cursor = Cursors.WaitCursor;
            boxCell.ReadOnly = false;
            
            dataGridView1.ReadOnly = false;
            включеноToolStripMenuItem.Enabled = false;
            отключеноToolStripMenuItem.Enabled = true;

            Enabled = true;
            Cursor = Cursors.Default;
        }

        private void ОтключеноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Cursor = Cursors.WaitCursor;
            boxCell.ReadOnly = true;

            dataGridView1.ReadOnly = true;
            включеноToolStripMenuItem.Enabled = true;
            отключеноToolStripMenuItem.Enabled = false;

            Enabled = true;
            Cursor = Cursors.Default;
        }

        public static void SetBoxCell(string table, ref DataGridView dataGrid, ref DataGridViewComboBoxCell boxCell)
        {
            switch (table)
            {
                case "Contract":
                    {
                        dataGrid.ColumnCount += 1;
                        dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = "IdContract";
                        boxCell = new DataGridViewComboBoxCell { AutoComplete = true };
                        GetNoteForeignTable("Contract",ref boxCell);
                        break;
                    }
                case "Writer":
                    {
                        dataGrid.ColumnCount += 1;
                        dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = "IdWriter";
                        boxCell = new DataGridViewComboBoxCell { AutoComplete = true };
                        GetNoteForeignTable("Writer", ref boxCell);
                        break;
                    }
                case "Books":
                    {
                        break;
                    }
                case "Orders":
                    {
                        break;
                    }
                case "Customers":
                    {
                        break;
                    }
            }
        }

        //constructor
        public static void GetNoteForeignTable(string tableName, ref DataGridViewComboBoxCell boxCell)
        {
            switch (tableName)
            {
                case "Contract":
                    {
                        foreach (var t in model.Writer)
                            boxCell.Items.AddRange(t.Id);

                        break;
                    }
                case "Writer":
                    {
                        foreach (var t in model.Contract)
                            boxCell.Items.AddRange(t.Id);

                        break;
                    }
                    //case ""
            }

        }

        private void DataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.ReadOnly == false)
            {


                switch (e.KeyData)
                {
                    case (Keys.Enter):
                        {
                            this.Enabled = false;
                            this.Cursor = Cursors.WaitCursor;
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            int index = dataGridView1.CurrentRow.Index-1;
                            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                                dic.Add(dataGridView1.Columns[i].HeaderText, dataGridView1.Rows[index].Cells[i].Value.ToString());

                            switch (toolStripComboBox1.SelectedItem.ToString())
                            {
                                case "Contract":
                                    {
                                        tempContract = new Contract
                                        {
                                            ContractTerminationDate = Convert.ToDateTime(dic["ContractTerminationDate"]),
                                            DateOfContract = Convert.ToDateTime(dic["DateOfContract"]),
                                            LengthOfContract = int.Parse(dic["LengthOfContract"]),
                                            StateContract = Convert.ToBoolean(dic["StateContract"]),
                                            Id = int.Parse(dic["Id"]),
                                        };
                                        if (model.Contract.Any(t => t.Id == tempContract.Id))
                                        {
                                            model.Contract.Attach(tempContract);
                                            model.Entry(tempContract).State = System.Data.Entity.EntityState.Modified;

                                            //var entry = model.Entry(tempContract);
                                            //entry.Property(t => t.ContractTerminationDate).IsModified = true;
                                            //entry.Property(t => t.DateOfContract).IsModified = true;
                                            //entry.Property(t => t.LengthOfContract).IsModified = true;
                                            //entry.Property(t => t.StateContract).IsModified = true;
                                            //entry.Property(t => t.Id).IsModified = true;
                                            model.SaveChanges();
                                        }
                                        else
                                        {
                                            model.Contract.Add(tempContract);
                                            model.SaveChanges();
                                        }
                                        break;
                                    }
                                case "Writer":
                                    {
                                        tempWriter = new Writer
                                        {
                                            FirstName = dic["FirstName"],
                                            LastName = dic["LastName"],
                                            Patronymic = dic["Patronymic"],
                                            Address = dic["Address"],
                                            Telephone = dic["Telephone"],
                                            Id = int.Parse( dic["Id"]),

                                        };
                                        if (model.Writer.Any(t => t.Id == tempWriter.Id))
                                        {
                                            model.Writer.Attach(tempWriter);
                                            model.Entry(tempWriter).State = System.Data.Entity.EntityState.Modified;

                                            //var entry = model.Entry(tempWriter);
                                            //entry.Property(t => t.FirstName).IsModified = true;
                                            //entry.Property(t => t.LastName).IsModified = true;
                                            //entry.Property(t => t.Patronymic).IsModified = true;
                                            //entry.Property(t => t.Address).IsModified = true;
                                            //entry.Property(t => t.Telephone).IsModified = true;
                                            //entry.Property(t => t.Id).IsModified = true;
                                            model.SaveChanges();
                                        }
                                        else
                                        {
                                            model.Writer.Add(tempWriter);
                                            model.SaveChanges();
                                        }
                                    }
                                    break;
                                case "Books":
                                    {
                                        tempBooks = new Books
                                        {
                                            BookChiper = dic["BookChiper"],
                                            Name = dic["Name"],
                                            Printing = int.Parse(dic["Printing"]),
                                            PrintDate = Convert.ToDateTime(dic["PrintDate"]),
                                            CostPrice = int.Parse(dic["CostPrice"]),
                                            SellingPrice = int.Parse(dic["SellingPrice"]),
                                            Fee = int.Parse(dic["Fee"]),
                                            Id =int.Parse( dic["Id"]),
                                            IdOrders =int.Parse( dic["IdOrders"])
                                        };
                                        if (model.Books.Any(t => t.Id == tempBooks.Id))
                                        {
                                            model.Books.Attach(tempBooks);
                                            model.Entry(tempBooks).State = System.Data.Entity.EntityState.Modified;

                                            //var entry = model.Entry(tempBooks);
                                            //entry.Property(t => t.BookChiper).IsModified = true;
                                            //entry.Property(t => t.Name).IsModified = true;
                                            //entry.Property(t => t.Printing).IsModified = true;
                                            //entry.Property(t => t.PrintDate).IsModified = true;
                                            //entry.Property(t => t.CostPrice).IsModified = true;
                                            //entry.Property(t => t.SellingPrice).IsModified = true;
                                            //entry.Property(t => t.Fee).IsModified = true;
                                            //entry.Property(t => t.Id).IsModified = true;
                                            //entry.Property(t => t.IdOrders).IsModified = true;
                                            model.SaveChanges();
                                        }
                                        else
                                        {
                                            model.Books.Add(tempBooks);
                                            model.SaveChanges();
                                        }
                                    }
                                    break;
                                case "Orders":
                                    {
                                        tempOrders = new Orders
                                        {
                                            Id = int.Parse(dic["Id"]),
                                            OrderDate = Convert.ToDateTime(dic["OrderDate"]),
                                            OrderExecutionDate = Convert.ToDateTime(dic["OrderExecutionDate"]),
                                            BookCount = int.Parse(dic["BookCount"])
                                        };
                                        if (model.Orders.Any(t => t.Id == tempOrders.Id))
                                        {
                                            model.Orders.Attach(tempOrders);
                                            model.Entry(tempOrders).State = System.Data.Entity.EntityState.Modified;

                                            //var entry = model.Entry(tempOrders);
                                            //entry.Property(t => t.Id).IsModified = true;
                                            //entry.Property(t => t.OrderDate).IsModified = true;
                                            //entry.Property(t => t.OrderExecutionDate).IsModified = true;
                                            //entry.Property(t => t.BookCount).IsModified = true;
                                            model.SaveChanges();
                                        }
                                        else
                                        {
                                            model.Orders.Add(tempOrders);
                                            model.SaveChanges();
                                        }
                                    }
                                    break;
                                case "Customers":
                                    {
                                        tempCustomers = new Customers
                                        {
                                            CustomerName = dic["CustomerName"],
                                            Address = dic["Address"],
                                            Telephone = dic["Telephone"],
                                            FirstLastName = dic["FirstLastName"],
                                            Id = int.Parse(dic["Id"])
                                        };
                                        if (model.Customers.Any(t => t.Id == tempCustomers.Id))
                                        {
                                            model.Customers.Attach(tempCustomers);
                                            model.Entry(tempCustomers).State = System.Data.Entity.EntityState.Modified;

                                            //var entry = model.Entry(tempCustomers);
                                            //entry.Property(t => t.CustomerName).IsModified = true;
                                            //entry.Property(t => t.Address).IsModified = true;
                                            //entry.Property(t => t.Telephone).IsModified = true;
                                            //entry.Property(t => t.FirstLastName).IsModified = true;
                                            //entry.Property(t => t.Id).IsModified = true;
                                            model.SaveChanges();
                                        }
                                        else
                                        {
                                            model.Customers.Add(tempCustomers);
                                            model.SaveChanges();
                                        }
                                    }
                                    break;

                            }
                            this.Enabled = true;
                            this.Cursor = Cursors.Default; 
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