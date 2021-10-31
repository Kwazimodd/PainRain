using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PaperContentGenerator : MonoBehaviour
{ 
    [SerializeField] private PaperContentScriptableObject _content;
    private List<string> _contentList;
    private static String _randomString;
    private String _randomStringCopy;

    public string RandomString => _randomString;

    private void Awake()
    {
        _randomString = RandomStrManager.GetRandomString(_content.Content.Count);
        _randomStringCopy = _randomString;
        _contentList = new List<string>(_content.Content);
    }

    public void PickUpUser()
    {
        var randomPaperIndex = new Random().Next(0, _contentList.Count-1);
        MenuScript.Instance.PickUpAndAddPaper(new Tuple<String, String>
        (
            _contentList[randomPaperIndex],
            _randomStringCopy[randomPaperIndex] + randomPaperIndex.ToString()
        ));
        _contentList.RemoveAt(randomPaperIndex);
        _randomStringCopy = _randomStringCopy.Substring(0, randomPaperIndex - 1) +
            _randomStringCopy.Substring(randomPaperIndex + 1, _randomStringCopy.Length - (randomPaperIndex + 1));
    }
}