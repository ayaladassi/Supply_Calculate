using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Supply_Calculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int n = 12;
        static int nThread = 3;
        static int partition = n / nThread;
        static int[] arrString = new int[n];
        static int[] arrString2 = new int[n];
        static int[] arrayt = new int[n];

        static int[] temp = new int[nThread + 1];
        static int[] prefix = new int[nThread];
        private void button1_Click_1(object sender, EventArgs e)
        {
            arrString[0] = Convert.ToInt32(textBox1.Text);
            arrString[1] = Convert.ToInt32(textBoxE2.Text);
            arrString[2] = Convert.ToInt32(textBoxE3.Text);
            arrString[3] = Convert.ToInt32(textBoxE4.Text);
            arrString[4] = Convert.ToInt32(textBoxE5.Text);
            arrString[5] = Convert.ToInt32(textBoxE6.Text);
            arrString[6] = Convert.ToInt32(textBoxE7.Text);
            arrString[7] = Convert.ToInt32(textBoxE8.Text);
            arrString[8] = Convert.ToInt32(textBoxE9.Text);
            arrString[9] = Convert.ToInt32(textBoxE10.Text);
            arrString[10] = Convert.ToInt32(textBoxE11.Text);
            arrString[11] = Convert.ToInt32(textBoxE12.Text);

            arrString2[0] = Convert.ToInt32(textBox1.Text);
            arrString2[1] = Convert.ToInt32(textBoxR2.Text);
            arrString2[2] = Convert.ToInt32(textBoxR3.Text);
            arrString2[3] = Convert.ToInt32(textBoxR4.Text);
            arrString2[4] = Convert.ToInt32(textBoxR5.Text);
            arrString2[5] = Convert.ToInt32(textBoxR6.Text);
            arrString2[6] = Convert.ToInt32(textBoxR7.Text);
            arrString2[7] = Convert.ToInt32(textBoxR8.Text);
            arrString2[8] = Convert.ToInt32(textBoxR9.Text);
            arrString2[9] = Convert.ToInt32(textBoxR10.Text);
            arrString2[10] = Convert.ToInt32(textBoxR11.Text);
            arrString2[11] = Convert.ToInt32(textBoxR12.Text);

            temp[0] = 0;
            //to
            arrayt = arrto();

            //enter
            prefix_sum_inPlace(arrString);
            int j;
            for (j = 0; j < arrString.Length; j++)
            {
                label11.Text = label11.Text + arrString[j].ToString() + '\n';
            }
            label11.Text = label11.Text + (Convert.ToInt32(textBoxE13.Text) + arrString[--j]).ToString() + '\n';

           //remove
            prefix_sum_inPlace(arrString2);
         
            for (j = 0; j < arrString2.Length; j++)
            {
                label96.Text = label96.Text + arrString2[j].ToString() + '\n';
            }
            label96.Text = label96.Text + (arrString2[--j] + Convert.ToInt32(textBoxR13.Text)).ToString() + '\n';
            //to
            prefix_sum_inPlace(arrayt);
            for (j = 0; j < arrayt.Length; j++)
            {
                labelM.Text = labelM.Text + arrayt[j].ToString() + '\n';
            }
            labelM.Text = labelM.Text + (arrayt[--j] + Convert.ToInt32(textBoxR13.Text)+ Convert.ToInt32(textBoxE13.Text)).ToString() + '\n';
           

        }
    
        public void prefix_sum_inPlace(int[]array)
        {

            Parallel.For(0, nThread, i =>
            {
                sum(array,i * partition, (i * partition) + partition);
            });
            insert_prefix();

            Parallel.For(0, nThread, i =>
            {
                end(array,i * partition, (i * partition) + partition);
            });
           
        }
        public static void sum(int []array,int indexStart, int indexEnd)//חישוב המערך הזמני
        {
            int sum = 0;
            int local = indexEnd / partition - 1;
            for (int i = indexStart; i < indexEnd; i++)
            {
                sum += array[i];
                array[i] = sum;
            }
            temp[local + 1] = array[indexEnd - 1];
        }
        public static void insert_prefix()//סכמת המערך הזמני
        {
            prefix[0] = 0;
            for (int i = 1; i < nThread; i++)
            {
                prefix[i] = temp[i - 1] + temp[i];
            }
        }
        public static void end(int[]array ,int indexStart, int indexEnd)//הצעד האחרון
        {
            int local = indexEnd / partition - 1;
            for (int i = indexStart; i < indexEnd; i++)
            {
                array[i] += prefix[local];
            }

        } 
        //to
        public static int[] arrto()
        {
            arrayt[0] = arrString[0];
            for (int i = 1; i < arrString.Length; i++)
            {
                arrayt[i] = arrString[i] + arrString2[i];
            }
            return arrayt;
        }







































        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }
    }
}
