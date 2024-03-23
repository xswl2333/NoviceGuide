using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RectGuide : GuideBase
{
    private float width;//镂空区域的宽
    private float height;

    //引导

    public override void Guide(Canvas canvas,RectTransform target)
    {
        base.Guide(canvas,target);
       
        //计算宽和高
        width = (targetCorners[3].x - targetCorners[0].x)/2;
        height =(targetCorners[1].y - targetCorners[0].y)/2;

        material.SetFloat("_SliderX", width);
        material.SetFloat("_SliderY", height);
    }

}
