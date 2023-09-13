using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace my_simple_project
{
    public partial class Form1 : Form
    {   
      
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();


            txt_username.Focus();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                try
                {
                    string conn = "Data Source=DESKTOP-HNEA2AS\\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True";
                    SqlConnection conn2 = new SqlConnection(conn);
                    /*
                    using (SqlConnection conn = new SqlConnection(connstring))
                    {

                        conn.Open();
                        string query = "select count(*) from user where 'username='" + txt_username.Text + "' and password='" + txt_password.Text + "'";
                        using (SqlCommand command=new SqlCommand(query,conn))
                        {
                            command.Parameters.AddWithValue("username", txt_username.Text);
                            command.Parameters.AddWithValue ("password", txt_password.Text);
                            int result=(int)command.ExecuteScalar();
                            if (result > 0)
                            {
                                MessageBox.Show("LOGIN SUCCESSFUL!!!!");
                            }
                            else {
                                MessageBox.Show("Invalid username or password!!!");
                                txt_username.Clear();
                                txt_password.Clear();


                                txt_username.Focus();

                                this.Focus();
                            }
                        }
                    }
                    */

                    string uname=txt_username.Text;
                    string pass=txt_password.Text; 
                    string query = "SELECT username,password FROM user WHERE username=" +uname+ " and password=" +pass;
                    //String query = "'select * from user where username='" + txt_username.Text + "' and password='" + txt_password.Text + "'";
                    conn2.Open();
                    // SqlCommand cmd = new SqlCommand(query, conn2);


                    SqlDataAdapter sda = new SqlDataAdapter(query, conn2);

                    // DataTable dt = new DataTable();
                    //
                    //sda.Fill(dt);

                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {


                        MessageBox.Show("LOGIN SUCCESSFUL!!!!");
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!!!");
                        txt_username.Clear();
                        txt_password.Clear();


                        txt_username.Focus();

                        this.Focus();
                    }
                }
                catch (ArithmeticException ex) { 
                    ex.GetBaseException();
                
                }
                


            }
        }

        private bool isvalid()
        {
            if (txt_username.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please Enter valid Username!!", "Error");
                return false;
            }
            else if (txt_password.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please Entwe valid password!!", "Error");
                return false;
            
            }
            return true;    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
