using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
//单抽代码
namespace ChouJiang
{
    public partial class Form2 : Form
    {


         Tools tools2 = new Tools();
        // 指定中奖人
        private Dictionary<string, string> Dict2 = new Dictionary<string, string>
        {
            { "Z","翟昊天"} ,
            { "D","杜伟"},
            { "C","范艳柯"}
        };
        public Form2()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile(@".\images\image1.png");
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // 按键响应必要参数
            this.KeyPreview = true;
            //窗口最大化
            this.WindowState = FormWindowState.Maximized;
            //初始化抽奖人数        
            label4.Text = tools2.FlushJoin();
        }
        //作弊函数
        private void Luck(string str)
        {
            try
            {
                timer1.Enabled = false;
                label1.Text = Dict2[str];
                tools2.SetJoin(this);
                tools2.FlushJoin();
            }
            catch (Exception) { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = tools2.QueryJoinName()[tools2.Get_Random1(tools2.QueryJoinName().Count)].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            label1.Text = tools2.QueryJoinName()[tools2.UniqueValue(tools2.QueryJoinName().Count)].ToString();
            timer1.Enabled = false;
            tools2.SetJoin(this);
            label4.Text = tools2.FlushJoin();
        }
        private void button4_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    Luck(Keys.Z.ToString());
                    break;
                case Keys.D:
                    Luck(Keys.D.ToString());
                    break;
                case Keys.C:
                    Luck(Keys.C.ToString());
                    break;
            }
        }
        private void 三连抽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 形参用来规避 初始化数据库
            Form1 form1 = new Form1("NewForm");
            this.Hide();
            form1.ShowDialog();
            this.Dispose();
            Application.ExitThread();
        }
        private void 五连抽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 from3 = new Form3();
            this.Hide();
            from3.ShowDialog();
            Application.ExitThread();
        }
    }
}
