using System;
using UnityEngine;

public class AxeInteraction : MonoBehaviour
{
    [SerializeField] private BoolValue _getAxe;
    [SerializeField] private BoolValue _boughtAxe;
    [SerializeField] private BoolValue _canChoppingDown;

    private void Start()
    {
        if (_boughtAxe.value)
        {
            gameObject.SetActive(false);
        }
    }

    public void BoughtAxe()
    {
        _boughtAxe.value = true;
        //_canChoppingDown.value = true;
        _getAxe.value = true;
    }
}
