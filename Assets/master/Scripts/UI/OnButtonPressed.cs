//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Master
{
    public class OnButtonPressed: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
       
        [SerializeField]
        private UnityEvent m_OnPress = null;

        [SerializeField]
        private UnityEvent m_OnReleas = null;
        private void Awake()
        {
        }

        private void OnDisable()
        {
        }
        void Update()
        {

        }



        public void OnPointerEnter(PointerEventData eventData)
        {
           
        }

        public void OnPointerExit(PointerEventData eventData)
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_OnPress.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_OnReleas.Invoke();
        }
    }
}
