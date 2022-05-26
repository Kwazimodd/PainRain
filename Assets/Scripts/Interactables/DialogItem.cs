using UnityEngine;

public class DialogItem: BaseItem
{
    public override void Interaction()
    {
        MenuScript.Instance.GetComponent<DialogueContentGenerator>().OpenDialogue();
    }        
}