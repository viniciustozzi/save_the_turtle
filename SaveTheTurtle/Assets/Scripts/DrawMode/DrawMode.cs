using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMode : MonoBehaviour
{
    public Image prefabPixel;
    public int widthScreen;
    public int heightScreen;

    private GridLayoutGroup mGridLayout;
    private int mQttPixels;

    private void Start()
    {
        mGridLayout = GetComponent<GridLayoutGroup>();

        prefabPixel.rectTransform.sizeDelta = new Vector2(mGridLayout.cellSize.x, mGridLayout.cellSize.y);

        int nHorizontal = widthScreen / Convert.ToInt32(mGridLayout.cellSize.x);
        int nVertical = heightScreen / Convert.ToInt32(mGridLayout.cellSize.y);

        mQttPixels = nHorizontal * nVertical;

        for (int i = 0; i < mQttPixels; i++)
        {
            Instantiate(prefabPixel, transform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckDraw();
            ClearAll();

        }
    }

    private void CheckDraw()
    {
        int[] m = new int[mQttPixels];

        List<Image> pixels = new List<Image>();
        foreach (Transform t in transform)
            pixels.Add(t.GetComponent<Image>());

        for (int i = 0; i < mQttPixels; i++)
        {
            if (pixels[i].color == Color.black)
                m[i] = 1;
            else
                m[i] = 0;
        }

        //TODO: Chamar API para validar o vetor!

        ClearAll();
    }

    private void ClearAll()
    {
        foreach (Transform t in transform)
            t.GetComponent<Image>().color = Color.white;
    }
}
