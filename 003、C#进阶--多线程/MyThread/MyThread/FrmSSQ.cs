using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyThread
{
    public partial class FrmSSQ : Form
    {
        /// <summary> 
        /// 多线程双色球项目
        /// 需求：双色球，投注号码由6个红色球号码和1个蓝色球号码组成；红色球号码从01--33中选择，不重复；蓝色球号码从01--16中选择
        /// </summary>
        public FrmSSQ()
        {
            InitializeComponent();
        }

        #region Data 
        /// <summary>
        /// 红球集合  其实可以写入配置文件
        /// </summary>
        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"
        };

        /// <summary>
        /// 蓝球集合  球号码可以放在配置文件；
        /// </summary>
        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"
        };

        private bool IsGoOn = true;
        private List<Task> taskList = new List<Task>();
        private static object object_Lock = new object();
        #endregion

        /// <summary>
        /// 点击开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region 初始化动作
            this.btnStart.Text = "运行ing";

            this.lblBlue.Text = "00";
            this.lblRed1.Text = "00";
            this.lblRed2.Text = "00";
            this.lblRed3.Text = "00";
            this.lblRed4.Text = "00";
            this.lblRed5.Text = "00";
            this.lblRed6.Text = "00";
            #endregion

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            taskList.Clear();
            Thread.Sleep(1000);
            //1.读取界面上有多少个球号码
            //2.循环球号码个数，每循环一次，开启一个线程
            foreach (var control in this.gboSSQ.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control; //只对lable处理
                    if (label.Name.Contains("Blue")) //蓝色球
                    {
                        taskList.Add( Task.Run(() => //开启一个线程
                        {
                            //目标：需要让这个球不断的跳动变化；
                            //1.获取号码值---号码的区间 建议写在配置文件；就应该在BlueNums数组中找数据；
                            //2.赋值
                            //3.循环 
                            while (IsGoOn)
                            {
                                //数组找数据通过索引；先确定索引；找到1-15的随机值作为索引值；然后去数组中取出数据
                                //new Random().Next(0, 16);
                                int index = new RandomHelper().GetRandomNumberDelay(0, 16);
                                string blueNum = this.BlueNums[index];
                                //this.lblBlue.Text = blueNum;//不允许---需要让主线程来帮助完成这件事儿
                                this.Invoke(new Action(() => //子线程委托出去，让主线程帮助完成一件事儿
                                {
                                    lblBlue.Text = blueNum;
                                }));
                            }
                        }));
                    }
                    else //红色球
                    {
                        taskList.Add( Task.Run(() => 
                        { 
                            while (IsGoOn)
                            {  
                                int index = new RandomHelper().GetRandomNumberDelay(0, 33);
                                string redNum = this.RedNums[index];                              
                                lock (object_Lock)
                                {
                                    var currentNumberlist = GetCurrentNumberList();
                                    if (!currentNumberlist.Contains(redNum))
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            label.Text = redNum;
                                        }));
                                    }                                    
                                }  
                                //问题：号码重复如何解决
                                //1.赋值的时候，判断是否有重复
                                //2.在赋值的时候，进行判断，如果界面上没有重复数据，就赋值，否则就重新生成index，重新获取值；
                                //3.锁
                            }
                        })); 
                    } 
                }
            }
        }

        /// <summary>
        /// 获取界面上所有红色球的球号码
        /// </summary>
        /// <returns></returns>
        public List<string> GetCurrentNumberList()
        {
            List<string> numberlist = new List<string>();
            foreach (var control in this.gboSSQ.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control; //只对lable处理
                    if (label.Name.Contains("Red"))
                    {
                        numberlist.Add(label.Text);
                    } 
                }
            }

            //写代码测试
            if (numberlist.Count(s=>s=="00")==0  && numberlist.Distinct().Count()<6)
            {
                Console.WriteLine("********************有重复************************");
                foreach (var num in numberlist)
                {
                    Console.WriteLine(num);
                }
            }

            return numberlist;
        }

        /// <summary>
        /// 点击结束  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.IsGoOn = false;
                //还要等待所有线程都执行结束，才能输出结果； 
                Task.WaitAll(taskList.ToArray()); 
                //死锁：是主线程和子线程相互等待引起的；  
                this.Invoke(new Action(() => {
                    this.btnStart.Text = "Start";
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                    this.IsGoOn = true;
                }));

                ShowResult();
            }); 
        }

        /// <summary>
        /// 弹框提示数据
        /// </summary>
        private void ShowResult()
        {
            MessageBox.Show(string.Format("本期双色球结果为：{0} {1} {2} {3} {4} {5}  蓝球{6}"
                , this.lblRed1.Text
                , this.lblRed2.Text
                , this.lblRed3.Text
                , this.lblRed4.Text
                , this.lblRed5.Text
                , this.lblRed6.Text
                , this.lblBlue.Text));
        }
    }
}
