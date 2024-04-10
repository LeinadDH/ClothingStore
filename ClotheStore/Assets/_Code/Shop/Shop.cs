using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private IntValue _trunks;
    [SerializeField] private IntValue _coins;
    [SerializeField] private int _clothesPrice = 0;
    
    public void Charge()
    {
        if (_trunks.value >= 5)
        {
            int coinsToAdd = _trunks.value / 5;
            _coins.value += coinsToAdd;
            _trunks.value -= coinsToAdd * 5;
        }
    }
    
    public void BuyClothes()
    {
        if (_coins.value >= _clothesPrice)
        {
            _coins.value -= _clothesPrice;
            gameObject.SetActive(false);
        }
    }
}
