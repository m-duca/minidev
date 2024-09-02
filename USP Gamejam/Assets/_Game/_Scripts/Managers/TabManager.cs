using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Variáveis
    public static TabManager Instance;

    private List<GameObject> childsGameObject = new List<GameObject>();
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
        ListChilds();
    }

    public void OpenTab(string newTabName)
    {
        DisableLastChild();
        EnableTargetChild(newTabName);
    }

    public void CloseTab() 
    {
        DisableLastChild();
    }

    private void ListChilds() 
    {
        foreach (Transform child in transform)
        {
            childsGameObject.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    private void DisableLastChild() 
    {
        foreach(GameObject child in childsGameObject) 
        {
            if (child.active)
                child.SetActive(false);   
        }
    }

    private void EnableTargetChild(string name) 
    {
        foreach (GameObject child in childsGameObject)
        {
            if (child.gameObject.name == name)
                child.SetActive(true);
        }
    }

    private void DisableButtons()
    {
        
    }
    #endregion
}