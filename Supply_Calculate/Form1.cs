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
        static int partition =n/ nThread;
        static int[] arrString = new int[n];
        static int[] arrSidrati = new int[n];
        static int[] arrSidrati2 = new int[n];
        static int[] temp = new int[nThread+1];
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
            //arrString[12] = Convert.ToInt32(textBoxE13.Text);


            arrSidrati[0] = Convert.ToInt32(textBox1.Text);
            arrSidrati[1] = Convert.ToInt32(textBoxE2.Text);
            arrSidrati[2] = Convert.ToInt32(textBoxE3.Text);
            arrSidrati[3] = Convert.ToInt32(textBoxE4.Text);
            arrSidrati[4] = Convert.ToInt32(textBoxE5.Text);
            arrSidrati[5] = Convert.ToInt32(textBoxE6.Text);
            arrSidrati[6] = Convert.ToInt32(textBoxE7.Text);
            arrSidrati[7] = Convert.ToInt32(textBoxE8.Text);
            arrSidrati[8] = Convert.ToInt32(textBoxE9.Text);
            arrSidrati[9] = Convert.ToInt32(textBoxE10.Text);
            arrSidrati[10] = Convert.ToInt32(textBoxE11.Text);
            arrSidrati[11] = Convert.ToInt32(textBoxE12.Text);
            //arrSidrati[12] = Convert.ToInt32(textBoxE13.Text);
            arrSidrati2[0] = Convert.ToInt32(textBox1.Text);
            arrSidrati2[1] = Convert.ToInt32(textBoxE2.Text);
            arrSidrati2[2] = Convert.ToInt32(textBoxE3.Text);
            arrSidrati2[3] = Convert.ToInt32(textBoxE4.Text);
            arrSidrati2[4] = Convert.ToInt32(textBoxE5.Text);
            arrSidrati2[5] = Convert.ToInt32(textBoxE6.Text);
            arrSidrati2[6] = Convert.ToInt32(textBoxE7.Text);
            arrSidrati2[7] = Convert.ToInt32(textBoxE8.Text);
            arrSidrati2[8] = Convert.ToInt32(textBoxE9.Text);
            arrSidrati2[9] = Convert.ToInt32(textBoxE10.Text);
            arrSidrati2[10] = Convert.ToInt32(textBoxE11.Text);
            arrSidrati2[11] = Convert.ToInt32(textBoxE12.Text);
            temp[0] = 0;
            Serial_algorithm_Revenue();
            prefix_sum_inPlace_Revenue();
            Serial_algorithm_Expenses();
        }
        //enter
        public void Serial_algorithm_Revenue()
        {
            
            for (int i = 1; i < arrSidrati.Length; i++)
            {
                arrSidrati[i] = arrSidrati[i - 1] + arrSidrati[i];
            }
            int j;
            for (j = 0; j < arrSidrati.Length; j++)
            {
                label10.Text = label10.Text + arrSidrati[j].ToString() + '\n';
            }
            label10.Text = label10.Text + (Convert.ToInt32(textBoxE13.Text) + arrSidrati[--j]).ToString() + '\n';

        }
        public void prefix_sum_inPlace_Revenue()
        {

            Parallel.For(0, nThread, i =>
            {
                sum(i * partition, (i * partition) + partition);
            });
            insert_prefix();

            Parallel.For(0, nThread, i =>
            {
                end(i * partition, (i * partition) + partition);
            });
            int j;
            for (j = 0; j < arrString.Length; j++)
            {
                label11.Text = label11.Text + arrString[j].ToString() + '\n';
            }
            label11.Text = label11.Text +( Convert.ToInt32(textBoxE13.Text)+ arrString[--j]).ToString() + '\n';

        }
        public static void sum(int indexStart, int indexEnd)//חישוב המערך הזמני
        {
            int sum = 0;
            int local = indexEnd / partition-1;
            for (int i = indexStart; i < indexEnd; i++)
            {
                sum += arrString[i];
                arrString[i] = sum;
            }
            temp[local + 1] = arrString[indexEnd - 1];
        }
        public static void insert_prefix()//סכמת המערך הזמני
        {
            prefix[0] = 0;
            for (int i = 1; i < nThread; i++)
            {
                prefix[i] = temp[i - 1] + temp[i];
            }
        }
        public static void end(int indexStart, int indexEnd)//הצעד האחרון
        {
            int local = indexEnd / partition - 1;
            for (int i = indexStart; i < indexEnd; i++)
            {
                arrString[i] += prefix[local];
            }

        }

        //remove

        public void Serial_algorithm_Expenses()
        {

            for (int i = 1; i < arrSidrati2.Length; i++)
            {
                arrSidrati2[i] = arrSidrati2[i - 1] - arrSidrati2[i];
            }
            int j;
            for (j = 0; j < arrSidrati2.Length; j++)
            {
                label49.Text = label49.Text + arrSidrati2[j].ToString() + '\n';
            }
            label49.Text = label10.Text + (Convert.ToInt32(textBoxE13.Text) + arrSidrati2[--j]).ToString() + '\n';

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
