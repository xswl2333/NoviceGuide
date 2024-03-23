using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel : MonoBehaviour
{
    GuideController controller;
    Canvas canvas;

    private void Awake()
    {
        canvas=transform.GetComponentInParent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller=transform.GetComponent<GuideController>();
        controller.Guide(canvas, GameObject.Find("Button").GetComponent<RectTransform>(), GuideType.Rect);

        //ÑÓ³Ùµ÷ÓÃ,monobehaviour
        Invoke("Test", 2);
    }

    void Test()
    {
        controller.Guide(canvas, GameObject.Find("Button1").GetComponent<RectTransform>(), GuideType.Circle);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
