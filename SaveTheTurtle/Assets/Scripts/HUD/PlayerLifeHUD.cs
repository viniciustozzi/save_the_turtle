using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeHUD : MonoBehaviour
{

    public List<Image> heartImages;

    private Life mLife;

    private void Start()
    {
        DeactivateAllHearts();

        GetChildrenHearts();

        mLife = FindObjectOfType<TurtleBehaviour>().GetComponent<Life>();

        if (mLife == null)
            Debug.LogWarning("Não encontrou o player turtle na cena.");
        else
            mLife._OnTakeDamage = UpdateHUD;
    }

    public void UpdateHUD()
    {
        DeactivateAllHearts();

        for (int i = 0; i < mLife.CurrentLife; i++)
            heartImages[i].gameObject.SetActive(true);
    }

    private void GetChildrenHearts()
    {
        foreach (Transform t in transform)
            heartImages.Add(t.GetComponent<Image>());
    }

    private void DeactivateAllHearts()
    {
        heartImages.ForEach(x => x.gameObject.SetActive(false));
    }
}
