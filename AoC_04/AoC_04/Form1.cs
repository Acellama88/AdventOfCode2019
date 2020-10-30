using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoC_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test1()
        {
            int start = 112233;
            int l1 = start / 100000;
            int l2 = start % 100000 / 10000;
            int l3 = start % 10000 / 1000;
            int l4 = start % 1000 / 100;
            int l5 = start % 100 / 10;
            int l6 = start % 10;

            if ((l1 <= l2 && l2 <= l3 && l3 <= l4 && l4 <= l5 && l5 <= l6) &&
                ((l1 == l2 && l2 != l3)  || (l2 == l3 && l3 != l4) || (l3 == l4 && l4 != l5) || (l4 == l5 && l5 != l6) || (l5 == l6)))
                start = 0;
            else
                MessageBox.Show("Test 1 Failure");
        }

        private void test2()
        {
            int start = 123444;
            int l1 = start / 100000;
            int l2 = start % 100000 / 10000;
            int l3 = start % 10000 / 1000;
            int l4 = start % 1000 / 100;
            int l5 = start % 100 / 10;
            int l6 = start % 10;

            if ((l1 <= l2 && l2 <= l3 && l3 <= l4 && l4 <= l5 && l5 <= l6) &&
                ((l1 == l2 && l2 != l3) || (l2 == l3 && l3 != l4) || (l3 == l4 && l4 != l5) || (l4 == l5 && l5 != l6) || (l5 == l6)))
                MessageBox.Show("Test 2 Failure");                
        }

        private void test3()
        {
            int start = 111122;
            int l1 = start / 100000;
            int l2 = start % 100000 / 10000;
            int l3 = start % 10000 / 1000;
            int l4 = start % 1000 / 100;
            int l5 = start % 100 / 10;
            int l6 = start % 10;

            if ((l1 <= l2 && l2 <= l3 && l3 <= l4 && l4 <= l5 && l5 <= l6) &&
                ((l1 == l2 && l2 != l3) || (l2 == l3 && l3 != l4) || (l3 == l4 && l4 != l5) || (l4 == l5 && l5 != l6) || (l5 == l6)))
                start = 0;
            else
                MessageBox.Show("Test 1 Failure");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test1();
            test2();
            test3();
            int start = 130254;
            int stop = 678275;
            int count = 0;
            for(;start <= stop; start++)
            {
                int l1 = start / 100000;
                int l2 = start % 100000 / 10000;
                int l3 = start % 10000 / 1000;
                int l4 = start % 1000 / 100;
                int l5 = start % 100 / 10;
                int l6 = start % 10;
                int[] aInts = new int[] { l1, l2, l3, l4, l5, l6 };
                bool res = false;
                if (l1 <= l2 && l2 <= l3 && l3 <= l4 && l4 <= l5 && l5 <= l6)
                {
                    for (int i = 0; i < aInts.Length; i++)
                    {
                        int total = 0;
                        for (int j = 0; j < aInts.Length; j++)
                        {
                            if (aInts[i] == aInts[j])
                                total++;
                        }
                        if (total == 2)
                            res = true;
                    }
                }
                if(res)
                    count++;
            }
            MessageBox.Show("" + count);
        }
    }
}
