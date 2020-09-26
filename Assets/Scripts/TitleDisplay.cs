using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


//Display the Title data that is readed from the JSON.
public class TitleDisplay : MonoBehaviour
{
    public JsonParser jsonReader;
    public TextMeshProUGUI title;

    void Start()
    {
        RenderTitle();
    }

    public void RenderTitle()
    {
        title.text = jsonReader.Title;
    }
}
