using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelBehaviour : MonoBehaviour
{
    private Image img;
    private bool mIsPressing;

    private void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.white;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mIsPressing = true;
        }
        else
        {
            mIsPressing = false;
        }
    }

    public void OnPointerEnter()
    {
        if (mIsPressing)
        {
            img.color = Color.black;
        }
    }
}
