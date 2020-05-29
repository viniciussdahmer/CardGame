using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject _zoomCard;

    public void Awake() {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter() {
        if ((IsAnEnemyCard() && !IsCardOverAnEnemyArea()) || !IsAnEnemyCard())
        {
            ZoomCard();
        }
    }
    
    public void OnHoverExit() {
        Destroy(_zoomCard);
    }

    private void ZoomCard()
    {
        _zoomCard = CreateZoomCard();
        _zoomCard.transform.SetParent(Canvas.transform, false);
        _zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = _zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(162, 240);
    }

    private bool IsAnEnemyCard() {
        return gameObject.CompareTag("EnemyCard") ? true : false;
    }

    private bool IsCardOverAnEnemyArea()
    {
        return gameObject.transform.parent.CompareTag("EnemyArea");
    }

    private GameObject CreateZoomCard()
    {
        return Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 170),
            Quaternion.identity);
    }

}
