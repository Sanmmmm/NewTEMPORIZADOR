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

namespace TEMPORIZADOR
{
    public partial class Form1 : Form
    {
        int tempo = 0;
        int minuto = 0;
        int segundo = 0;
        int horas = 0;
        bool isPaused = false;
        int zerar;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >0)
            {
                pictureBox1.Visible = false;
                tempo = Convert.ToInt16(textBox1.Text);
                if (tempo >= 60)
                {

                    minuto = tempo / 60;
                    segundo = tempo % 60;
                }
                else
                {
                    minuto = 0;
                    segundo = tempo;
                }
                label1.Text = minuto.ToString().PadLeft(2, '0') + ":" + segundo.ToString().PadLeft(2, '0');
                timer1.Enabled = true;
                button7.Text = "PAUSE";


            }
            else
            {
                MessageBox.Show("Entre com um digito" );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            timer2.Enabled = false;// Para o timer
            isPaused = false; // Garante que o estado de pausa é redefinido
            label1.Text = "00:00:00"; // Reseta o display para zero

            // Redefine todas as variáveis de tempo
            segundo = 0;
            minuto = 0;
            horas = 0;

            // Limpa o conteúdo da caixa de texto (se for um cronômetro de contagem regressiva)
            textBox1.Text = "";

            // Opcional: Atualiza o texto do botão de pausar/retomar
            button7.Text = "PAUSE"; // Caso o cronômetro/temporizador esteja pausado
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
                segundo--;
                if (minuto > 0)
                {
                    if (segundo < 0)
                    {
                        segundo = 59;
                        minuto--;
                    }
                }
                label1.Text = horas.ToString().PadLeft(2, '0') + ":" + minuto.ToString().PadLeft(2, '0') + ":" + segundo.ToString().PadLeft(2, '0');
                if (minuto == 0 && segundo == 0)
                {
                    timer1.Enabled = false;
                    pictureBox1.Visible = true;

                }
            
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            pictureBox1.Visible = false;
            timer2.Enabled = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            segundo++;
            if (segundo == 60)
            {
                minuto++;
                segundo = 0;
            }
            if (minuto == 60)
            {
                horas++;
                minuto = 0;
            }
            label1.Text = horas.ToString().PadLeft(2, '0') + ":" + minuto.ToString().PadLeft(2, '0') + ":" + segundo.ToString().PadLeft(2, '0');
            if (minuto == 0 && segundo == 0)
            {
                timer2.Enabled = false;
                pictureBox1.Visible = true;

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                isPaused = !isPaused; // Toggle pause state
                if (isPaused)
                {
                    timer2.Enabled = false;// Stop the timer
                    button7.Text = "RETOMAR"; // Change button text to "Resume"
                }
                else
                {

                    timer2.Enabled = true;// Resume the timer
                    button7.Text = "PAUSE"; // Change button text to "Pause"
                }
            }
            else
            {
                isPaused = !isPaused; // Toggle pause state
                if (isPaused)
                {
                    timer1.Enabled = false;
                    // Stop the timer
                    button7.Text = "RETOMAR"; // Change button text to "Resume"
                }
                else
                {
                    timer1.Enabled = true;
                    // Resume the timer
                    button7.Text = "PAUSE"; // Change button text to "Pause"
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        { if (textBox1.Text.Length > 0)
            {
               
                zerar = Convert.ToInt16(textBox1.Text);
                if (zerar >= 60)
                {

                    minuto = zerar / 60;
                    segundo = zerar % 60;
                }
                else
                {
                    minuto = 0;
                    segundo = zerar;
                }
                label1.Text = minuto.ToString().PadLeft(2, '0') + ":" + segundo.ToString().PadLeft(2, '0');
                timer1.Enabled = false;

                textBox1.Text = Convert.ToString(zerar);
                button7.Text = "RETOMAR";
            }
            else
            {
        
                timer2.Enabled = false;
                label1.Text = "00:00:00";
                segundo = 0;
                minuto = 0;
                horas = 0;
                button7.Text = "PAUSE";
            }
        }
    }

 }


