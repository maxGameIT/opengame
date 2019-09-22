using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master
{
    public static class auth_proto
    {
        public static ArrayList decode_guest_login(byte[] cmd_buf)
        {
            ArrayList cmd = new ArrayList();
            cmd.Add(proto_tool.Instance().read_int16(cmd_buf, 0));
            cmd.Add(proto_tool.Instance().read_int16(cmd_buf, 2));

            JsonData body = new JsonData();
            int offset = proto_tool.Instance().header_size;
            body["status"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            if ((int)body["status"] != (int)Respones.OK)
            {
                return cmd;
            }
            offset += 2;

            body["uid"] = proto_tool.Instance().read_uint32(cmd_buf, offset);
            offset += 4;

            ArrayList ret = proto_tool.Instance().read_str_inbuf(cmd_buf, offset);
            body["unick"] = (string)ret[0];
            offset = (int)ret[1];

            body["usex"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;

            body["uface"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;

            body["uvip"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;

            ArrayList ret2 = proto_tool.Instance().read_str_inbuf(cmd_buf, offset);
            body["ukey"] = (string)ret2[0];
            offset = (int)ret2[1];
            cmd.Add(body);
            return cmd;
        }

        public static ArrayList decode_edit_profile(byte[] cmd_buf)
        {
            ArrayList cmd = new ArrayList();
            cmd.Add(proto_tool.Instance().read_int16(cmd_buf, 0));
            cmd.Add(proto_tool.Instance().read_int16(cmd_buf, 2));
            JsonData body = new JsonData();

            int offset = proto_tool.Instance().header_size;
            body["status"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;
            if ((int)body["status"] != (int)Respones.OK)
            {
                return cmd;
            }
            ArrayList ret = proto_tool.Instance().read_str_inbuf(cmd_buf, offset);
            body["unick"] = (string)ret[0];
            offset = (int)ret[1];
            body["usex"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            cmd.Add(body);

            return cmd;
        }

        public static byte[] encode_edit_profile(int stype,int ctype,string body)
        {
            JsonData data = JsonMapper.ToObject(body);
            int unick_len =     extend.utf8_byte_len((string)data["unick"]);
            int total_len = proto_tool.Instance().header_size + (2 + unick_len) + 2;
            byte[] cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);
            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);

            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["unick"], unick_len);
            proto_tool.Instance().write_int16(cmd_buf, offset, (short)data["usex"]);
            offset += 2;
            return cmd_buf;
        }

        public static byte[] encode_upgrade_verify_code(int stype,int ctype,string body)
        {
            JsonData data = JsonMapper.ToObject(body);

            int phone_len = extend.utf8_byte_len((string)data["1"]);
            int guest_key_len = extend.utf8_byte_len((string)data["2"]);

            int total_len = proto_tool.Instance().header_size + 2 + (2 + phone_len) + (2 + guest_key_len);
            byte[] cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);
            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);

            proto_tool.Instance().write_int16(cmd_buf, offset, (short)data["0"]);
            offset += 2;

            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["1"], phone_len);
            proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["2"], guest_key_len);

            return cmd_buf;
        }

        public static byte[] encode_guest_bind_account(int stype, int ctype, string body)
        {
            JsonData data = JsonMapper.ToObject(body);
            int phone_len = extend.utf8_byte_len((string)data["0"]);
            int pwd_len = extend.utf8_byte_len((string)data["1"]);
            int verify_code_len = extend.utf8_byte_len((string)data["2"]);

            int total_len = proto_tool.Instance().header_size + (2 + phone_len) + (2 + pwd_len) + (2 + verify_code_len);
            byte[] cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);
            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);

            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data[0], phone_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data[1], pwd_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data[2], verify_code_len);

            return cmd_buf;
        }

        public static byte[] encode_uname_login(int stype, int ctype, string body)
        {
            JsonData data = JsonMapper.ToObject(body);
            int uname_len = extend.utf8_byte_len((string)data["0"]); 
            int upwd_len = extend.utf8_byte_len((string)data["1"]);

            int total_len = proto_tool.Instance().header_size + (2 + uname_len) + (2 + upwd_len);
            byte[] cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);
            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);

            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["0"], uname_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["1"], upwd_len);

            return cmd_buf;
        }

        public static ArrayList decode_uname_login(byte[] cmd_buf)
        {
            var cmd = new ArrayList();
            cmd.Add( proto_tool.Instance().read_int16(cmd_buf, 0));
            cmd.Add(proto_tool.Instance().read_int16(cmd_buf, 2));
            JsonData body = new JsonData();

            var offset = proto_tool.Instance().header_size;
            body["status"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            if ((int)body["status"] != (int)Respones.OK)
            {
                return cmd;
            }
            offset += 2;

            body["uid"] = proto_tool.Instance().read_uint32(cmd_buf, offset);
            offset += 4;

            ArrayList ret = proto_tool.Instance().read_str_inbuf(cmd_buf, offset);
            body["unick"] = (string)ret[0];
            offset = (int)ret[1];

            body["usex"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;

            body["uface"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;

            body["uvip"] = proto_tool.Instance().read_int16(cmd_buf, offset);
            offset += 2;
            cmd.Add(body);

            return cmd;
        }

        public static byte[] encode_phone_reg_verify_code(int stype, int ctype, string body)
        {
            JsonData data = JsonMapper.ToObject(body);

            int phone_len = extend.utf8_byte_len((string)data["1"]);

            var total_len = proto_tool.Instance().header_size + 2 + (2 + phone_len);
            var cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);
            var offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);

            proto_tool.Instance().write_int16(cmd_buf, offset, (short)data["0"]);
            offset += 2;

            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["1"], phone_len);

            return cmd_buf;
        }

        public static byte[] encode_phone_reg_account(int stype,int ctype,string body)
        {
            JsonData data = JsonMapper.ToObject(body);

            int phone_len = extend.utf8_byte_len((string)data["0"]);
            int pwd_len = extend.utf8_byte_len((string)data["1"]);
            int verify_code_len = extend.utf8_byte_len((string)data["2"]);
            int unick_len = extend.utf8_byte_len((string)data["3"]);


            int total_len = proto_tool.Instance().header_size + (2 + phone_len) + (2 + pwd_len) + (2 + verify_code_len) + (2 + unick_len);
            byte[] cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);

            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["0"], phone_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["1"], pwd_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["2"], verify_code_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["3"], unick_len);

            return cmd_buf;
        }

        public static byte[] encode_reset_upwd(int stype, int ctype, string body)
        {
            JsonData data = JsonMapper.ToObject(body);
            int phone_len = extend.utf8_byte_len((string)data["0"]);
            int pwd_len = extend.utf8_byte_len((string)data["1"]);
            int verify_code_len = extend.utf8_byte_len((string)data["2"]);


            int total_len = proto_tool.Instance().header_size + (2 + phone_len) + (2 + pwd_len) + (2 + verify_code_len);
            var cmd_buf = proto_tool.Instance().alloc_Buffer(total_len);

            int offset = proto_tool.Instance().write_cmd_header_inbuf(cmd_buf, stype, ctype);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["0"], phone_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["1"], pwd_len);
            offset = proto_tool.Instance().write_str_inbuf(cmd_buf, offset, (string)data["2"], verify_code_len);

            return cmd_buf;
        }

    }
}
