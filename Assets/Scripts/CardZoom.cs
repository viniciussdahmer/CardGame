using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject _zoomCard;

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
        Destroy(_zoomCard);
    }

    private void ZoomCard()
    {
        _zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 170),
            Quaternion.identity);
        _zoomCard.transform.SetParent(Canvas.transform, false);
        _zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = _zoomCard.GetComponent<RectTransform>();
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
