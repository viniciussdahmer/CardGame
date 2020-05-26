using System;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject Card;

    private bool _wasClicked = false;
    private static readonly int Color = Shader.PropertyToID("_Color");
    private const int MaxCardsToBeDrawn = 5;

    private const String PlayerCardTag = "PlayerCard";
    private const String EnemyCardTag = "EnemyCard";

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
            GameObject enemyCard = CreateCard();
            AssignPropertiesToCards(playerCard, enemyCard);
            deckCounterScript.UpdateNumberOfCardsInTheDeck(1);
        }
    }

    private GameObject CreateCard()
    {
        return Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void AssignPropertiesToCards(GameObject playerCard, GameObject enemyCard)
    {
        playerCard.transform.SetParent(PlayerArea.transform, false);
        playerCard.tag = PlayerCardTag;
        enemyCard.transform.SetParent(EnemyArea.transform, false);
        enemyCard.tag = EnemyCardTag;
    }
}
