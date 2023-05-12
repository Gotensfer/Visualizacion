using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InfoCloseButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(InfoRenderer.instance.CloseActiveEpisodeInfo);
    }
}
