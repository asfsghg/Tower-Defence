using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardHolderManager : MonoBehaviour
{
    [SerializeField] private Transform _cardHolderPosition; 
    [SerializeField] private GameObject _card;
    [SerializeField] private card[] _cardSO;
    private int _cardAmmount;

    [SerializeField] private GameObject[] _panelCard;
    private int _cost;
    private Sprite _icon;
    
    void Start()
    {
        _cardAmmount = _cardSO.Length;
        _panelCard = new GameObject[_cardAmmount];

        for (int i = 0; i < _cardAmmount; i++)
            CreateCard(i);
    }

    private void CreateCard( int i)
    {
        var card = Instantiate(_card, _cardHolderPosition);
        _panelCard[i] = card;
        _icon = _cardSO[i].icon;
        _cost = _cardSO[i].cost;

        card.GetComponentInChildren<SpriteRenderer>().sprite = _icon;
        card.GetComponentInChildren<TMP_Text>().text = _cost.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
