using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FillController : MonoBehaviour
{
    [SerializeField] float Time;
    [SerializeField] GameObject CloseButton;
    private Image imageToFill;


    void OnEnable()
    {
        imageToFill = GetComponent<Image>();
        imageToFill.DOFillAmount(1, Time).SetDelay(0.5f).OnComplete(() => { CloseButton.SetActive(true); });
    }

    void OnDisable()
    {
        imageToFill.DORestart();
        CloseButton.SetActive(false);
        imageToFill.fillAmount = 0;
    }    
}
