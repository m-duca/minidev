using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Variáveis Globais
    // Referência
    public static DialogueManager Instance;

    [Header("Configurações:")]
    [SerializeField] private string[] lines;
    [SerializeField] private float charTimeInterval;

    [Header("Referências:")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueParent;

    // Índices
    private int _currentIndex = 0;
    private int _maxIndex = 0;
    #endregion

    #region Funções Unity
    private void Awake() => Instance = this;

    private void Start()
    {
        dialogueText.text = string.Empty;
        InitDialogue(3);
    }

    private void Update()
    {
        if (dialogueParent.active)
            DialogueInput();
    }
    #endregion

    #region Funções Próprias
    public void InitDialogue(int newMaxIndex) 
    {
        dialogueParent.SetActive(true);
        dialogueText.text = lines[_currentIndex];
        _maxIndex = newMaxIndex;
    }

    private void StopDialogue() => Instance.dialogueParent.SetActive(false);

    private IEnumerator TypeLine() 
    {
        foreach(char c in lines[_currentIndex].ToCharArray()) 
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(charTimeInterval);
        }
    }

    private void DialogueInput() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[_currentIndex])
            {
                if (_currentIndex < _maxIndex) 
                {
                    NextLine();
                }
                else 
                {
                    StopDialogue();
                }
            }
            else 
            {
                StopAllCoroutines();
                dialogueText.text = lines[_currentIndex];
            }
        }
    }

    private void NextLine() 
    {
        _currentIndex++;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    #endregion
}
