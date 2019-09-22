using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public partial class ui_login : UGuiForm
    {
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            this.youke_btn.GetComponent<Button>().onClick.AddListener( youke_login);
            this.phone_btn.GetComponent<Button>().onClick.AddListener(phone_login);
            this.wechat_btn.GetComponent<Button>().onClick.AddListener(wechat_login);
            this.phonereginster_btn.GetComponent<Button>().onClick.AddListener(Register_login);
            proto_man.Instance().init();
            Dictionary<int, Action<int, int, object>> service_handlers = new Dictionary<int, Action<int, int, object>>();
            service_handlers[(int)Stype.Auth] = on_auth_server_return;
            GameEntry.websocketMgr.register_serivces_handler(service_handlers);
            GameEntry.websocketMgr.connect("ws://127.0.0.1:6081/ws", proto_type.BUF);

        }

        void on_auth_server_return(int stype,int ctype,object body)
        {
            switch (ctype)
            {
                case (int)Cmd.Auth.GUEST_LOGIN:
                    this.guest_login_return((JsonData)body);
                    break;
                case (int)Cmd.Auth.RELOGIN:
                    Debug.Log("Cmd.Auth.RELOGIN: 账号在其他地方登陆，请注意账号安全！！！");
                    break;
                case (int)Cmd.Auth.UNAME_LOGIN:
                    this.uname_login_return((JsonData)body);
                    break;

                case (int)Cmd.Auth.GET_PHONE_REG_VERIFY:
                    this.on_get_phone_reg_verify_return((int)body);
                    break;
                case (int)Cmd.Auth.PHONE_REG_ACCOUNT:
                    this.on_reg_phone_account_return((int)body);
                    break;

                case (int)Cmd.Auth.GET_FORGET_PWD_VERIFY:
                    this.on_get_forget_pwd_verify_return((int)body);
                    break;

                case (int)Cmd.Auth.RESET_USER_PWD:
                    this.on_reset_pwd_return((int)body);
                    break;
            }
        }

        void guest_login_return(JsonData body)
        {
            if ((int)body["status"] != (int)Respones.OK)
            {
                Debug.Log(body);
                return;
            }

            ugame.Instance().guest_login_success((string)body["unick"], (int)body["usex"],(int) body["uface"],
                (int)body["uvip"], (string)body["ukey"]);
        }


         void uname_login_return(JsonData body)
        {
            if ((int)body["status"] != (int)Respones.OK)
            {
                Debug.Log(body);
                return;
            }

            ugame.Instance().uname_login_success((string)body["unick"],(int) body["usex"], (int)body["uface"], (int)body["uvip"]);
            // 保存本次登陆的用户和密码到本地
            ugame.Instance().save_uname_and_upwd();
            // end 
            // cc.director.loadScene("home_scene");
            this.on_auth_login_success();
        }

        void on_get_phone_reg_verify_return(int status)
        {
            if (status != (int)Respones.OK)
            {
                Debug.Log("get verify code err! status: "+ status);
                return;
            }
            Debug.Log("get verify code success! status: "+ status);
        }

        void on_reg_phone_account_return(int status)
        {
            if (status != (int)Respones.OK)
            {
                Debug.Log("phone reg account err status: "+status);
                return;
            }
            ugame.Instance().save_uname_and_upwd();
            auth.uname_login();
        }

        void on_get_forget_pwd_verify_return(int status)
        {
            if (status != (int)Respones.OK)
            {
                Debug.Log("get verify code err! status: "+ status);
                return;
            }

            Debug.Log("get verify code success! status: "+ status);
        }


        void on_reset_pwd_return(int status)
        {
            if (status != (int)Respones.OK)
            {
                Debug.Log("on_reset_pwd_return err status: "+ status);
                return;
            }
            ugame.Instance().save_uname_and_upwd();
            auth.uname_login();
        }

        void on_auth_login_success()
        {

        }


        void youke_login()
        {
            if (ugame.Instance().playerData.is_guest)
            {
                auth.uname_login();
            }
            else
            {
                auth.guest_login();
            }
        }

        void phone_login()
        {
            GameEntry.UI.OpenUIForm(UIFormId.ui_phonelogin);
        }

        void wechat_login()
        {
            Close();
            GameEntry.UI.OpenUIForm(UIFormId.ui_fight);
        }
      
        void Register_login()
        {
            GameEntry.UI.OpenUIForm(UIFormId.ui_phoneregister);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}


