using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCounter : MonoBehaviour
{
    private int _count = 30;
    private Text _text;
    
    private const String TextForSingleCard = " card";
    private const String TextForMultipleCards = " cards";

    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        SetCountText();
    }

    public void UpdateNumberOfCardsInTheDeck(int numberToSubtractFromDeck)
    {
        _count -= numberToSubtractFromDeck;
        SetCountText();
    }
    
    private void SetCountText()
    {
        if (_count == 1)
        {
            _text.text = _count + TextForSingleCard;
        }
        else
        {
            _text.text = _count + TextForMultipleCards;
        }
    }
}
