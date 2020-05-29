using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    public void Awake() {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter() {
        if (!IsAnEnemyCard())
        {
            ZoomCard();
        }
    }
    
    public void OnHoverExit() {
        Destroy(zoomCard);
    }

    private void ZoomCard()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 170),
            Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(162, 240);

        // For debug purposes
        Card test = gameObject.GetComponent<Card>();
        int attack = test.GetAttack();
        Debug.Log("Attack = " + attack);
    }


    private bool IsAnEnemyCard() {
        return gameObject.CompareTag("EnemyCard") ? true : false;
    }

}
