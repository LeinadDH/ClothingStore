using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private IntValue _trunks;
    [SerializeField] private IntValue _coins;
    
    public void Charge()
    {
        if (_trunks.value >= 5)
        {
            int coinsToAdd = _trunks.value / 5;
            _coins.value += coinsToAdd;
            _trunks.value -= coinsToAdd * 5;
        }
    }
}
