using UnityEngine;

public class ClothesController : MonoBehaviour
{
    [SerializeField] private BoolValue _canUseAxe;
    [SerializeField] private BoolValue _canUseSpacebuns;
    [SerializeField] private BoolValue _canUseShirt;
    [SerializeField] private BoolValue _canUsePants;
    [SerializeField] private BoolValue _canUseShoes;
    
    [SerializeField] private GameObject _axe;
    [SerializeField] private GameObject _spacebuns;
    [SerializeField] private GameObject _shirt;
    [SerializeField] private GameObject _pants;
    [SerializeField] private GameObject _shoes;

    private void Update()
    {
        CanUseClothes(_canUseAxe, _axe);
        CanUseClothes(_canUseSpacebuns, _spacebuns);
        CanUseClothes(_canUseShirt, _shirt);
        CanUseClothes(_canUsePants, _pants);
        CanUseClothes(_canUseShoes, _shoes);
    }

    void CanUseClothes(BoolValue clothes, GameObject clothesObject)
    {
        if(clothes.value)
        {
            clothesObject.SetActive(true);
        }
        else
        {
            clothesObject.SetActive(false);
        }
    }
}
