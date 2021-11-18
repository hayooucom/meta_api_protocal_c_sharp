using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace SerialCom
{
    class play_record_data
    {
        public FileStream loadDataFS = null;
        public bool stop_signal = false;
        UInt32 start_time_stamp_ms = 0;
        long start_time_pc_ms = 0;
        public MainForm mainform = null;
        long sendStartTime = 0;
        public bool pause_signal = false;
        public void play(MainForm mainform1, metaverse_protocal metaverse_protocal_obj ,string loadDataFile)
        {
            mainform = mainform1;
            //loadDataFS = File.OpenRead(loadDataFile);

            stop_signal = false;
            start_time_stamp_ms = 0;
            start_time_pc_ms = 0;
            var play_counter = 0;
            StreamReader sr = new StreamReader(loadDataFile, Encoding.Default);
            string line = "1";
            int file_line_counter = 0;
            pause_signal = false;
            mainform.btn_pause_play_file_data.Text = "Paused";
            mainform.msg_box_print("Play file data:"+ loadDataFile);

            while (line != null && stop_signal == false)
            {
                while (pause_signal) { 

                }
                line = sr.ReadLine();
                if(line == null)
                {
                    mainform.msg_box_print("file data load and play finished!");
                    return;
                }
                var line_a = line.Split(',');
                var line_number = line_a[0];
                file_line_counter++;

                if(file_line_counter == 1 && line!= "metaverse_data"){
                    mainform.msg_box_print("seems file error!");
                    return;
                }
                if (file_line_counter == 2 )
                {
                    var ver_a = line.Split(':');
                    if(ver_a.Length == 2)
                    {
                        if (ver_a[1] != "1")
                        {
                            mainform.msg_box_print("seems file version not support!");
                            return;
                        }
                    }
                }
                if (file_line_counter < 5 || line_a.Length <2)
                {
                    continue;
                }

                var metaverse_protocal_data_buf = HexStringToByteArray(line_a[1]);

                UInt32 parm_a = (UInt32)(metaverse_protocal_data_buf[0] & 0x0F) << 16;
                parm_a |= (UInt32)(metaverse_protocal_data_buf[1] & 0xFF) << 8;
                parm_a |= (UInt32)metaverse_protocal_data_buf[2];

                UInt16 parm_b = (UInt16)(((UInt16)(metaverse_protocal_data_buf[3] & 0x0F)) << 8);
                parm_b |= (UInt16)(((UInt16)metaverse_protocal_data_buf[4]));

                float aperture = (float)metaverse_protocal_data_buf[5] / 10;
                float log2 = (float)(Math.Log((float)aperture) / Math.Log(2.0));
                float parm_c = (float)((log2 * 2 + 1) * 1000);

                UInt32 time_stamp_ms = (UInt32)(metaverse_protocal_data_buf[6]) << 24;
                time_stamp_ms |= (UInt32)(metaverse_protocal_data_buf[7]) << 16;
                time_stamp_ms |= (UInt32)(metaverse_protocal_data_buf[8]) << 8;
                time_stamp_ms |= (UInt32)(metaverse_protocal_data_buf[9]);

                if(start_time_stamp_ms == 0)
                {
                    start_time_stamp_ms = time_stamp_ms;
                    start_time_pc_ms = DateTime.Now.ToUniversalTime().Ticks / 10000;
                }

                long time_pc_ms1 = DateTime.Now.ToUniversalTime().Ticks / 10000;

                while(time_pc_ms1 - start_time_pc_ms < time_stamp_ms - start_time_stamp_ms)
                {
                    time_pc_ms1 = DateTime.Now.ToUniversalTime().Ticks / 10000;
                }

                var ts = DateTime.Now.ToUniversalTime().Ticks;

                if (ts - sendStartTime > 30 * 10000)
                {
                    sendStartTime = ts;
                    metaverse_protocal_obj.metaverse_unreal_obj.send_metaverse_lens_data((float)parm_a / 1000, parm_b, parm_c);
                }
                play_counter++;

                if (play_counter % 30 == 1)
                {
                    var spritfstr = String.Format(@" {0:F4}m, {1:F1}, {2:D}mm", (float)parm_a / 1000, aperture, parm_b);
                    mainform.msg_box_print( "time:"+ ((float)(time_stamp_ms - start_time_stamp_ms) /1000).ToString() +"S,"+ spritfstr);
                }
            } 
        }

        public void stop()
        {
            stop_signal = true;
        }

        public void pause()
        {
            pause_signal = !pause_signal;
            if (pause_signal)
            {
                mainform.btn_pause_play_file_data.Text="Continue";
            }
            else
            {
                mainform.btn_pause_play_file_data.Text = "Paused";
            }
        }


        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }

            return buffer;
        }
    }
}
