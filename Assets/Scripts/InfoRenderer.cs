using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRenderer : MonoBehaviour
{
    public static InfoRenderer instance;

    [Header("Cada elemento es el objeto de UI de la info respectiva a los episodios\nNótese que el sistema hará que los objetos se activen/desactiven")]
    public GameObject[] infoObjects;

    GameObject previousActivatedInfoObject;
    GameObject activeInfoObject;

    private void Start()
    {
        instance = this;
    }

    public void DisplayEpisodeInfo(int episode)
    {
        if (previousActivatedInfoObject != null) previousActivatedInfoObject.SetActive(false);


        infoObjects[episode].SetActive(true);

        activeInfoObject = infoObjects[episode];
        previousActivatedInfoObject = infoObjects[episode];
    }

    public void CloseAllEpisodesInfo()
    {
        for (int i = 0; i < infoObjects.Length; i++)
        {
            infoObjects[i].SetActive(false);
        }
    }

    public void CloseActiveEpisodeInfo()
    {
        activeInfoObject.SetActive(false);
    }
}
