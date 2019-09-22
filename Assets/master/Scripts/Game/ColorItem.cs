using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Master
{
    public class ColorItem : MonoBehaviour
    {
        public enum ColorType
        {
            OEN,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN
        }
        [Serializable]
        public struct ColorSprite
        {
            public ColorType color;
            public Sprite sprite;
        }

        public ColorSprite[] ColorSprites;

        private Dictionary<ColorType, Sprite> colorSpriteDict;

        public int NumColors
        {
            get
            {
                return ColorSprites.Length;
            }
        }

        public ColorType Color
        {
            get
            {
                return m_color;
            }

            set
            {
                SetColor(value);
            }
        }

        private Image Sprite;
        private ColorType m_color;

        private void Awake()
        {
            Sprite = transform.Find("Sweet").GetComponent<Image>();
            colorSpriteDict = new Dictionary<ColorType, Sprite>();
            for (int i = 0; i < ColorSprites.Length; i++)
            {
                if (!colorSpriteDict.ContainsKey(ColorSprites[i].color))
                {
                    colorSpriteDict.Add(ColorSprites[i].color, ColorSprites[i].sprite);
                }
            }
        }

        public void SetColor(ColorType newColor)
        {
            m_color = newColor;
            if (colorSpriteDict.ContainsKey(newColor))
            {
                Sprite.sprite = colorSpriteDict[newColor];
            }
        }

    }
}

