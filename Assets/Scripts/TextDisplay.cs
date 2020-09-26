using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//instance the text UI Elements
public class TextDisplay : MonoBehaviour
{
    public List<string> _registerData;
    public bool _isHeader;
    public GameObject textFieldPrefab;


    void Start()
    {
        InstanceTextElement();
    }

    //instance the text elements.
    private void InstanceTextElement()
    {
        foreach (var element in _registerData)
        {
            var newText = Instantiate(textFieldPrefab);
            newText.GetComponent<TextMeshProUGUI>().text = element;

            if (_isHeader)
            {
                newText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                newText.GetComponent<TextMeshProUGUI>().color = Color.black;
            }

            newText.transform.SetParent(transform);
        }
    }

    //Passing from the RowDisplayer.
    public void RecievedData(List<string> registerData, bool isHeader)
    {
        _registerData = registerData;
        _isHeader = isHeader;
    }
}