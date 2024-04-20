using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputStateManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private GameObject nand;
    private bool currentState;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.green;
        label.text = "1";
        nand.GetComponent<Nand>().OutputChanged += nand_OutputChanged;
    }

    private void nand_OutputChanged(bool outputState)
    {
        currentState = outputState; 
        switch (currentState)
        {
            case false:
                rend.material.color = Color.red;
                label.text = "0";
                break;
            case true:
                rend.material.color = Color.green;
                label.text = "1";
                break;
        }

    }
}
