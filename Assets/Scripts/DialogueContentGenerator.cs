using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DialogueContentGenerator : MonoBehaviour
{ 
    [SerializeField] private PaperContentScriptableObject _content;
    [SerializeField] private Text dialogueText;
    [SerializeField] public CanvasGroup input;
    [SerializeField] private CanvasGroup nextButton;
    
    public void OpenDialogue()
    {
        MenuScript.Instance.OpenDialogue();
        if (MenuScript.Instance.paperTextList.Count != 10)
        {
            dialogueText.text = _content.Content[1];
        }
        else
        {
            nextButton.alpha = input.alpha = 1;
            nextButton.blocksRaycasts = input.blocksRaycasts = true;
            dialogueText.text = _content.Content[0];
        }
    }
}