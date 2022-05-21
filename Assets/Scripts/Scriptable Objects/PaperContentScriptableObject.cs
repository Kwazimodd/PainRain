using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class PaperContentScriptableObject : ScriptableObject, IPaperContentProvider
{
    public List<String> Content;

    public List<String> GetContent()
    {
        return Content;
    }
}