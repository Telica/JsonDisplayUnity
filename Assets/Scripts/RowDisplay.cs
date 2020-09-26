using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instantiate the UI Rows element necesary to render the data on screen.
public class RowDisplay : MonoBehaviour
{
    public JsonParser jsonData;
    public GameObject rowPrefab;

    private void Start()
    {
        InstiantateRows();
    }



    private void InstiantateRows()
    {
        // instiante the header row.
        var headerRow = Instantiate(rowPrefab);
        headerRow.GetComponent<TextDisplay>().RecievedData(jsonData.ColumnHeaderList, true);
        headerRow.transform.SetParent(transform);

        //instance the registers rows.
        foreach (var register in jsonData.ListOfRegisters)
        {
            var registerRow = Instantiate(rowPrefab);
            registerRow.GetComponent<TextDisplay>().RecievedData(register, false);
            registerRow.transform.SetParent(transform);
        }
    }

    public void ReInstantiateRows()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        InstiantateRows();
    }
}
