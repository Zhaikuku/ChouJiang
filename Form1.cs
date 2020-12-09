using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// 三连抽代码
namespace ChouJiang
{

    public partial class Form1 : Form
    {

         Tools tools1 = new Tools();
        // 指定中奖人
        // List<object> 泛型
        public Dictionary<string, List<object>> Dict1 = new Dictionary<string, List<object>>{
                { "Z", new List<object> {  "杜伟", "范艳珂", "李浩鹏"} },
                { "X", new List<object> { "陈富民", "陈良", "杨娟丽", } },
                { "C", new List<object> { "李玉田", "刘香玲", "宋婉婉" } }
          };
        public Form1(string is_new)
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile(@".\images\image1.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            //每次启动抽奖程序设置 is_join 为 11 未中奖。
            if (is_new == "Restart")
            {
                DBHelper.Update_sql(" update UserInfo set is_JOIN = 11");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // 按键响应必要参数
            this.KeyPreview = true;
            //窗口最大化
            this.WindowState = FormWindowState.Maximized;
            label4.Text = tools1.FlushJoin();
        }
        //作弊函数
        private void Luck(string keysValues)
        {

            timer1.Enabled = false;
            label1.Text = Dict1[keysValues][0].ToString();
            label2.Text = Dict1[keysValues][1].ToString();
            label3.Text = Dict1[keysValues][2].ToString();
            tools1.SetJoin(this);
            label4.Text = tools1.FlushJoin();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 启动 循环 无限随机但不是最终结果。
            try
            {
                label1.Text = tools1.QueryJoinName()[tools1.Get_Random1(tools1.QueryJoinName().Count) +1 ].ToString();
                label2.Text = tools1.QueryJoinName()[tools1.Get_Random1(tools1.QueryJoinName().Count) +2 ].ToString();
                label3.Text = tools1.QueryJoinName()[tools1.Get_Random1(tools1.QueryJoinName().Count) - 1].ToString();
            }
            catch (System.Exception) { }
            finally { }
        }
        private void button5_Click(object sender, EventArgs e)
        {   
            // 终止 循环  调用Get_Random 生成一个绝对唯一的随机数。
            
            label1.Text = tools1.QueryJoinName()[tools1.UniqueValue(tools1.QueryJoinName().Count)].ToString();
            label2.Text = tools1.QueryJoinName()[tools1.UniqueValue(tools1.QueryJoinName().Count)].ToString();
            label3.Text = tools1.QueryJoinName()[tools1.UniqueValue(tools1.QueryJoinName().Count)].ToString();
            timer1.Enabled = false;
            tools1.SetJoin(this);
            label4.Text = tools1.FlushJoin();
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
        private void 单抽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 from2 = new Form2();
            this.Hide();
            from2.ShowDialog();
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

