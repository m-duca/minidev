using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Variáveis
    public static TabManager Instance;

    public static GameObject EmailTab, ConfirmationTab, UnityTab;
    #endregion

    #region Funções Unity
    private void Awake()
    {
        Instance = this;
        Init();
    }
    #endregion

    #region Funções Próprias
    private void Init()
    {
        // Pegando referências dos GameObjects
        var windowCanvas = GameObject.Find("Window Canvas");
        EmailTab = windowCanvas.transform.Find("EmailTab").gameObject;
        ConfirmationTab = windowCanvas.transform.Find("ConfirmationTab").gameObject;
    }

    // tab => próximo gameObject que será ativado
    // callingTab => gameObject anterior que será desativado
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