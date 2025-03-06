using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingMeServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pi_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = Jogo.versao;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String retorno = Jogo.ListarPartidas("T");

            retorno = retorno.Replace("\r", " ");
            retorno = retorno.Substring(0, retorno.Length - 1);
            String[] partidas = retorno.Split('\n');

            listBox1.Items.Clear();
            for (int i = 0; i < partidas.Length; i++)
            {

                listBox1.Items.Add(partidas[i]);
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string partida = listBox1.SelectedItem.ToString();
            string[] dadosPartidas = partida.Split(',');
            int idPartida = Convert.ToInt32(dadosPartidas[0]);
            string nomePartida = dadosPartidas[1];
            string data = dadosPartidas[2];

            label1.Text = idPartida.ToString();
            label2.Text = nomePartida;
            label3.Text = data;

            string retorno = Jogo.ListarJogadores(idPartida);
            if (!string.IsNullOrEmpty(retorno) && retorno.Length >= 4 && retorno.Substring(0, 4) == "ERRO")
            {
                MessageBox.Show("Ocorreu um erro: \n" + retorno);
            }
            else
            {
                retorno = retorno.Replace("\r", "");
                string[] jogadores = retorno.Split('\n');

                listBox2.Items.Clear();
                for (int i = 0; i < jogadores.Length; i++)
                {
                    listBox2.Items.Add(jogadores[i]);
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void TxtNomedaPartida_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IddaPardita_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Validação dos dados de entrada
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("O nome da partida não pode estar vazio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("A data da partida não pode estar vazia.");
                return;
            }


            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("O campo adicional não pode estar vazio.");
                return;
            }

            // Criação da partida
            string partida = Jogo.CriarPartida(textBox2.Text, textBox3.Text, textBox4.Text);

            if (!string.IsNullOrEmpty(partida))
            {
                MessageBox.Show("Partida criada com sucesso: " + partida);


                // Atualizar o campo IdPartida com o ID da nova partida
                string[] dadosPartida = partida.Split(',');
                if (dadosPartida.Length > 0)
                {
                    IdPartida.Text = dadosPartida[0];
                }
            }
            else
            {
                MessageBox.Show("Erro ao criar a partida.");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idPartida;
            if (int.TryParse(IdPartida.Text, out idPartida))
            {
                string Jogador = Jogo.Entrar(idPartida, textBox5.Text, textBox3.Text);
            }
            else
            {
                MessageBox.Show("ID da partida inválido.");
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
