using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Forms;
using System.Drawing;


namespace ChouJiang
{
    class Tools
    {
        public Tools() { }
        ~Tools() { }


        public Hashtable hashtable = new Hashtable();

        public IEnumerable<Control> Controls { get; private set; }


        public int Get_Random1(int Num)
        {
            Random random1 = new Random();
            return random1.Next(Num);
        }

        public int UniqueValue(int Number)
        {
            Random random = new Random();
            int Num = (int)(random.Next(Number));
            for (int i = 0; i < Number; i++)
            {
                if (!hashtable.ContainsValue(Num) && Num != 0)
                {
                    hashtable.Add(Num, Num);
                    break;
                }
                else if (hashtable.ContainsValue(Num))
                {
                    Num = (int)(random.Next(Number));
                }
            }
            return Num;
        }
        public void SetJoin(Form form)
        {
            // 遍历控件获取 Lable.Text 的值 
            foreach (Control control in form.Controls)
            {
                if (control is Label)
                {
                    DBHelper.Update_sql($" update UserInfo set is_JOIN = 12 where name = '{(control as Label).Text}'");
                }
            }
        }

        public string FlushJoin()
        {
            //12 表示已中奖，11 表示未中奖
            ArrayList Count = DBHelper.Query_sql("select count(id) from userinfo(nolock) where  isnull(is_join,11)<>12");
            return "当前参与抽奖人数：" + Count[0].ToString();

        }

        public ArrayList QueryJoinName()
        {
            ArrayList Data = DBHelper.Query_sql("select name from userinfo(nolock)");
            return Data;
        }

    }
}