using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SerialCom
{
    class metaverse_unreal
    {



        private String metaverse_json_str1;
        private String metaverse_json_str2;
        private String metaverse_json_str3;


        public static string localip = "192.168.124.8";
        public static string remote_ip = "192.168.124.8";
        public static int remote_port = 5432;
        private IPEndPoint localIpep; // 本机IP和监听端口号
        private UdpClient udpcSend;
        IPEndPoint remoteIpep;

        public int using_portocal = 0;

        public void send_init(string local_ip1,string remote_ip1, int remote_port1)
        {
            localip = local_ip1;
            remote_ip = remote_ip1;
            remote_port = remote_port1;
            localIpep = new IPEndPoint(IPAddress.Parse(localip), 8889); // 本机IP和监听端口号
            remoteIpep = new IPEndPoint(IPAddress.Parse(remote_ip), remote_port); // 发送到的IP地址和端口号
            udpcSend = new UdpClient(localIpep);
            init_json_str();
        }

        #region 发送数据包
        public void send_metaverse_lens_data(float focus_m, UInt16 parm_b, float parm_c)
        {
            String spritfstr=null;
            if(using_portocal == 0)
            {
                spritfstr = get_metaverse_json_protocal(focus_m, parm_b, parm_c);
            }

            // 实名发送
            if (spritfstr != null)
            {
                //IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(localip), 5432); // 发送到的IP地址和端口号
                //udpcSend.Send(buf, buf.Length, remoteIpep);

                Thread thrSend = new Thread(SendMessage);
                thrSend.Start(spritfstr);
            }

            return;
             
        }
        #endregion
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            try
            {
                String message = (string)obj;
                byte[] sendbytes = Encoding.UTF8.GetBytes(message); //message.GetBytes();
                if (remoteIpep != null)
                {
                    udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                }
                
                //udpcSend.Close();
            }
            catch { }
        }

        private string get_metaverse_json_protocal(float focus_m, float parm_b, float parm_c)
        {
            // 处理换行
            string spritfstr = String.Format(metaverse_json_str2, focus_m, focus_m * 39.37008, parm_c, parm_b);
            spritfstr = metaverse_json_str1 + spritfstr + metaverse_json_str3;                                                                                                                                                                                  //  MTU5MTkyMTg3MjkgaGV5IHRoaXMgcHJvZ3JhbSBpcyB3cml0dGVuIGJ5IGh0dHBzOi8vZ2l0aHViLmNvbS95b3VrcGFu
            return spritfstr;
        }
        public void init_json_str()
        {
            metaverse_json_str1 = @"{
""metadata"":
{
    ""info""{
        ""protocalVersion"":1
    },
    ""device"":
    {
      ""model"":  ""metaverse"",
      ""BoxID"":  """",
      ""BoxSoftwareVersion"":  """",
    },
    ""lens"":
    {
        ""device"":
        {
            ""model"":  """",
            ""serialNumber"":  ""123"",
        },
        ""state"":
        {
";
            metaverse_json_str2 = @" ";

            metaverse_json_str3 = @"

        }
    },
    ""positional"":
    {
          ""position"":
          {
            ""x"":  0,
            ""y"":  0,
            ""z"":  0
          },
          ""orientation"":
          {
            ""yaw"":  0,
            ""roll"":  0,
            ""tilt"":  0,
            ""pitch"":  0
          },
          ""compass"":
          {
            ""x"":  0,
            ""y"":  0,
            ""z"":  0
          },
            ""accel"":
            {
                ""x"":0,
                ""y"":0,
                ""z"":0,
                ""rateHz"":125
            },
            ""gyro"":{
                ""x"":0,
                ""y"":0,
                ""z"",0,
                ""rateHz"":125
            },
            ""location"":{
                ""lat"":0,
                ""lng"":0
            }
    }
    
}";
            metaverse_json_str1 = metaverse_json_str1.Replace("\r\n", "");
            metaverse_json_str1 = metaverse_json_str1.Replace("\n", "");
            metaverse_json_str1 = metaverse_json_str1.Replace(" ", "");
            metaverse_json_str3 = metaverse_json_str3.Replace("\r\n", "");
            metaverse_json_str3 = metaverse_json_str3.Replace("\n", "");
            metaverse_json_str3 = metaverse_json_str3.Replace(" ", "");
        }

    }
}
