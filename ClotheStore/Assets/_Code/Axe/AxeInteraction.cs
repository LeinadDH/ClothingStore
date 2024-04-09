using UnityEngine;

public class AxeInteraction : MonoBehaviour
{
    [SerializeField] private BoolValue _getAxe;
    [SerializeField] private BoolValue _canChoppingDown;
    void Start()
    {
        if (_getAxe.value)
        {
            gameObject.SetActive(false);
        }
    }
    
    private void OnDisable()
    {
        _getAxe.value = true;
        _canChoppingDown.value = true;
    }
}
