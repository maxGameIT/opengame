using GameFramework;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Master
{
    public partial class MessageBoxForm : UGuiForm
    {
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            messageparams = null;
            m_callback = null;
            m_userData = null;
        }
        private Button ok;
        private GameFrameworkAction<object> m_callback;
        private MessageParams messageparams;
        private object m_userData;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            messageparams = (MessageParams)userData;
            m_callback = messageparams.OnClickConfirm;
            m_userData = messageparams.UserData;

            Text message = this.Background.transform.Find("Message").GetComponent<Text>();
            message.text = messageparams.Message;

            ok = this.Background.transform.Find("btn_ok").GetComponent<Button>();
            ok.onClick.AddListener(okFun);
        }

        void okFun()
        {
            if (m_callback != null)
            {
                m_callback(m_userData);
                m_callback = null;
            }
            Close();
        }
      

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}


