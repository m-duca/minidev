using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Vari�veis Globais
    // Refer�ncia
    public static DialogueManager Instance;

    [Header("Configura��es:")]
    [SerializeField] private string[] lines;
    [SerializeField] private float charTimeInterval;

    [Header("Refer�ncias:")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueParent;

    // �ndices
    private int _currentIndex = 0;
    private int _maxIndex = 0;
    #endregion

    #region Fun��es Unity
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

    #region Fun��es Pr�prias
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
