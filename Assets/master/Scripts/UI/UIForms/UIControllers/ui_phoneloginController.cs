using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public partial class ui_phonelogin : UGuiForm
    {
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            Toggle tog = this.tog_pwd_login.GetComponent<Toggle>();
            Toggle tog1 = this.tog_pwd_login.GetComponent<Toggle>();
            tog.onValueChanged.AddListener(enter_pwd);
            tog1.onValueChanged.AddListener(enter_pwd);

            transform.Find("group").GetComponent<ToggleGroup>().NotifyToggleOn(tog);
            transform.Find("group").GetComponent<ToggleGroup>().NotifyToggleOn(tog1);


            this.btn_exit.GetComponent<Button>().onClick.AddListener(OnBack);
            this.pwd_login.transform.Find("btn_ok").GetComponent<Button>().onClick.AddListener(okpassword);
            this.yzm_login.transform.Find("btn_ok").GetComponent<Button>().onClick.AddListener(okyzm);
            this.pwd_login.transform.Find("btn_zhuce").GetComponent<Button>().onClick.AddListener(zhuce);
            this.pwd_login.transform.Find("btn_findpwd").GetComponent<Button>().onClick.AddListener(findpwd);
            this.yzm_login.transform.Find("btn_zhuce").GetComponent<Button>().onClick.AddListener(zhuce);
            this.yzm_login.transform.Find("btn_findpwd").GetComponent<Button>().onClick.AddListener(findpwd);
            Button send = this.yzm_login.transform.Find("password").GetComponentInChildren<Button>();
            send.onClick.AddListener(sendyzm);

            if (!ugame.Instance().playerData.is_guest)
            {
                InputField phone = this.pwd_login.transform.Find("phoneNum").GetComponentInChildren<InputField>();
                InputField pwd = this.pwd_login.transform.Find("password").GetComponentInChildren<InputField>();
                phone.text = ugame.Instance().playerData.uname;
                pwd.text = ugame.Instance().playerData.upwd;
            }
        }

        void enter_pwd(bool flag)
        {
            this.pwd_login.SetActive(flag);
            this.yzm_login.SetActive(!flag);
        }

        void sendyzm()
        {
            InputField phone = this.pwd_login.transform.Find("phoneNum").GetComponentInChildren<InputField>();
            if (string.IsNullOrEmpty(phone.text) || phone.text.Length != 11)
            {
                return;
            }
            auth.get_phone_reg_verify_code(phone.text);
        }


        void okyzm()
        {
            InputField phone = this.pwd_login.transform.Find("phoneNum").GetComponentInChildren<InputField>();
            InputField pwd = this.pwd_login.transform.Find("password").GetComponentInChildren<InputField>();
            if (phone.text.Length != 11 || string.IsNullOrEmpty(phone.text))
            {

                return;
            }
            if (string.IsNullOrEmpty(pwd.text) || pwd.text.Length != 6)
            {
                return;
            }
            auth.phone_login(phone.text, pwd.text);
        }

        void okpassword()
        {
            InputField phone = this.pwd_login.transform.Find("phoneNum").GetComponentInChildren<InputField>();
            InputField pwd = this.pwd_login.transform.Find("password").GetComponentInChildren<InputField>();
            if (phone.text.Length != 11 || string.IsNullOrEmpty( phone.text))
            {

                return;
            }
            if (string.IsNullOrEmpty( pwd.text))
            {
                return;
            }
            ugame.Instance().save_temp_uname_and_upwd(phone.text,pwd.text);
            auth.uname_login();
        }

        void zhuce()
        {
            Close();
            GameEntry.UI.OpenUIForm(UIFormId.ui_phoneregister);
        }

        void findpwd()
        {
            Close();
            GameEntry.UI.OpenUIForm(UIFormId.ui_forgetpassword);
        }



        void OnBack()
        {
            Close();
            GameEntry.UI.OpenUIForm(UIFormId.ui_login);
        }



        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}


