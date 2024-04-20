using System;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    private Renderer rend;

    public event Action<bool> StateChanged;

    bool CurrentState { get; set; }

    private void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
        label.text = "0";
    }

    private void OnMouseDown()
    {
        CurrentState = CurrentState == false ? true : false;
        OnStateChanged();

        switch (CurrentState)
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

    private void OnStateChanged()
    {
        StateChanged?.Invoke(CurrentState);
    }
}
