using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Image))]
public class GuideBase : MonoBehaviour
{
    protected Material material;//材质
    protected Vector3 center;//圆心
    protected RectTransform target;
    protected Vector3[] targetCorners = new Vector3[4];

    protected virtual void Start()
    {


    }

    //引导

    public virtual void Guide(Canvas canvas, RectTransform target)
    {
        material = transform.GetComponent<Image>().material;

        this.target = target;
        //获取中心点

        target.GetWorldCorners(targetCorners);
        //把世界坐标转换为屏幕坐标

        for (int i = 0; i < targetCorners.Length; i++)
        {
            targetCorners[i] = WorldToScreenPoint(canvas, targetCorners[i]);

        }

        center.x = targetCorners[0].x + (targetCorners[3].x - targetCorners[0].x) / 2;
        center.y = targetCorners[0].y + (targetCorners[1].y - targetCorners[0].y) / 2;
        //设置中心点
        material.SetVector("_Center", center);
    }

    public Vector2 WorldToScreenPoint(Canvas canvas, Vector3 world)
    {
        //世界坐标转换屏幕坐标
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, world);
        Vector2 localPoint;
        //屏幕坐标装成局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPoint, canvas.worldCamera, out localPoint);

        return localPoint;
    }


}
