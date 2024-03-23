using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GuideType
{
    Rect,
    Circle
}

[RequireComponent(typeof(RectGuide))]
[RequireComponent(typeof(CircleGuide))]

public class GuideController : MonoBehaviour
{
    private CircleGuide circleGuide;
    private RectGuide rectGuide;

    public Material rectMat;
    public Material circleMat;

    private Image Mask;

    private void Awake()
    {
        Mask = transform.GetComponent<Image>();
        if(Mask == null )
        {
            throw new System.Exception("mask初始化失败");
        }

        if (rectMat == null|| circleMat==null)
        {
            throw new System.Exception("材质初始化失败");
        }

        circleGuide = transform.GetComponent<CircleGuide>();
        rectGuide = transform.GetComponent<RectGuide>();  
    }

    public void Guide(Canvas canvas, RectTransform target, GuideType type)
    {
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

}
