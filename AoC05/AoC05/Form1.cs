using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AoC05
{
    public partial class Form1 : Form
    {
        public int instPtr = 0;
        public int opCode = 0;
        public int offset = 0;
        public enum paramModes
        {
            POSITION_MODE = 0,
            IMMEDIATE_MODE = 1
        };
        public paramModes param1 = paramModes.POSITION_MODE;
        public paramModes param2 = paramModes.POSITION_MODE;
        public paramModes param3 = paramModes.POSITION_MODE;

        public Form1()
        {
            InitializeComponent();
        }

        public void splitInstruction(int instruction)
        {
            opCode = instruction % 100;
            param1 = (paramModes) (instruction % 1000 / 100);
            param2 = (paramModes) (instruction % 10000 / 1000);
            param3 = (paramModes) (instruction % 100000 / 10000);
        }

        public int getParameter(int offset, int param, paramModes mode)
        {
            if (mode == paramModes.IMMEDIATE_MODE)
                return instructionData[instPtr + offset];
            else if (mode == paramModes.POSITION_MODE)
                return instructionData[instructionData[instPtr + offset]];
            MessageBox.Show("Fault: Invalid Parameter Mode");
            return -1;
        }

        public int getParameter(int param, paramModes mode)
        {
            if (mode == paramModes.IMMEDIATE_MODE)
                return instructionData[instPtr + param];
            else if (mode == paramModes.POSITION_MODE)
                return instructionData[instructionData[instPtr + param]];
            MessageBox.Show("Fault: Invalid Parameter Mode");
            return -1;
        }

        public void setParameter(int param, int value)
        {
            instructionData[instructionData[instPtr + param]] = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            do
            {
                int value1 = 0;
                int value2 = 0;
                int value3 = 0;
                splitInstruction(instructionData[instPtr]);
                switch (opCode)
                {
                    case 1: //Add
                        offset = 4;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        value3 = value1 + value2;
                        setParameter(3, value3);
                        break;
                    case 2: //Multiply
                        offset = 4;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        value3 = value1 * value2;
                        setParameter(3, value3);
                        break;
                    case 3: //Input
                        if (inputData == null || inputLoc >= inputData.Length)
                        {
                            offset = 2;
                            Form2 getValue = new Form2();
                            getValue.ShowDialog();
                            value1 = getValue.Value;
                            getValue.Dispose();
                            setParameter(1, value1);
                        }
                        else
                        {
                            //inputList
                        }
                        break;
                    case 4: //Output
                        offset = 2;
                        value1 = getParameter(1, param1);
                        MessageBox.Show("" + value1);
                        break;
                    case 5: //jump-if-true
                        offset = 3;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        if (value1 != 0)
                        {
                            instPtr = value2;
                            offset = 0;
                        }
                        break;
                    case 6: //jump-if-false
                        offset = 3;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        if (value1 == 0)
                        {
                            instPtr = value2;
                            offset = 0;
                        }
                        break;
                    case 7: //Less Than
                        offset = 4;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        if (value1 < value2)
                            setParameter(3, 1);
                        else
                            setParameter(3, 0);
                        break;
                    case 8: //Equal
                        offset = 4;
                        value1 = getParameter(1, param1);
                        value2 = getParameter(2, param2);
                        if (value1 == value2)
                            setParameter(3, 1);
                        else
                            setParameter(3, 0);
                        break;
                    case 99: //break
                        break;
                    default:
                        MessageBox.Show("Fault: Missing opCode");
                        break;
                }
                instPtr = instPtr + offset;
            } while (opCode != 99);
            MessageBox.Show("Complete");
        }

        /*private int[] instructionData = new int[] {
            3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99};*/
        private string[] inputOptions = new string[] {
                "1,2,3,4,5",
                "2,1,3,4,5",
                "3,1,2,4,5",
                "1,3,2,4,5",
                "2,3,1,4,5",
                "3,2,1,4,5",
                "3,2,4,1,5",
                "2,3,4,1,5",
                "4,3,2,1,5",
                "3,4,2,1,5",
                "2,4,3,1,5",
                "4,2,3,1,5",
                "4,1,3,2,5",
                "1,4,3,2,5",
                "3,4,1,2,5",
                "4,3,1,2,5",
                "1,3,4,2,5",
                "3,1,4,2,5",
                "2,1,4,3,5",
                "1,2,4,3,5",
                "4,2,1,3,5",
                "2,4,1,3,5",
                "1,4,2,3,5",
                "4,1,2,3,5",
                "5,1,2,3,4",
                "1,5,2,3,4",
                "2,5,1,3,4",
                "5,2,1,3,4",
                "1,2,5,3,4",
                "2,1,5,3,4",
                "2,1,3,5,4",
                "1,2,3,5,4",
                "3,2,1,5,4",
                "2,3,1,5,4",
                "1,3,2,5,4",
                "3,1,2,5,4",
                "3,5,2,1,4",
                "5,3,2,1,4",
                "2,3,5,1,4",
                "3,2,5,1,4",
                "5,2,3,1,4",
                "2,5,3,1,4",
                "1,5,3,2,4",
                "5,1,3,2,4",
                "3,1,5,2,4",
                "1,3,5,2,4",
                "5,3,1,2,4",
                "3,5,1,2,4",
                "4,5,1,2,3",
                "5,4,1,2,3",
                "1,4,5,2,3",
                "4,1,5,2,3",
                "5,1,4,2,3",
                "1,5,4,2,3",
                "1,5,2,4,3",
                "5,1,2,4,3",
                "2,1,5,4,3",
                "1,2,5,4,3",
                "5,2,1,4,3",
                "2,5,1,4,3",
                "2,4,1,5,3",
                "4,2,1,5,3",
                "1,2,4,5,3",
                "2,1,4,5,3",
                "4,1,2,5,3",
                "1,4,2,5,3",
                "5,4,2,1,3",
                "4,5,2,1,3",
                "2,5,4,1,3",
                "5,2,4,1,3",
                "4,2,5,1,3",
                "2,4,5,1,3",
                "3,4,5,1,2",
                "4,3,5,1,2",
                "5,3,4,1,2",
                "3,5,4,1,2",
                "4,5,3,1,2",
                "5,4,3,1,2",
                "5,4,1,3,2",
                "4,5,1,3,2",
                "1,5,4,3,2",
                "5,1,4,3,2",
                "4,1,5,3,2",
                "1,4,5,3,2",
                "1,3,5,4,2",
                "3,1,5,4,2",
                "5,1,3,4,2",
                "1,5,3,4,2",
                "3,5,1,4,2",
                "5,3,1,4,2",
                "4,3,1,5,2",
                "3,4,1,5,2",
                "1,4,3,5,2",
                "4,1,3,5,2",
                "3,1,4,5,2",
                "1,3,4,5,2",
                "2,3,4,5,1",
                "3,2,4,5,1",
                "4,2,3,5,1",
                "2,4,3,5,1",
                "3,4,2,5,1",
                "4,3,2,5,1",
                "4,3,5,2,1",
                "3,4,5,2,1",
                "5,4,3,2,1",
                "4,5,3,2,1",
                "3,5,4,2,1",
                "5,3,4,2,1",
                "5,2,4,3,1",
                "2,5,4,3,1",
                "4,5,2,3,1",
                "5,4,2,3,1",
                "2,4,5,3,1",
                "4,2,5,3,1",
                "3,2,5,4,1",
                "2,3,5,4,1",
                "5,3,2,4,1",
                "3,5,2,4,1",
                "2,5,3,4,1",
                "5,2,3,4,1"
        };

        private string[] inputData;
        private int inputLoc;

        private int[] instructionData = new int[] {
            3,225,1,225,6,6,1100,1,238,225,104,0,1102,31,68,225,1001,13,87,224,1001,224,-118,224,4,224,102,8,223,223,1001,224,7,224,1,223,224,223,1,174,110,224,1001,224,-46,224,4,224,102,8,223,223,101,2,224,224,1,223,224,223,1101,13,60,224,101,-73,224,224,4,224,102,8,223,223,101,6,224,224,1,224,223,223,1101,87,72,225,101,47,84,224,101,-119,224,224,4,224,1002,223,8,223,1001,224,6,224,1,223,224,223,1101,76,31,225,1102,60,43,225,1102,45,31,225,1102,63,9,225,2,170,122,224,1001,224,-486,224,4,224,102,8,223,223,101,2,224,224,1,223,224,223,1102,29,17,224,101,-493,224,224,4,224,102,8,223,223,101,1,224,224,1,223,224,223,1102,52,54,225,1102,27,15,225,102,26,113,224,1001,224,-1560,224,4,224,102,8,223,223,101,7,224,224,1,223,224,223,1002,117,81,224,101,-3645,224,224,4,224,1002,223,8,223,101,6,224,224,1,223,224,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,8,226,677,224,102,2,223,223,1005,224,329,1001,223,1,223,1108,677,226,224,102,2,223,223,1006,224,344,101,1,223,223,108,677,226,224,102,2,223,223,1006,224,359,101,1,223,223,7,677,226,224,102,2,223,223,1005,224,374,101,1,223,223,1007,226,677,224,102,2,223,223,1005,224,389,101,1,223,223,8,677,677,224,102,2,223,223,1006,224,404,1001,223,1,223,1007,677,677,224,1002,223,2,223,1006,224,419,101,1,223,223,1108,677,677,224,1002,223,2,223,1005,224,434,1001,223,1,223,1107,226,677,224,102,2,223,223,1005,224,449,101,1,223,223,107,226,226,224,102,2,223,223,1006,224,464,101,1,223,223,1108,226,677,224,1002,223,2,223,1005,224,479,1001,223,1,223,7,677,677,224,102,2,223,223,1006,224,494,1001,223,1,223,1107,677,226,224,102,2,223,223,1005,224,509,101,1,223,223,107,677,677,224,1002,223,2,223,1006,224,524,101,1,223,223,1008,677,677,224,1002,223,2,223,1006,224,539,101,1,223,223,7,226,677,224,1002,223,2,223,1005,224,554,101,1,223,223,108,226,226,224,1002,223,2,223,1006,224,569,101,1,223,223,1008,226,677,224,102,2,223,223,1005,224,584,101,1,223,223,8,677,226,224,1002,223,2,223,1005,224,599,101,1,223,223,1007,226,226,224,1002,223,2,223,1005,224,614,101,1,223,223,1107,226,226,224,1002,223,2,223,1006,224,629,101,1,223,223,107,677,226,224,1002,223,2,223,1005,224,644,1001,223,1,223,1008,226,226,224,1002,223,2,223,1006,224,659,101,1,223,223,108,677,677,224,1002,223,2,223,1005,224,674,1001,223,1,223,4,223,99,226};

    }
}
