using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    #region Variáveis
    public static TabManager Instance;

    private List<GameObject> childsGameObject = new List<GameObject>();

    private GameObject _buttonParent;

    //Desculpa duca mas eu sou noob de programação ent vou declarar os objetos um por um (só por causa do tempo)
    private GameObject buttons;
    private GameObject tabs;

    public bool IsDragging = false;
    #endregion

    #region Funções Unity
    private void Awake()
    {
        Instance = this;

        ListChilds();

        _buttonParent = GameObject.FindGameObjectWithTag("Buttons");
        buttons = GameObject.FindGameObjectWithTag("Buttons");
        tabs = GameObject.FindGameObjectWithTag("Tabs");
    }

    private void Start()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX("notify 2");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            SFXMouse();
    }

    #endregion

    #region Funções Próprias
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
        if (tabs != null) tabs.SetActive(false);
    }

    public void SFXMouse() 
    {
        if (AudioManager.Instance != null) 
        {
            if (IsDragging) 
                AudioManager.Instance.PlaySFX("click drag " + Random.Range(1, 3));
            else
                AudioManager.Instance.PlaySFX("mouse " + Random.Range(1, 3));
        }
    }

    public void SFXKeyboard() 
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX("teclado " + Random.Range(1, 3));
    }
    #endregion
}