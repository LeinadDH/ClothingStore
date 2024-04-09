using UnityEngine;
using TMPro;

public class ShowTrunks : MonoBehaviour
{
    [SerializeField] private IntValue _trunk;
    [SerializeField] private TextMeshProUGUI _trunkText;

    private void Update()
    {
        _trunkText.text = _trunk.value.ToString();
    }
}
