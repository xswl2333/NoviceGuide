using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Image))]
public class GuideBase : MonoBehaviour
{
    protected Material material;//����
    protected Vector3 center;//Բ��
    protected RectTransform target;
    protected Vector3[] targetCorners = new Vector3[4];

    protected virtual void Start()
    {


    }

    //����

    public virtual void Guide(Canvas canvas, RectTransform target)
    {
        material = transform.GetComponent<Image>().material;

        this.target = target;
        //��ȡ���ĵ�

        target.GetWorldCorners(targetCorners);
        //����������ת��Ϊ��Ļ����

        for (int i = 0; i < targetCorners.Length; i++)
        {
            targetCorners[i] = WorldToScreenPoint(canvas, targetCorners[i]);

        }

        center.x = targetCorners[0].x + (targetCorners[3].x - targetCorners[0].x) / 2;
        center.y = targetCorners[0].y + (targetCorners[1].y - targetCorners[0].y) / 2;
        //�������ĵ�
        material.SetVector("_Center", center);
    }

    public Vector2 WorldToScreenPoint(Canvas canvas, Vector3 world)
    {
        //��������ת����Ļ����
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, world);
        Vector2 localPoint;
        //��Ļ����װ�ɾֲ�����
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPoint, canvas.worldCamera, out localPoint);

        return localPoint;
    }


}
