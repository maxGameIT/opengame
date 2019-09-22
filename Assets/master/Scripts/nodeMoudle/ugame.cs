using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Master
{
    public class ugame
    {
        static ugame g_instance;
        public static ugame Instance()
        {
            if (g_instance == null)
            {
                g_instance = new ugame();
            }
            return g_instance;
        }
        const string GameDataFileName = "GameData.json";
        public GameData playerData;
        const string DataKey = "GameData";

        public class GameData
        {
            public string unick = "";
            public int usex = -1;
            public int uface = 0;
            public int uvip = 0;

            public bool is_guest = false; // 是否为游客账号
            public string guest_key = "";

            public string uname = "";
            public string upwd = "";

            public JsonData game_info = null; // 玩家的游戏数据;

            public int zid = 0; // 玩家的区间信息
        }


       


        /// <summary>
        /// 初始化本地存档
        /// </summary>
        public void init()
        {
            if (!ES3.FileExists(GameDataFileName))
            {
                playerData = new GameData();
                _save_uname_and_upwd();
            }
            ES3Settings settings = new ES3Settings();
            settings.format = ES3.Format.JSON;
            playerData = ES3.Load<GameData>(DataKey, GameDataFileName, settings);
            string uname_and_upwd_json = playerData.guest_key;
            if (string.IsNullOrEmpty(uname_and_upwd_json))
            {
                playerData.is_guest = true;
                playerData.guest_key = utils.random_string(32);
            }
        }

        public void guest_login_success(string unick, int usex,int uface, int uvip,string ukey)
        {
            playerData.unick = unick;
            playerData.usex = usex;
            playerData.uface = uface;
            playerData.uvip = uvip;
            playerData.is_guest = true;
            if (playerData.guest_key != ukey)
            {
                playerData.guest_key = ukey;
                _save_uname_and_upwd();
            }


        }

        public void uname_login_success(string unick, int usex, int uface, int uvip)
        {
            playerData.unick = unick;
            playerData.usex = usex;
            playerData.uface = uface;
            playerData.uvip = uvip;
            playerData.is_guest = false;
            _save_uname_and_upwd();
        }


        void _save_uname_and_upwd()
        {
            ES3Settings setting = new ES3Settings();
            setting.format = ES3.Format.JSON;
            ES3.Save<GameData>(DataKey, playerData, GameDataFileName, setting);
        }

        public void edit_profile_success(string unick, int usex)
        {
            playerData.unick = unick;
            playerData.usex = usex;
        }

        public void save_temp_uname_and_upwd(string uname, string upwd)
        {
            playerData.uname = uname;
            playerData.upwd = upwd;
        }

        public void save_uname_and_upwd()
        {
            playerData.is_guest = false;
            _save_uname_and_upwd();
        }

        public void save_user_game_data(ArrayList data)
        {
            playerData.game_info = new JsonData();
            playerData.game_info["uchip"] = (string)data[1];
            playerData.game_info["uexp"] = (int)data[2];
            playerData.game_info["uvip"] = (int)data[3];
        }

        public void enter_zone(int zid)
        {
            playerData.zid = zid;
        }
    }
}
