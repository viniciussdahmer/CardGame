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
    private bool wasClicked = false;

    private const int MaxNumberOfCardsToDrawn = 5;

    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }

    public void OnClick() {
        if (!wasClicked) {
            DrawAllCards();
            wasClicked = true;
        }
    }

    private void DrawAllCards() {
        for (var i = 0; i < MaxNumberOfCardsToDrawn; i++)
        {
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
