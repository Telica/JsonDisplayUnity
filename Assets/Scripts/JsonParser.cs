using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System;

//Read and Parse the data to more usable Data Structures.
public class JsonParser : MonoBehaviour
{   
    #region variables
    private JsonData jsonData;
    private string path;
    private string jsonString;

    [Tooltip("Put here the route to the file that goes after the streaming asset ")]
    public string pathToFile = "/JsonChallengeAlternative.json";
    private List<string> register;

    public string Title{ get; private set; }
    public List<string> ColumnHeaderList { get; private set; }
    public List<List<string>> ListOfRegisters { get; private set; }

    #endregion
    void Awake()
    {
        JsonDataParsing();
    }

    private void JsonDataParsing()
    {
        ColumnHeaderList = new List<string>();
        ListOfRegisters = new List<List<string>>();

        path = Application.streamingAssetsPath + pathToFile;

        //Read and map the data.
        jsonString = File.ReadAllText(path);
        jsonData = JsonMapper.ToObject(jsonString);

        //Format the data to new data structures.
        //Title.
        try
        {
            Title = jsonData["Title"].ToString();
        }
        catch (Exception e)
        {
            Title = "No Data Found";
            Debug.LogException(e, this);
        }

        //Column Headers.
        foreach (var item in jsonData["ColumnHeaders"])
        {
            try
            {
                ColumnHeaderList.Add(item.ToString());
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }

        //Registers.
        for (int i = 0; i < jsonData["Data"].Count; i++)
        {
            register = new List<string>();
            foreach (var item in ColumnHeaderList)
            {
                try
                {
                    register.Add(jsonData["Data"][i][item].ToString());
                }
                catch (Exception e)
                {
                    register.Add("no data");
                    Debug.LogException(e, this);
                }
            }
            ListOfRegisters.Add(register);
        }
    }

    public void OnReloadButtonPressed()
    {
        JsonDataParsing();
    }
}
