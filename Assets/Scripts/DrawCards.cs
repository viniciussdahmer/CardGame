using System;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject Card;

    private bool _wasClicked = false;
    private static readonly int Color = Shader.PropertyToID("_Color");
    private const int MaxCardsToBeDrawn = 5;

    void Start()
    {
        
    }

    public void OnClick() {
        if (!_wasClicked) {
            DrawAllCards();
            _wasClicked = true;
        }
    }

    private void DrawAllCards()
    {
        GameObject deckCounterText = GameObject.Find("DeckCounterText");
        DeckCounter deckCounterScript = deckCounterText.GetComponent<DeckCounter>();
        for (var i = 0; i < MaxCardsToBeDrawn; i++) {
            GameObject playerCard = CreateCard();
            playerCard.GetComponent<Card>().SetAttributes(true, PlayerArea);

            GameObject enemyCard = CreateCard();
            enemyCard.GetComponent<Card>().SetAttributes(false, EnemyArea);

            deckCounterScript.UpdateNumberOfCardsInTheDeck(1);
        }
    }
    private GameObject CreateCard()
    {
        return Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
