
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaperItem: BaseItem
{
    public override void Interaction()
    {
        MenuScript.Instance.GetComponent<PaperContentGenerator>().PickUpUser();
        GameObject.Destroy(this.gameObject);
    }
}