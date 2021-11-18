﻿using System;
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
    class metaverse_protocal
    {

        public Byte[] Uart_Rx_buf = new Byte[256];
        public Int32 Uart_Rx_idx = 0;
        private Byte meta_api_state = 0;
        private Byte meta_api_extend_len = 0;
        private Byte meta_api_data_type = 0;
        private UInt32 meta_api_buf_start_idx = 0;
        private Int16 meta_api_version = 0;
        private UInt16 meta_api_len = 0;
        private Int16 meta_api_rx_idx = 0;
        private UInt16 meta_api_seq = 0;
        private UInt16 meta_api_cmdset = 0;
        private UInt16 meta_api_cmdid = 0;
        private Byte[] meta_api_data_buf = new Byte[256];
        private Byte[] meta_api_buf = new Byte[256];
        private UInt16 meta_api_buf_idx = 0;
        private UInt16 meta_api_extend_idx = 0;
        private string last_save_data;
        private long last_time_ticks = 0;

        private UInt16 meta_api_crc16 = 0;
        private UInt16 meta_api_crc16_calc = 0;
        private UInt32 meta_api_crc32 = 0;
        private UInt32 meta_api_crc32_calc = 0;

        private crc16 crc16_obj = new crc16();
        private crc32 crc32_obj = new crc32();
        private bool Frm_main_init = false;
        public metaverse_unreal metaverse_unreal_obj = new metaverse_unreal();

        private long sendStartTime = DateTime.Now.ToUniversalTime().Ticks;

        public MainForm mainform=null;

        public void init(string local_ip1, string remote_ip1, int remote_port1)
        {
            metaverse_unreal_obj.send_init(local_ip1, remote_ip1, remote_port1);
        }

        public void send_metaverse_unreal_data(UInt32 parm_a, UInt16 parm_b,float parm_c)
        {

            var ts = DateTime.Now.ToUniversalTime().Ticks;

            if (ts - sendStartTime > 30 * 10000)
            {
                sendStartTime = ts;
                metaverse_unreal_obj.send_metaverse_lens_data((float)parm_a / 1000, parm_b, parm_c);
            }

        }
        #region 协议执行
        private int Process_metaverse_packet(UInt16 meta_api_cmdset, UInt16 meta_api_id, Byte[] meta_api_packet_buf, UInt16 meta_api_packet_len, Byte[] meta_api_data_buf, UInt16 meta_data_len)
        {
            if (meta_api_cmdset == 0)
            {
                    send_metaverse_unreal_data(1, 2, 3);

                    if (mainform.rcv_pkg_counter_all % 300 == 1)
                    {
                        var spritfstr = String.Format(@"received len {0:D} ", meta_api_packet_len);
                        mainform.textBoxReceive.Text += spritfstr + "\r\n"; ;

                        mainform.textBoxReceive.SelectionStart = mainform.textBoxReceive.Text.Length;
                        mainform.textBoxReceive.ScrollToCaret();//滚动到光标处
                    }
            }
            save_packet();
            return 0;
        }

        #endregion
        /*
        public class metaverseProtocalS
        {
            Byte version;
            Byte DataType;
            Byte CmdType; 
            Byte ENC;
            UInt16 meta_api_cmdset;
            UInt16 meta_api_id;
            Byte[] meta_api_data_buf;
            UInt16 meta_data_len;
        };*/

        public Byte[] metaverseProtocalGen(Byte version,Byte data_type,Byte cmd_type,Byte ENC, UInt16 cmd_set, UInt16 cmd_id, Byte extend_len,UInt16 SEQ,  Byte[] data_buf, UInt16 data_len)
        {
            Byte[] api_buf;//= new Byte[];
            if (version < 16)
            {
                UInt16 packet_len = 0;
                UInt16 packet_len_all = (UInt16)(6 + data_len);
                api_buf = new Byte[packet_len_all];

                if((cmd_type & 0x20) == 0)
                    api_buf[packet_len++] = 0xFA;
                else
                    api_buf[packet_len++] = 0xFB;

                if (version < 2)
                    api_buf[packet_len++] = (Byte)(((version << 6) & 0xFF) | (packet_len_all & 0x3F));
                else
                {
                    api_buf[packet_len++] = (Byte)(packet_len_all & 0xFF);
                    api_buf[packet_len++] = (Byte)(((version << 6) & 0xF0) | ((packet_len_all >> 8) & 0x0F));
                }
                if (version == 1)
                {
                    api_buf[packet_len++] = (Byte)(cmd_set & 0xFF);
                    api_buf[packet_len++] = (Byte)(cmd_id & 0xFF);
                }
                else if(version >= 2)
                {
                    api_buf[packet_len++] = (Byte)(cmd_set & 0xFF);
                    api_buf[packet_len++] = (Byte)((cmd_set >> 8) & 0xFF);
                    api_buf[packet_len++] = (Byte)(cmd_id & 0xFF);
                    api_buf[packet_len++] = (Byte)((cmd_id >> 8) & 0xFF);
                    api_buf[packet_len++] = (Byte)(cmd_id & 0xFF);
                    api_buf[packet_len++] = (Byte)((cmd_id >> 8) & 0xFF);
                    api_buf[packet_len++] = (Byte)(SEQ & 0xFF);
                    api_buf[packet_len++] = (Byte)((SEQ >> 8) & 0xFF);
                }

                for (int i = 0; i < data_len; i++)
                {
                    api_buf[packet_len++] = data_buf[i];
                }
                if (version <= 1)
                {
                    UInt16 crc16_t = crc16_obj.crc16_init();
                    crc16_t = crc16_obj.crc16_update(crc16_t, api_buf, packet_len);
                    api_buf[packet_len++] = (Byte)(crc16_t & 0xFF);
                    api_buf[packet_len++] = (Byte)((crc16_t >> 8) & 0xFF);
                }
                
                if (version >= 2)
                {
                    UInt32 crc32_t = crc32_obj.crc32_init();
                    crc32_t = crc32_obj.crc32_update(crc32_t, api_buf, packet_len);
                    api_buf[packet_len++] = (Byte)(crc32_t & 0xFF);
                    api_buf[packet_len++] = (Byte)((crc32_t >> 8) & 0xFF);
                    api_buf[packet_len++] = (Byte)((crc32_t >> 16) & 0xFF);
                    api_buf[packet_len++] = (Byte)((crc32_t >> 24) & 0xFF);
                }

            }
            else
            {
                UInt16 packet_len = 0;
                UInt16 packet_len_all = (UInt16)(extend_len + 22 + data_len);
                api_buf = new Byte[packet_len_all];
                
                api_buf[packet_len++] = 0x5A;
                api_buf[packet_len++] = 0xEA;
                api_buf[packet_len++] = 0x10;//ver
                api_buf[packet_len++] = data_type;
                api_buf[packet_len++] = (Byte)(packet_len_all & 0xFF);
                api_buf[packet_len++] = (Byte)((packet_len_all >>8) & 0xFF);
                api_buf[packet_len++] = cmd_type;
                api_buf[packet_len++] = ENC;
                api_buf[packet_len++] = (Byte)(cmd_set & 0xFF); 
                api_buf[packet_len++] = (Byte)((cmd_set >> 8) & 0xFF);
                api_buf[packet_len++] = (Byte)(cmd_id & 0xFF);
                api_buf[packet_len++] = (Byte)((cmd_id >> 8) & 0xFF);
                api_buf[packet_len++] = 0;
                api_buf[packet_len++] = 0;
                api_buf[packet_len++] = (Byte)(SEQ & 0xFF);
                api_buf[packet_len++] = (Byte)((SEQ >> 8) & 0xFF);
                UInt16 crc16_t = crc16_obj.crc16_init();
                crc16_t = crc16_obj.crc16_update(crc16_t, api_buf, packet_len);
                api_buf[packet_len++] = (Byte)(crc16_t & 0xFF);
                api_buf[packet_len++] = (Byte)((crc16_t >> 8) & 0xFF);

                for(int i = 0; i < data_len; i++)
                {
                    api_buf[packet_len++] = data_buf[i];
                }

                UInt32 crc32_t = crc32_obj.crc32_init();
                crc32_t = crc32_obj.crc32_update(crc32_t, api_buf, packet_len);
                api_buf[packet_len++] = (Byte)(crc32_t & 0xFF);
                api_buf[packet_len++] = (Byte)((crc32_t >> 8) & 0xFF);
                api_buf[packet_len++] = (Byte)((crc32_t >> 16) & 0xFF);
                api_buf[packet_len++] = (Byte)((crc32_t >> 24) & 0xFF);

            }
            return api_buf;
        }

        #region 协议拆包
        public void metaverseProtocalRecev(Byte[] buf, int size)
        {
            DateTime dt = DateTime.Now;
            
            string date1 = dt.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss.ffffff");

            for (int i = 0; i < size; i++)
            {
                Byte rx_data = buf[i];
                if (meta_api_state >= 1)
                {
                    meta_api_buf[meta_api_buf_idx++] = rx_data;
                }
                switch (meta_api_state)
                {
                    case 0:
                        if (rx_data == 0xFA || rx_data == 0xFB || rx_data == 0x5A)
                        {
                            if(rx_data == 0xEA)
                            {
                                meta_api_state = 1;
                            }
                            else
                            {
                                meta_api_state = 2;
                            }
                            meta_api_extend_idx = 0;
                            meta_api_len = 0;
                            meta_api_buf_idx = 0;
                            meta_api_buf = new Byte[256];
                            meta_api_buf[meta_api_buf_idx++] = rx_data;
                        }
                        break;
                    case 1:
                        if (rx_data == 0xEA)
                        {
                            meta_api_state = 2;
                        }
                        else
                        {
                            meta_api_state = 0;
                        }
                        break;
                    case 2:

                        if(meta_api_buf[meta_api_buf_idx-2] == 0x5A ){
                            meta_api_version = (Int16)(rx_data & 0x3F);
                        }
                        else
                        {
                            meta_api_version = (Byte)(rx_data >> 6);
                        }

                        meta_api_rx_idx = 0;
                        
                        if (meta_api_version <= 2)
                        {
                            meta_api_len = (Byte)(rx_data & 0x3F);
                            meta_api_state = 6;
                        }
                        else
                        {
                            meta_api_state = 3;
                        }
                        break;
                    case 3:
                        {
                            meta_api_data_type = rx_data;
                            meta_api_state = 4;
                        }
                        break;
                    case 4:
                        {
                            meta_api_len = (UInt16)(rx_data);
                            meta_api_state = 5;
                        }
                        break;
                    case 5:
                        {
                            meta_api_len |= (UInt16)(((UInt16)rx_data) << 8);
                        }
                        break;
                    case 6:
                        meta_api_cmdset = rx_data;

                        if (meta_api_version < 2)
                            meta_api_state = 8;
                        else
                            meta_api_state = 7;
                            
                        break;
                    case 7:
                        meta_api_cmdset |= (UInt16)(((UInt16)rx_data) << 8);
                        meta_api_state = 8;
                        break;
                    case 8:
                        meta_api_cmdid = rx_data;

                        if (meta_api_version < 2)
                            meta_api_state = 17;
                        else
                            meta_api_state = 9;
                        break;
                    case 9:
                        meta_api_cmdid |= (UInt16)(((UInt16)rx_data) << 8);
                        meta_api_state = 10;
                        break;
                    case 10:
                        meta_api_state = 11;
                        break;
                    case 11:
                        meta_api_extend_len = (Byte)(rx_data & 0x0F);
                        meta_api_state = 12;
                        break;
                    case 12:
                        meta_api_extend_idx++;
                        if(meta_api_extend_idx == meta_api_extend_len)
                        {
                            meta_api_state = 13;
                        }
                        break;
                    //seq
                    case 13:
                        meta_api_seq = rx_data;
                        meta_api_state = 14;
                        break;                                                                                                                                                                                                                       //aGV5IHRoaXMgcHJvZ3JhbSBpcyB3cml0dGVuIGJ5IGh0dHBzOi8vZ2l0aHViLmNvbS95b3VrcGFu
                    case 14:
                        meta_api_seq |= (UInt16)(((UInt16)rx_data) << 8);
                        meta_api_state = 15;

                        if (meta_api_version < 16)
                            meta_api_state = 17;
                        else
                            meta_api_state = 15;
                        break;

                    case 15:
                        meta_api_crc16 = (UInt16)rx_data; 
                        meta_api_state = 16;
                        break;
                    case 16:
                        meta_api_crc16 |= (UInt16)((UInt16)rx_data << 8);

                        UInt16 crc16_d = crc16_obj.crc16_init();

                        meta_api_crc16_calc = crc16_obj.crc16_update(crc16_d, meta_api_buf, meta_api_len);

                        if(meta_api_crc16 != meta_api_crc16_calc)
                        {
                            meta_api_state = 0;
                        }
                        else
                        {
                            meta_api_state = 17;
                        }
                        break;
                    case 17:
                        meta_api_data_buf[meta_api_rx_idx] = rx_data;
                        meta_api_rx_idx++;

                        UInt16 data_len = 0;
                        if (meta_api_version == 1)
                            data_len = (UInt16)(meta_api_len - 6);
                        else if (meta_api_version == 2)
                            data_len = (UInt16)(meta_api_len - 11);
                        else if (meta_api_version >= 16)
                            data_len = (UInt16)(meta_api_len - 22 - meta_api_extend_len);

                        if (meta_api_rx_idx == data_len)
                        {
                            meta_api_state = 18;
                        }
                        break;
                    case 18:
                        if (meta_api_version < 16)
                            meta_api_crc16 = (UInt16)rx_data;
                        else
                            meta_api_crc32 = (UInt32)rx_data;

                        meta_api_state = 19;
                        break;
                    case 19:

                        if (meta_api_version < 16)
                        {
                            meta_api_crc16 |= (UInt16)((UInt16)rx_data << 8);
                            meta_api_crc16_calc = crc16_obj.crc16_init();

                            meta_api_crc16_calc = crc16_obj.crc16_update(meta_api_crc16_calc, meta_api_buf, meta_api_len);

                            if (meta_api_crc16 == meta_api_crc16_calc)
                            {
                                Process_metaverse_packet(meta_api_cmdset, meta_api_cmdid, meta_api_buf, meta_api_len, meta_api_data_buf, meta_api_len);
                            }

                            meta_api_state = 0;
                        }
                        else
                        {
                            meta_api_crc32 |= (UInt32)((UInt32)rx_data << 8);
                            meta_api_state = 20;
                        }

                        break;

                    case 20:
                        meta_api_crc32 |= (UInt32)((UInt32)rx_data << 16);
                        meta_api_state = 21;
                        break;
                    case 21:
                        meta_api_crc32 |= (UInt32)((UInt32)rx_data << 24);
                        meta_api_crc32_calc = crc32_obj.crc32_init();

                        meta_api_crc32_calc = crc32_obj.crc32_update(meta_api_crc32_calc, meta_api_buf, meta_api_len);

                        if(meta_api_crc32_calc == meta_api_crc32)
                        {
                            Process_metaverse_packet(meta_api_cmdset, meta_api_cmdid, meta_api_buf, meta_api_len, meta_api_data_buf, meta_api_len);
                        }
                        
                        meta_api_state = 0;
                        break;

                }
            }
        }
        #endregion

        private void save_packet()
        {
            long time_passed_ms = DateTime.Now.ToUniversalTime().Ticks / 10000 - mainform.start_time_ms;                                                                                                                                                                      // //im the author :dGhpcyBwcm9ncmFtIGlzIHdyaXR0ZW4gYnkgeW91a3BhbkBnbWFpbC5jb20=

            if (mainform != null)
            {
                mainform.rcv_pkg_counter_all++;
                if (mainform.saveDataFS != null && mainform.radioButtonFileSave.Checked)
                {
                    try
                    {
                        var time_info = "";
                        //version,timstamp,counter,buf_data
                        var data_hex_str = BitConverter.ToString(meta_api_data_buf, 0, meta_api_len).Replace("-", string.Empty);
                        if (last_time_ticks != time_passed_ms)
                        {
                            last_time_ticks = time_passed_ms;
                            time_info = time_passed_ms.ToString();
                        }

                        if (last_save_data != data_hex_str)
                        {
                            last_save_data = data_hex_str;
                            var write_msg = mainform.rcv_pkg_counter_all + "," + data_hex_str + "\n";
                            byte[] info = new UTF8Encoding(true).GetBytes(write_msg);
                            mainform.saveDataFS.Write(info, 0, info.Length);
                        }

                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }
        }

        public void unit_test()
        {
            //(Byte version, Byte data_type, Byte cmd_type, Byte ENC, UInt16 cmd_set, UInt16 cmd_id, Byte extend_len, UInt16 SEQ, Byte[] data_buf, UInt16 data_len)
            var data_len = 1000;
            var data_buf = new Byte[data_len];
            for(int i = 0; i < data_len; i++)
            {
                data_buf[i] = (Byte)i;
            }
            Byte version;
            Byte data_type = 1;
            Byte cmd_type = 0x20;
            Byte ENC = 0;
            UInt16 cmd_set = 0;
            UInt16 cmd_id = 0;
            Byte extend_len = 0;
            UInt16 SEQ = 0;

            for ( version =0; version<16; version++)
            {
                var buf = metaverseProtocalGen(version, data_type, cmd_type, ENC, cmd_set, cmd_id, extend_len, SEQ, data_buf, data_len);

                metaverseProtocalRecev(buf, buf.Length);
            }

        }
    }
}
