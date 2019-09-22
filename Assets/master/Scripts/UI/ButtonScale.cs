using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float time = 0.2f;
    public Vector3 endValue = new Vector3(1.2f,1.2f,1.2f);
    public int loopCount = -1;
    public UpdateType updatetype;
    public Ease ease;
    public float delaytime = 0;
    private Transform target;
    private Vector3 startScale;

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToScaleEnd(endValue);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToScaleEnd(startScale);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        target = this.transform;
        startScale = target.localScale;
        
    }

     void ToScaleEnd(Vector3 value)
    {
        Tween t = target.DOScale(value, time);
        t.SetUpdate(updatetype);
        t.SetEase(ease);
        t.SetDelay(delaytime);
        t.SetLoops(loopCount);
    }
}
