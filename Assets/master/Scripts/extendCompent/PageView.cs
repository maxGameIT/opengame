using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class PageView:ScrollRect
{
    public float Duration = 0.2f;
    private int PageCount;
    private Vector2 Size;
    private List<GameObject> pageList;
    private int _curPageIndex;
    [SerializeField]
    private float BeforeValue;
    public float CloseDragDuration = 1;

    protected override void Start()
    {
        _curPageIndex = 0;
        vertical = false;
        horizontal = true;
        pageList = new List<GameObject>();
        horizontalScrollbar.value = 0;
        BeforeValue = 0;
        if (content)
        {
            PageCount = content.childCount;
            for (int i = 0; i < content.childCount; i++)
            {
                RectTransform rect = content.GetChild(i).GetComponent<RectTransform>();
                Size += rect.sizeDelta;
                pageList.Add(content.GetChild(i).gameObject);
            }
            Size -= GetComponent<RectTransform>().sizeDelta;
            Size -= viewport.GetComponent<RectTransform>().sizeDelta;
        }
    }



    public override void OnEndDrag(PointerEventData eventData)
    {
        this.StopMovement();
        float curvalue = this.horizontalScrollbar.value;
        float pageWidth = 0;
        float Nextvalue = 0;
        float Prevalue = 0;
        for (int i = 0; i <= _curPageIndex; i++)
        {
            if (i % 2 == 0)
            {
                pageWidth +=  pageList[i].GetComponent<RectTransform>().sizeDelta.x/2;
            }
            else
            {
                pageWidth +=  pageList[i].GetComponent<RectTransform>().sizeDelta.x;
            }
            Nextvalue +=  pageList[i].GetComponent<RectTransform>().sizeDelta.x;
            if (i <= _curPageIndex-1)
            {
                Prevalue += pageList[i].GetComponent<RectTransform>().sizeDelta.x;
            }
        }

        float per = pageWidth / Size.x;
        Nextvalue = Nextvalue / Size.x;
        Prevalue = Prevalue / Size.x;
        Nextvalue = Nextvalue < 1 ? Nextvalue : 1;
        if (curvalue > BeforeValue)//xiangzuo
        {
            if (curvalue >= per && _curPageIndex < PageCount - 1)
            {
                ++_curPageIndex;
                DOTween.To(() => this.horizontalScrollbar.value, x => this.horizontalScrollbar.value = x, Nextvalue, Duration);
                BeforeValue = Nextvalue;
            }
            else if(_curPageIndex >= PageCount - 1)
            {
                this.horizontalScrollbar.value = 1;
                BeforeValue = 1;
            }
            else if(curvalue < per)
            {
                DOTween.To(() => this.horizontalScrollbar.value, x => this.horizontalScrollbar.value = x, BeforeValue, Duration);
            }
        }
        else if(curvalue < BeforeValue)//xiangyou 
        {
            if (curvalue <= per && _curPageIndex > 0)
            {
                --_curPageIndex;
                DOTween.To(() => this.horizontalScrollbar.value, x => this.horizontalScrollbar.value = x, Prevalue, Duration);
                BeforeValue = Prevalue;
            }
            else if (_curPageIndex <= 0)
            {
                this.horizontalScrollbar.value = 0;
                BeforeValue = 0;
            }
            else if (curvalue > per)
            {
                DOTween.To(() => this.horizontalScrollbar.value, x => this.horizontalScrollbar.value = x, BeforeValue, Duration);
            }
        }
    }




}
