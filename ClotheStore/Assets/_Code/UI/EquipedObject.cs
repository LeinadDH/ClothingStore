using UnityEngine;

public class EquipedObject : MonoBehaviour
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
        if(_boughtAxe.value && !_equipedObject.value)
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

    public void UnEquipObject()
    {
        _UIObjectToEquip.SetActive(true);
        _UICharacterobject.SetActive(false);
        _objectToEquip.SetActive(false);
        _equipedObject.value = true;
        _button.SetActive(false);
        if (_isAxe)
        {
            _canChopping.value = false;
        }
    }
}
