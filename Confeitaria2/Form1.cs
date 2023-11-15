using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Confeitaria2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }
        private void CarregarDadosBanco()
        {
            string conexao = "server=localhost;database=db_confeitaria;;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from tb_pedido_item", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvList.DataSource = dt;

        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtQuant.Text = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtVal.Text = dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=db_confeitaria;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("update tecnico set nome_tec='" + txtId.Text + "', cargo='" + txtQuant.Text + "' where id_tec=" + txtVal.Text, conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Dados alterados!!!");
            txtId.Text = "";
            txtQuant.Text = "";
            txtVal.Text = "";
            CarregarDadosBanco();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
