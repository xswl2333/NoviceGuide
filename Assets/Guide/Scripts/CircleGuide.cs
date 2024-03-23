using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGuide : GuideBase
{

    private float r;


    public override void Guide(Canvas canvas, RectTransform target)
    {
        base.Guide(canvas, target);

        //计算半径
        //计算宽和高
        float width = (targetCorners[3].x - targetCorners[0].x) / 2;
        float height = (targetCorners[1].y - targetCorners[0].y) / 2;

        r=Mathf.Sqrt(width*width + height*height);
        this.material.SetFloat("_Slider", r);
    }

}
