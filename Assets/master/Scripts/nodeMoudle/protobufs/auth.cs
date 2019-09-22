using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master
{
  public static class auth
    {
        public static void guest_login()
        {
            string key = ugame.Instance().playerData.guest_key;
            JsonData data = new JsonData();

            GameEntry.websocketMgr.send_cmd((int)Stype.Auth,(int)Cmd.Auth.GUEST_LOGIN,key);
        }

        public static void uname_login()
        {
            string pwd = utils.GetMD5(ugame.Instance().playerData.upwd);
            JsonData body = new JsonData();
            body["0"] = ugame.Instance().playerData.uname;
            body["1"] = pwd;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth,(int)Cmd.Auth.UNAME_LOGIN, str);
        }


        public static void phone_login(string phone,string code )
        {
            JsonData body = new JsonData();
            body["0"] = phone;
            body["1"] = code;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.PHONE_LOGIN, str);
        }

        public static void edit_profile(string unick, int usex)
        {
            JsonData body = new JsonData();
            body["unick"] = unick;
            body["usex"] = usex;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.EDIT_PROFILE, str);
        }

        public static void get_guess_upgrade_verify_code(string phone_num,string guest_key)
        {
            JsonData body = new JsonData();
            body["0"] = 0;
            body["1"] = phone_num;
            body["2"] = guest_key;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.GUEST_UPGRADE_INDENTIFY, str);
        }
        public static void guest_bind_phone(string phone_num,string pwd,string identifying_code)
        {
            JsonData body = new JsonData();
            body["0"] = phone_num;
            body["1"] = pwd;
            body["2"] = identifying_code;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth,(int)Cmd.Auth.BIND_PHONE_NUM, str);
        }

        public static void get_phone_reg_verify_code(string phone)
        {
            JsonData body = new JsonData();
            body["0"] = 1;
            body["1"] = phone;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.GET_PHONE_REG_VERIFY, str);
        }

        public static void get_forget_pwd_verify_code(string phone)
        {
            JsonData body = new JsonData();
            body["0"] = 2;
            body["1"] = phone;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.GET_FORGET_PWD_VERIFY, str);
        }

        public static void reg_phone_account(string unick,string phone,string pwd,string verify_code)
        {
            JsonData body = new JsonData();
            body["0"] = phone;
            body["1"] = pwd;
            body["2"] = verify_code;
            body["3"] = unick;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.PHONE_REG_ACCOUNT, str);
        }

        public static void reset_user_pwd(string phone,string pwd,string verify_code)
        {
            JsonData body = new JsonData();
            body["0"] = phone;
            body["1"] = pwd;
            body["2"] = verify_code;
            string str = JsonMapper.ToJson(body);
            GameEntry.websocketMgr.send_cmd((int)Stype.Auth, (int)Cmd.Auth.RESET_USER_PWD, str);
        }


    }
}
