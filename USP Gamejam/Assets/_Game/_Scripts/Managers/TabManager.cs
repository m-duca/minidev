using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Vari�veis
    public static TabManager Instance;

    private List<GameObject> childsGameObject = new List<GameObject>();

    private GameObject _buttonParent;

    //Desculpa duca mas eu sou noob de programa��o ent vou declarar os objetos um por um (s� por causa do tempo)
    private GameObject buttons;
    private GameObject tabs;
    #endregion

    #region Fun��es Unity
    private void Awake()
    {
        Instance = this;

        ListChilds();

        _buttonParent = GameObject.FindGameObjectWithTag("Buttons");
        buttons = GameObject.FindGameObjectWithTag("Buttons");
        tabs = GameObject.FindGameObjectWithTag("Tabs");
    }
    #endregion

    #region Fun��es Pr�prias
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

    public void ButtonSetState(bool state)
    {
        _buttonParent.SetActive(state);
    }

    public void CloseAllTabs()
    {
        buttons.SetActive(false);
        tabs.SetActive(false);
    }
    #endregion
}