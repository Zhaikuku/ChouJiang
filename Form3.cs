using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// 五连抽奖
namespace ChouJiang
{
    public partial class Form3 : Form
    {


        Dictionary<string, List<object>> Dict3 = new Dictionary<string, List<object>>
        {
                { "Z", new List<object> {  "杜伟", "范艳珂", "李浩鹏","昊天","天天"} },
                { "X", new List<object> { "陈富民", "陈良", "杨娟丽", "昊天", "天tian" } },
                { "C", new List<object> { "李玉田", "刘香玲", "宋婉婉" ,"昊tian", "天填" } }
        };


         Tools  tools3 = new Tools();

        public Form3()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile(@".\images\image1.png");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // 按键响应必要参数
            this.KeyPreview = true;
            //窗口最大化
            this.WindowState = FormWindowState.Maximized;
            label4.Text = tools3.FlushJoin();
        }

        private void 单抽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 from2 = new Form2();
            this.Hide();
            from2.ShowDialog();
            Application.ExitThread();

        }

        private void 三连抽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 from1 = new Form1("NewForm");
            this.Hide();
            from1.ShowDialog();
            Application.ExitThread();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            var Data = tools3.QueryJoinName();
            int Number = tools3.QueryJoinName().Count;

            label1.Text = Data[tools3.UniqueValue(Number)].ToString();
            label2.Text = Data[tools3.UniqueValue(Number)].ToString();
            label3.Text = Data[tools3.UniqueValue(Number)].ToString();
            label5.Text = Data[tools3.UniqueValue(Number)].ToString();
            label6.Text = Data[tools3.UniqueValue(Number)].ToString();
            timer1.Enabled = false;
            tools3.SetJoin(this);
            label4.Text = tools3.FlushJoin();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                label1.Text = tools3.QueryJoinName()[tools3.Get_Random1(tools3.QueryJoinName().Count) + 1 ].ToString();
                label2.Text = tools3.QueryJoinName()[tools3.Get_Random1(tools3.QueryJoinName().Count) + 2 ].ToString();
                label3.Text = tools3.QueryJoinName()[tools3.Get_Random1(tools3.QueryJoinName().Count) + 3 ].ToString();
                label5.Text = tools3.QueryJoinName()[tools3.Get_Random1(tools3.QueryJoinName().Count) - 2  ].ToString();
                label6.Text = tools3.QueryJoinName()[tools3.Get_Random1(tools3.QueryJoinName().Count) - 3  ].ToString();
            }

            catch (System.Exception) { }
            finally {  }

        }

        private void button4_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    Luck(Keys.Z.ToString());
                    break;
                case Keys.X:
                    Luck(Keys.X.ToString());
                    break;
                case Keys.C:
                    Luck(Keys.C.ToString());
                    break;
            }
        }




        private void Luck(string keysValues)
        {
            label1.Text = Dict3[keysValues][0].ToString();
            label2.Text = Dict3[keysValues][1].ToString();
            label3.Text = Dict3[keysValues][2].ToString();
            label5.Text = Dict3[keysValues][3].ToString();
            label6.Text = Dict3[keysValues][4].ToString();
            tools3.SetJoin(this);
            label4.Text = tools3.FlushJoin();
            timer1.Enabled = false;
        }
    }
}
