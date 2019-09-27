using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Master
{
    public class MoveItem : MonoBehaviour
    {
       
      
        private IEnumerator moveCoroutine;
        private item m_item;
        private void Awake()
        {
            m_item = GetComponent<item>();
        }


        public void Move(int newX,int newY,float time)
        {
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = MoveCoroutine(newX, newY, time);
            StartCoroutine(moveCoroutine);
        }


        private IEnumerator MoveCoroutine(int newX,int newY,float time)
        {
            m_item.X = newX;
            m_item.Y = newY;
            RectTransform rectTransform = GetComponent<RectTransform>();
            Vector2 startpos = rectTransform.anchoredPosition;
            Vector2 endpos = new Vector2(newX * 106 + 50,  450 - newY * 80);
            for (float t = 0; t < time; t+= Time.deltaTime)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(startpos,endpos,t/time);
                yield return 0;
            }
            rectTransform.anchoredPosition = endpos;
        }


    }
}

