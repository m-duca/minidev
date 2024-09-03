using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailTab : MonoBehaviour
{
    [SerializeField] private GameObject engineBtn;

    public void BtnDownload() 
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX("startup");

        engineBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
