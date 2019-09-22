using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public partial class forgetpassword : UGuiForm
    {
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            this.btn_exit.GetComponent<Button>().onClick.AddListener(OnBack);
            this.btn_ok.GetComponent<Button>().onClick.AddListener(okFun);


        }

        void okFun()
        {
            InputField phone = this.phoneNum.GetComponentInChildren<InputField>();
            InputField pass = this.password.GetComponentInChildren<InputField>();
            InputField checkpass = this.checkpassword.GetComponentInChildren<InputField>();
            InputField yanzhengma = this.yzm.GetComponentInChildren<InputField>();
            if (string.IsNullOrEmpty(phone.text) || phone.text.Length != 11)
            {
                return;
            }
            if (pass.text != checkpass.text ||( string.IsNullOrEmpty(pass.text) && string.IsNullOrEmpty(checkpass.text)))
            {
                return;
            }
            if (string.IsNullOrEmpty(yanzhengma.text) || yanzhengma.text.Length != 6)
            {
                return;
            }
            ugame.Instance().save_temp_uname_and_upwd(phone.text, pass.text);
            var pwd = utils.GetMD5(pass.text);
            auth.reset_user_pwd(phone.text,pwd, yanzhengma.text);
        }



        void sendyzm()
        {
            InputField phone = this.phoneNum.GetComponentInChildren<InputField>();
            if (string.IsNullOrEmpty(phone.text) || phone.text.Length != 11)
            {
                return;
            }
            auth.get_forget_pwd_verify_code(phone.text);
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


