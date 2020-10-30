using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoC_Day02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int loc = 0;

        private int location(int offset)
        {
            return input_part1[loc + offset];
        }

        private int location_part2(int offset)
        {
            return input_part2[loc + offset];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int opCode = 0;
            while ((opCode = input_part1[loc]) == 99 || opCode == 1 || opCode == 2)
            {
                if (opCode == 99)
                    break;
                if (opCode == 1)
                {
                    int total = input_part1[location(1)] + input_part1[location(2)];
                    input_part1[location(3)] = total;
                }
                else if (opCode == 2)
                {
                    int total = input_part1[location(1)] * input_part1[location(2)];
                    input_part1[location(3)] = total;
                }
                else
                    MessageBox.Show("ERROR");
                loc += 4;
            }
            if (opCode == 99)
                MessageBox.Show("Done");
            else
                MessageBox.Show("Fault");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int opCode = 0;
            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    input_part2 = (int[]) input_part1.Clone();
                    input_part2[1] = i;
                    input_part2[2] = j;
                    loc = 0;
                    while ((opCode = input_part2[loc]) == 99 || opCode == 1 || opCode == 2)
                    {
                        if (opCode == 99)
                            break;
                        if (opCode == 1)
                        {
                            int total = input_part2[location_part2(1)] + input_part2[location_part2(2)];
                            input_part2[location_part2(3)] = total;
                        }
                        else if (opCode == 2)
                        {
                            int total = input_part2[location_part2(1)] * input_part2[location_part2(2)];
                            input_part2[location_part2(3)] = total;
                        }
                        else
                            MessageBox.Show("ERROR");
                        loc += 4;
                    }
                    if (opCode == 99 && input_part2[0] == 19690720)
                    {
                        MessageBox.Show("Done: " + input_part2[0] + ", Output: " + ((100 * i) + j));
                    }
                    else if (opCode != 99)
                        break;
                    else
                        continue;
                }
            }
            if(opCode != 99)
                MessageBox.Show("Fault");
        }

        private int[] input_part2;

        private int[] input_part1 = new int[] {
            1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,6,19,23,2,23,6,27,1,5,27,31,1,31,9,35,2,10,35,39,1,5,39,43,2,43,10,47,1,47,6,51,2,51,6,55,2,55,13,59,2,6,59,63,1,63,5,67,1,6,67,71,2,71,9,75,1,6,75,79,2,13,79,83,1,9,83,87,1,87,13,91,2,91,10,95,1,6,95,99,1,99,13,103,1,13,103,107,2,107,10,111,1,9,111,115,1,115,10,119,1,5,119,123,1,6,123,127,1,10,127,131,1,2,131,135,1,135,10,0,99,2,14,0,0};

        
    }
}
