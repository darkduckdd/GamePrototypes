using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISafeAreaHandler : MonoBehaviour
{
    RectTransform panel;

    void Start()
    {
        panel = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect area = Screen.safeArea;

        //Размер пикселя в пространстве экрана всего экрана
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        //Установите якоря в процентах от используемого экрана.
        panel.anchorMin = area.position / screenSize;
        panel.anchorMax = (area.position + area.size) / screenSize;

       

    }
}
