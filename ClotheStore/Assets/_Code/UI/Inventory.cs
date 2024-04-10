using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private BoolValue _boughtAxe;
    [SerializeField] private BoolValue _equipedObject;
    [SerializeField] private GameObject _UIObjectToEquip;
    [SerializeField] private GameObject _UICharacterobject;
    [SerializeField] private GameObject _objectToEquip;
    [SerializeField] private GameObject _button;
    [SerializeField] private BoolValue _canChopping;
    [SerializeField] private bool _isAxe;

    private void Start()
    {
        if(_boughtAxe.value && _equipedObject.value)
        {
            _button.SetActive(true);
            _UICharacterobject.SetActive(true);
            _objectToEquip.SetActive(true);
        }
        else
        {
            _button.SetActive(false);
            _UICharacterobject.SetActive(false);
            _objectToEquip.SetActive(false);
        }
    }

    public void EquipObject()
    {
        _UIObjectToEquip.SetActive(true);
        _UICharacterobject.SetActive(true);
        _objectToEquip.SetActive(true);
        _equipedObject.value = false;
        _button.SetActive(true);
        if (_isAxe)
        {
            _canChopping.value = true;
        }
    }
}
