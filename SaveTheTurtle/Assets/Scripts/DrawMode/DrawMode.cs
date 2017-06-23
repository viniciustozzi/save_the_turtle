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
    private NetworkManager mNetwork;
    private TurtleBehaviour mTurtle;

    private readonly Color whiteTransp = new Color(0, 0, 0, 0.0f);

    private void Start()
    {
        mNetwork = FindObjectOfType<NetworkManager>();
        mGridLayout = GetComponent<GridLayoutGroup>();
        mTurtle = FindObjectOfType<TurtleBehaviour>();

        prefabPixel.rectTransform.sizeDelta = new Vector2(mGridLayout.cellSize.x, mGridLayout.cellSize.y);

        int nHorizontal = widthScreen / Convert.ToInt32(mGridLayout.cellSize.x);
        int nVertical = heightScreen / Convert.ToInt32(mGridLayout.cellSize.y);

        //mQttPixels = nHorizontal * nVertical;
        mQttPixels = 2840;

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
        float[] m = new float[mQttPixels];

        List<Image> pixels = new List<Image>();
        foreach (Transform t in transform)
            pixels.Add(t.GetComponent<Image>());

        for (int i = 0; i < mQttPixels; i++)
        {
            if (pixels[i].color == Color.black)
                m[i] = 0;
            else
                m[i] = 1;
        }

        mNetwork.SendData(m, (int res) =>
        {
            mTurtle.ApplyDraw((DrawType)res);
        });

        ClearAll();
    }

    private void ClearAll()
    {
        foreach (Transform t in transform)
            t.GetComponent<Image>().color = whiteTransp;
    }
}
