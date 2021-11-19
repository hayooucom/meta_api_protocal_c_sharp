using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace SerialCom
{
    public partial class MainForm : Form
    {

        //实例化串口对象
        SerialPort serialPort = new SerialPort();

        int comboBoxCom_index = 0;

        String saveDataFile = null;
        String loadDataFile = null;
        public FileStream saveDataFS = null;

        play_record_data play_record_data_obj = new play_record_data();
        metaverse_protocal metaverse_protocal_obj = new metaverse_protocal();

        int rcv_pkg_counter = 0;
        public UInt64 rcv_pkg_counter_all = 0;
        bool is_write_start_time = false;

        public long start_time_ms = 0;                                                                                                                                                                          //yo uk-p a n@g ma il.c om
        DateTime file_start_time;


        public MainForm()
        {
            InitializeComponent();
            metaverse_protocal_obj.mainform = this;
        }

        //初始化串口界面参数设置
        private void Init_Port_Confs()
        {
            /*------串口界面参数设置------*/

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            /*------波特率设置-------* /
            string[] baudRate = { "9600", "19200", "38400", "57600", "115200" };
            foreach (string s in baudRate)
            {
                comboBoxBaudRate.Items.Add(s);
            }
            comboBoxBaudRate.SelectedIndex = 4;*/

            /*------数据位设置-------* /
            string[] dataBit = { "5", "6", "7", "8" };
            foreach (string s in dataBit)
            {
                comboBoxDataBit.Items.Add(s);
            }
            comboBoxDataBit.SelectedIndex = 3;


            /*------校验位设置-------* /
            string[] checkBit = { "None", "Even", "Odd", "Mask", "Space" };
            foreach (string s in checkBit)
            {
                comboBoxCheckBit.Items.Add(s);
            }
            comboBoxCheckBit.SelectedIndex = 0;


            /*------停止位设置-------* /
            string[] stopBit = { "1", "1.5", "2" };
            foreach (string s in stopBit)
            {
                comboBoxStopBit.Items.Add(s);
            }
            comboBoxStopBit.SelectedIndex = 0;
            */

            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                string ip = addr[i].ToString();
                //this program is written by youkpan@gmail.com
                if (ip.Contains(":"))
                {
                    continue;
                }
                comboBox_ip.Items.Add(ip);
            }
            comboBox_ip.SelectedIndex = 0;

            string[] ip_port = { "5678", "9998" };
            foreach (string s in ip_port)
            {
                comboBox_port.Items.Add(s);
            }
            comboBox_port.SelectedIndex = 0;

            string[] protocal_lists = { "metaverse", "Test" };
            foreach (string s in protocal_lists)
            {
                comboBox_protocal.Items.Add(s);
            }
            comboBox_protocal.SelectedIndex = 0;

            refesh_port();

            /*------数据格式设置-------*/
            radioButtonSendDataASCII.Checked = true;
            /*radioButtonReceiveDataASCII.Checked = false;
            radioButtonReceiveDataHEX.Checked = true;
            radioButtonReceiveDataASCII.Enabled = false;
            radioButtonReceiveDataHEX.Enabled = false;*/
            radioButtonFileSave.Checked = false;

            try
            {
                string subdir = @"./save_file";
                // If directory does not exist, create it. 
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                DateTime dt = DateTime.Now;
                string date1 = dt.ToUniversalTime().ToString("yyyy-MM-dd HH.mm.ss");

                saveDataFile = "./save_file/metaverse_DL_UNREAL_" + date1 + ".bin";

                radioButtonFileSave.Checked = true;
                radioButtonFileSave.Text =  "Save to file\n" + saveDataFile;                                                                                                                                                                                                                                                    //base64info : IC8vdGhpcyBwcm9ncmFtIGlzIHdyaXR0ZW4gYnkgeW91a3BhbkBnbWFpbC5jb20=

            }
            catch (System.Exception ex)
            {
            }
        }

        //加载主窗体
        private void MainForm_Load(object sender, EventArgs e)
        {

            Init_Port_Confs();

            Control.CheckForIllegalCrossThreadCalls = false;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(dataReceived);

            //准备就绪              
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
            //设置数据读取超时为1ms
            serialPort.ReadTimeout = 1;

            serialPort.Close();

            buttonSendData.Enabled = false;
            comboBox_protocal.Enabled = true;
            comboBox_ip.Enabled = true;
            comboBox_port.Enabled = true;

            reset_ip_port();
        }


        //打开串口 关闭串口
        private void buttonOpenCloseCom_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)//串口处于关闭状态
            {
                try
                {
                    if(comboBox_protocal.SelectedIndex == 1)
                    {
                        for(int i = 0; i < 100; i++)
                        {
                            metaverse_protocal_obj.unit_test();
                        }
                        
                        return;
                    }

                    if (comboBoxCom.SelectedIndex == -1)
                    {
                        MessageBox.Show("Error: 无效的端口,请重新选择", "Error");
                        return;
                    }
                    string strSerialName    = comboBoxCom.SelectedItem.ToString();
                    strSerialName = strSerialName.Replace("metaverse_", "COM");
                    //string strBaudRate      = comboBoxBaudRate.SelectedItem.ToString();
                    //string strDataBit       = comboBoxDataBit.SelectedItem.ToString();
                    //string strCheckBit      = comboBoxCheckBit.SelectedItem.ToString();
                    //string strStopBit       = comboBoxStopBit.SelectedItem.ToString();
                    string strCheckBit = "None";
                    string strStopBit = "1";
                    Int32 iBaudRate = 115200;// Convert.ToInt32(strBaudRate);
                    Int32 iDataBit = 8;// Convert.ToInt32(strDataBit);

                    serialPort.PortName = strSerialName;//串口号
                    serialPort.BaudRate = iBaudRate;//波特率
                    serialPort.DataBits = iDataBit;//数据位

                    switch (strStopBit)            //停止位
                    {
                        case "1":
                            serialPort.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            serialPort.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            serialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：停止位参数不正确!", "Error");
                            break;
                    }
                    switch (strCheckBit)             //校验位
                    {
                        case "None":
                            serialPort.Parity = Parity.None;
                            break;
                        case "Odd":
                            serialPort.Parity = Parity.Odd;
                            break;
                        case "Even":
                            serialPort.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：校验位参数不正确!", "Error");
                            break;
                    }

                    //打开串口
                    serialPort.Open();

                    disable_buttons();

                    buttonOpenCloseCom.Text = "Stop Send";
                    rcv_pkg_counter = 0;

                }
                catch(System.Exception ex)
                {
                    close_save_file();
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    
                    return;
                }
            }
            else //串口处于打开状态
            {
                
                serialPort.Close();//关闭串口
                enable_buttons();

                buttonOpenCloseCom.Text = "Start";

            }
        }

        private void enable_buttons()
        {
            //串口关闭时设置有效
            comboBoxCom.Enabled = true;
            //comboBoxBaudRate.Enabled = true;
            //comboBoxDataBit.Enabled = true;
            //comboBoxCheckBit.Enabled = true;
            //comboBoxStopBit.Enabled = true;
            comboBox_protocal.Enabled = true;
            comboBox_ip.Enabled = true;
            comboBox_port.Enabled = true;
            //radioButtonSendDataASCII.Enabled = true;
            //radioButtonSendDataHex.Enabled = true;
            //radioButtonReceiveDataASCII.Enabled = false;
            //radioButtonReceiveDataHEX.Enabled = false;
            radioButtonFileSave.Enabled = true;
            buttonSendData.Enabled = false;
            Button_Refresh.Enabled = true;
        }

        private void disable_buttons()
        {
            //打开串口后设置将不再有效
            comboBoxCom.Enabled = false;
            comboBox_protocal.Enabled = false;
            comboBox_ip.Enabled = false;
            comboBox_port.Enabled = false;
            //comboBoxBaudRate.Enabled = false;
            //comboBoxDataBit.Enabled = false;
            //comboBoxCheckBit.Enabled = false;
            //comboBoxStopBit.Enabled = false;
            radioButtonSendDataASCII.Enabled = false;
            radioButtonSendDataHex.Enabled = false;
            //radioButtonReceiveDataASCII.Enabled = false;
            //radioButtonReceiveDataHEX.Enabled = false;
            buttonSendData.Enabled = true;
            Button_Refresh.Enabled = false;
            radioButtonFileSave.Enabled = false;
        }



        //接收数据
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                rcv_pkg_counter++;
                
                //MessageBox.Show("sss","OK");
                //输出当前时间
                DateTime dateTimeNow = DateTime.Now;
                //dateTimeNow.GetDateTimeFormats();                                                                                                                                                                                     //im the author :dGhpcyBwcm9ncmFtIGlzIHdyaXR0ZW4gYnkgeW91a3BhbkBnbWFpbC5jb20=
                if (rcv_pkg_counter % 100==1)
                {
                    textBoxReceive.Text += string.Format("{0}\r\n", dateTimeNow +",counter:"+ rcv_pkg_counter_all);
                    try
                    {
                        if (textBoxReceive.Text.Length > 100000)
                        {
                            textBoxReceive.Text = textBoxReceive.Text.Substring(50000);
                        }
                        saveDataFS.FlushAsync();
                        textBoxReceive.SelectionStart = textBoxReceive.Text.Length;
                        textBoxReceive.ScrollToCaret();//滚动到光标处

                    }
                    catch (System.Exception ex)
                    {

                    }
                }
                //dateTimeNow.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                textBoxReceive.ForeColor = Color.Black;    //改变字体的颜色

                if(saveDataFS ==null && saveDataFile!=null)
                {
                    create_save_file();
                }

                if (!is_write_start_time)
                {
                    write_start_time();
                    is_write_start_time = true;
                }

                try
                {

                    var buf = new Byte[serialPort.BytesToRead];
                    var count = serialPort.Read(buf, 0, buf.Length);

                    metaverse_protocal_obj.metaverseProtocalRecev(buf, count);

                }
                catch (System.Exception ex)
                {

                }
                if (false) //接收格式为ASCII
                {
                    try
                    {
                        String input = serialPort.ReadLine();
                        textBoxReceive.Text += input + "\r\n";
                        // save data to file
                        /*if (saveDataFS != null)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(input + "\r\n");
                            saveDataFS.Write(info, 0, info.Length);
                        }*/
                    }
                    catch(System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错:"+ex.Message);
                        return;
                    }


                }
                else //接收格式为HEX
                {
                    try
                    {
                        /*
                        string input = serialPort.ReadLine();

                        char[] values = input.ToCharArray();
                        foreach (char letter in values)
                        {
                            // Get the integral value of the character.
                            int value = Convert.ToInt32(letter);
                            // Convert the decimal value to a hexadecimal value in string form.
                            string hexOutput = String.Format("{0:X}", value);
                            textBoxReceive.AppendText(hexOutput + " ");
                            textBoxReceive.SelectionStart = textBoxReceive.Text.Length;
                            textBoxReceive.ScrollToCaret();//滚动到光标处
                            //textBoxReceive.Text += hexOutput + " ";

                        }

                        // save data to file


                        */
                    }
                    catch(System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        textBoxReceive.Text = "";//清空
                    }
                }
                serialPort.DiscardInBuffer(); //清空SerialPort控件的Buffer 

            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        //发送数据
        private void buttonSendData_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口", "Error");
                return;
            }

            String strSend = textBoxSend.Text;//发送框数据
            if (true)//以字符串 ASCII 发送
            {
                serialPort.WriteLine(strSend);//发送一行数据 

            }
            else
            {
                //16进制数据格式 HXE 发送
                 
                char[] values = strSend.ToCharArray();
                foreach (char letter in values)
                {
                    // Get the integral value of the character.
                    int value = Convert.ToInt32(letter);
                    // Convert the decimal value to a hexadecimal value in string form.
                    string hexIutput = String.Format("{0:X}", value);
                    serialPort.WriteLine(hexIutput);

                }



            }

        }

        //清空接收数据框
        private void buttonClearRecData_Click(object sender, EventArgs e)
        {
            
            textBoxReceive.Text = "";

        }


        //窗体关闭时
        private void MainForm_Closing(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();//关闭串口
            }

            if (saveDataFS != null)
            {
                saveDataFS.Close(); // 关闭文件
                saveDataFS = null;//释放文件句柄
            }

        }

        private void refesh_port()
        {
            comboBoxCom.Text = "";
            comboBoxCom.Items.Clear();

            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            comboBoxCom_index = -1;

            //添加串口
            foreach (string s in str)
            {
                string s2 = s;
                /*if (s == "COM1" && str.Length > 1)
                {
                    continue;
                }*/
                if (s != "COM1")
                {
                    s2 = s.Replace("COM", "metaverse_");
                }
                comboBoxCom.Items.Add(s2);
                comboBoxCom_index++;
            }

            //设置默认串口
            comboBoxCom.SelectedIndex = comboBoxCom_index;
            //comboBoxBaudRate.SelectedIndex = 4;
            ////comboBoxDataBit.SelectedIndex = 3;
            //comboBoxCheckBit.SelectedIndex = 0;
            //comboBoxStopBit.SelectedIndex = 0;
        }

        //刷新串口
        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            refesh_port();
        }

        // 退出
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();//关闭串口
            }
            close_save_file();

            this.Close();
        }

        // 重置串口参数设置
        private void ResetPortConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxCom.SelectedIndex = comboBoxCom_index;
            //comboBoxBaudRate.SelectedIndex = 4;
            //comboBoxDataBit.SelectedIndex = 3;
            //comboBoxCheckBit.SelectedIndex = 0;
            //comboBoxStopBit.SelectedIndex = 0;
            radioButtonSendDataASCII.Checked = true;
            //radioButtonReceiveDataASCII.Checked = false;
            //radioButtonReceiveDataHEX.Checked = true;
        }

        private void create_save_file()
        {
            saveDataFS = File.Create(saveDataFile);
            byte[] info = new UTF8Encoding(true).GetBytes("metaverse_data\r\nver:1\r\n");
            saveDataFS.Write(info, 0, info.Length);
            textBoxReceive.Text += string.Format("create file:{0}\r\n", saveDataFile);
            rcv_pkg_counter_all = 0;
        }

        // 保存接收数据到文件
        private void SaveReceiveDataToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DateTime dt = DateTime.Now;
            string date1 = dt.ToUniversalTime().ToString("yyyy-MM-dd HH.mm.ss");

            saveFileDialog.FileName = "metaverse_DL_UNREAL_"+ date1+".bin";

            saveFileDialog.Filter = "Bin |*.bin";
            saveFileDialog.Title = "Save data to file";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null)
            {
                saveDataFile = saveFileDialog.FileName;
                radioButtonFileSave.Checked = true;
                radioButtonFileSave.Text = saveFileDialog.Title + "\n" + saveDataFile;

                create_save_file();

            }

        }

        private void close_save_file()
        {
            radioButtonFileSave.Checked = false;
            if (saveDataFS != null)
            {
                saveDataFS.Flush();
                saveDataFS.Close(); // 关闭文件
                saveDataFS = null;//释放文件句柄
                saveDataFile = null;
                textBoxReceive.Text += string.Format("close file:{0}\r\n", saveDataFile);
            }
        }
        
        private void radioButtonFileSave_Click(object sender, MouseEventArgs e)
        {
            //radioButtonFileSave.Checked = !radioButtonFileSave.Checked;
            if (radioButtonFileSave.Checked)
            {
                close_save_file();
            }
            else if (saveDataFile !=null)
            {
                radioButtonFileSave.Checked = true;
            }
            
        }

        private void AuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://thoughts.aliyun.com/share/6195068ebdc2c4001aea0058");
        }

        private void reset_ip_port()
        {
            try
            {
                if (comboBox_port.SelectedItem != null)
                {
                    int port = Convert.ToInt32(comboBox_port.SelectedItem.ToString());
                    string localip = comboBox_ip.SelectedItem.ToString();
                    metaverse_protocal_obj.init(localip, localip, port);
                }
                
            }
            catch (System.Exception ex)
            {

            }
        }
        private void comboBox_ip_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset_ip_port();
        }

        private void comboBox_port_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset_ip_port();
        }

        private void comboBox_protocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            metaverse_protocal_obj.metaverse_unreal_obj.using_portocal = comboBox_protocal.SelectedIndex;
            switch (comboBox_protocal.SelectedIndex)
            {
                case 0:
                    comboBox_port.Text = "5678";
                    break;
                case 1:
                    comboBox_port.Text = "5432";
                    break;
            }
        }

        private void write_start_time()
        {
            file_start_time = DateTime.Now;
            string date1 = file_start_time.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss.ffffff");
            if (start_time_ms == 0)
            {
                start_time_ms = file_start_time.ToUniversalTime().Ticks / 10000;
            }
            if (saveDataFS != null)
            {
                byte[] info = new UTF8Encoding(true).GetBytes("start_time:" + date1 + "\r\n"+ "start_time_ms:" + start_time_ms + "\r\n");
                saveDataFS.Write(info, 0, info.Length);
            }
            
        }


        private void btn_load_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Bin|*.bin";       //打开文件的类型
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (fd.FileName != null)
                {
                    loadDataFile = fd.FileName;

                    textBoxReceive.Text += string.Format("load file:{0}\r\n", loadDataFile);
                }
            }

        }
        private void start_play_data_file()
        {
            disable_buttons();
            play_record_data_obj.play(this, metaverse_protocal_obj, loadDataFile);
            enable_buttons();
            btn_pause_play_file_data.Text = "Paused";
            play_record_data_obj.pause_signal = false;
        }
        private void btn_play_load_file_Click(object sender, EventArgs e)
        {
            //btn_play_load_file.BackColor = Color.Green;
            if (loadDataFile != null)
            {
                if (File.Exists(loadDataFile))
                {
                    Thread thrSend = new Thread(start_play_data_file);
                    thrSend.Start();
                }
                else
                {
                    msg_box_print("the data file not Exists."+ loadDataFile);
                }
            }
            else
            {
                msg_box_print("please load data file first.");
            }
            //btn_play_load_file.BackColor = Color.Gray;
        }

        public void msg_box_print(string spritfstr)
        {
            textBoxReceive.Text += spritfstr + "\r\n"; ;

            textBoxReceive.SelectionStart = textBoxReceive.Text.Length;
            textBoxReceive.ScrollToCaret();//滚动到光标处
        }

        private void btn_pause_play_file_data_Click(object sender, EventArgs e)
        {
            play_record_data_obj.pause();
        }

        private void btn_stop_play_file_Click(object sender, EventArgs e)
        {
            play_record_data_obj.stop();
        }

        private void ContributorSylvesterLiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://github.com/youkpan");
            
        }
    }
}
