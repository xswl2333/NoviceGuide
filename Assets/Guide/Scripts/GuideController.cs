using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum GuideType
{
    Rect,
    Circle
}

[RequireComponent(typeof(RectGuide))]
[RequireComponent(typeof(CircleGuide))]

public class GuideController : MonoBehaviour, ICanvasRaycastFilter
{
    private CircleGuide circleGuide;
    private RectGuide rectGuide;

    public Material rectMat;
    public Material circleMat;

    private Image Mask;
    private RectTransform target;

    private void Awake()
    {
        Mask = transform.GetComponent<Image>();
        if(Mask == null )
        {
            throw new System.Exception("mask��ʼ��ʧ��");
        }

        if (rectMat == null|| circleMat==null)
        {
            throw new System.Exception("���ʳ�ʼ��ʧ��");
        }

        circleGuide = transform.GetComponent<CircleGuide>();
        rectGuide = transform.GetComponent<RectGuide>();  
    }

    public void Guide(Canvas canvas, RectTransform target, GuideType type)
    {
        this.target = target;
        switch (type)
        {
            case GuideType.Rect:
                Mask.material = rectMat;
                rectGuide.Guide(canvas, target);
                break;
            case GuideType.Circle:
                Mask.material = circleMat;
                circleGuide.Guide(canvas, target);
                break;


        }


    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if(target==null)
        {
           return true;//�¼�������͸
        }

        return !RectTransformUtility.RectangleContainsScreenPoint(target,sp);
    }

}
