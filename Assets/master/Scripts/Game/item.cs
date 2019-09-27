using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Master
{
    public class item : MonoBehaviour,IPointerEnterHandler,IPointerDownHandler,IPointerUpHandler
    {
        public enum ItemType
        {
           EMPTY,
           NORMAL,
           BARRIER,
           ROW_CLEAR,
           COLUMN_CLEAR,
           RAINBOWCANDY,
           COUNT
        }
        private ItemType m_type;
        private int x;
        private int y;
        private ColorItem m_coloritem;
        private MoveItem m_moveitem;
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                if (CanMove())
                {
                    x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                if (CanMove())
                {
                    y = value;
                }
                
            }
        }

        public ItemType Type
        {
            get
            {
                return m_type;
            }
        }

        public ColorItem Coloritem
        {
            get
            {
                return m_coloritem;
            }

            set
            {
                m_coloritem = value;
            }
        }

        public MoveItem Moveitem
        {
            get
            {
                return m_moveitem;
            }

            set
            {
                m_moveitem = value;
            }
        }

        public void init(int _x,int _y,ItemType _type)
        {
            x = _x;
            y = _y;
            m_type = _type;
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(_x * 106 + 50,500);
        }

        public bool CanMove()
        {
            return m_moveitem != null;
        }
        public bool CanColor()
        {
            return m_coloritem != null;
        }

        private void Awake()
        {
            m_coloritem = GetComponent<ColorItem>();
            m_moveitem = GetComponent<MoveItem>();
            ui_fight ui = (ui_fight)GameEntry.UI.GetUIForm(UIFormId.ui_fight);
        }



        public void OnPointerEnter(PointerEventData eventData)
        {
            ui_fight ui = (ui_fight)GameEntry.UI.GetUIForm(UIFormId.ui_fight);
            ui.EnterItem(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ui_fight ui = (ui_fight)GameEntry.UI.GetUIForm(UIFormId.ui_fight);
            ui.PressItem(this);
        }
        private bool IsScroll = true;
        public void OnPointerUp(PointerEventData eventData)
        {
            ui_fight ui = (ui_fight)GameEntry.UI.GetUIForm(UIFormId.ui_fight);
            IsScroll = ui.ReleaseItem();
        }

        //public void OnBeginDrag(PointerEventData eventData)
        //{
        //    if (!IsScroll)
        //    {
        //        scrollview.OnBeginDrag(eventData);
        //    }
        //}

        //public void OnDrag(PointerEventData eventData)
        //{
        //    if (!IsScroll)
        //    {
        //        scrollview.OnDrag(eventData);
        //    }
        //}

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    if (!IsScroll)
        //    {
        //        scrollview.OnEndDrag(eventData);
        //    }
        //}
    }
}

