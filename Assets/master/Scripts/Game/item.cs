using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    public class item : MonoBehaviour
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
            rectTransform.anchoredPosition = new Vector2(_x * 106 + 50,700);
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
        }

    }
}

