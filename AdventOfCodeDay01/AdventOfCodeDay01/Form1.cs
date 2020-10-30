using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdventOfCodeDay01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal fueltotal = 0;
            for (int i = 0; i < input_part1.Length; i++)
            {
                fueltotal += (Math.Floor(input_part1[i]/3)-2);
            }
            MessageBox.Show(" " + fueltotal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal fueltotal = 0;
            for (int i = 0; i < input_part1.Length; i++)
            {
                decimal curFuel = (Math.Floor(input_part1[i] / 3) - 2);
                decimal totalFuel = curFuel;
                do
                {
                    decimal temp = (Math.Floor(totalFuel / 3) - 2);
                    curFuel += temp;
                    totalFuel = temp;
                } while (totalFuel > 0);

                fueltotal += curFuel - totalFuel;
            }
            
            MessageBox.Show(" " + fueltotal);
        }

        private decimal[] input_test = new decimal[] {
            100756};

        private decimal[] input_part1 = new decimal[] {
            88397,
            140448,
            79229,
            122289,
            143507,
            71642,
            145178,
            149729,
            104257,
            109287,
            136937,
            131253,
            88847,
            143302,
            104210,
            56054,
            137178,
            134861,
            117151,
            103772,
            135590,
            64319,
            53682,
            101137,
            52772,
            142235,
            88312,
            146564,
            131670,
            74925,
            126276,
            109028,
            95438,
            56083,
            77649,
            135414,
            52079,
            83883,
            92754,
            69122,
            77489,
            142896,
            126195,
            78749,
            133146,
            107841,
            75897,
            70156,
            128501,
            113859,
            64823,
            147935,
            72855,
            139576,
            125827,
            57409,
            113492,
            85048,
            89204,
            68744,
            120464,
            118813,
            102856,
            117750,
            130545,
            65139,
            77010,
            139609,
            88580,
            104355,
            99680,
            82451,
            141198,
            142489,
            121556,
            66616,
            121318,
            149517,
            135978,
            126001,
            70211,
            73221,
            52727,
            82621,
            143301,
            64186,
            75382,
            130742,
            135248,
            129867,
            78189,
            148444,
            95969,
            106317,
            147315,
            81697,
            131555,
            56152,
            105759,
            117769};
    }
}
