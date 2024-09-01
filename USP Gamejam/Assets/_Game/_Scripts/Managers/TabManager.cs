using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Vari�veis
    public static TabManager Instance;

    public static GameObject EmailTab, ConfirmationTab, UnityTab;
    #endregion

    #region Fun��es Unity
    private void Awake()
    {
        Instance = this;
        Init();
    }
    #endregion

    #region Fun��es Pr�prias
    private void Init()
    {
        // Pegando refer�ncias dos GameObjects
        var windowCanvas = GameObject.Find("Window Canvas");
        EmailTab = windowCanvas.transform.Find("EmailTab").gameObject;
        ConfirmationTab = windowCanvas.transform.Find("ConfirmationTab").gameObject;
    }

    // tab => pr�ximo gameObject que ser� ativado
    // callingTab => gameObject anterior que ser� desativado
    public void OpenTab(Tabs.Default tab, GameObject callingTab)
    {
        switch (tab)
        {
            case Tabs.Default.Email:
                EmailTab.SetActive(true);
                break;

            case Tabs.Default.Confirmation:
                ConfirmationTab.SetActive(true);
                break;
        }

        callingTab.SetActive(false);
    }
    #endregion
}