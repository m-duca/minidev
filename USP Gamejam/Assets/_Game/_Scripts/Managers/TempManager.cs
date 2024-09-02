using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    public GameObject email;
    public GameObject confirmationWindow;

    public void OpenEmail()
    {
        email.SetActive(true);
    }

    public void CloseEmail()
    {
        email.SetActive(false);
    }

    public void DownloadAssetsMessage()
    {
        confirmationWindow.SetActive(true);
    }
}
