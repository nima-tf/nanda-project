using System;
using UnityEngine;

public class Nand : MonoBehaviour
{
    [SerializeField] private GameObject _inputA, _inputB;
    [SerializeField] private GameObject _output;
    private bool _out = false;
    private bool aState, bState;

    public event Action<bool> OutputChanged;

    private void Start()
    {
        StateManager a = _inputA.GetComponent<StateManager>();
        StateManager b = _inputB.GetComponent<StateManager>();
        a.StateChanged += a_StateChanged;
        b.StateChanged += b_StateChanged;
    }

    private void NandLogic(bool a, bool b)
    {
        _out = !(a && b);
        OnOutputChanged();
    }


    private void a_StateChanged(bool state)
    {
        aState = state;
        NandLogic(aState, bState);
    }

    private void b_StateChanged(bool state)
    {
        bState = state;
        NandLogic(aState, bState);
    }

    private void OnOutputChanged()
    {
        OutputChanged?.Invoke(_out);
    }
}
