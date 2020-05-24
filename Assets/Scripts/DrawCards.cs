using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;

    private List<GameObject> cards = new List<GameObject>();
    private bool _wasClicked = false;
    
    private const int MaxCardsToBeDrawn = 5;

    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }

    public void OnClick() {
        if (!_wasClicked) {
            DrawAllCards();
            _wasClicked = true;
        }
    }

    private void DrawAllCards() {
        for (var i = 0; i < MaxCardsToBeDrawn; i++) {
            GameObject playerCard = CreateCard();
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject enemyCard = CreateCard();
            enemyCard.transform.SetParent(EnemyArea.transform, false);
            enemyCard.tag = "EnemyCard";
        }
    }

    private GameObject CreateCard()
    {
        return Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
