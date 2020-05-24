using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool _isDragging = false;
    private GameObject _dropZone;
    private GameObject _startParent;
    private GameObject _card;
    private Vector2 _startPosition;

    private void Awake() {
        Canvas = GameObject.Find("Main Canvas");
    }

    void Update()
    {
        if (_isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        _dropZone = collision.gameObject;
    }
    
    private void OnCollisionExit2D(Collision2D collision) {
        _dropZone = null;
    }

    public void StartDrag() {
        _startParent = transform.parent.gameObject;
        _startPosition = transform.position;
        _card = transform.gameObject;
        _isDragging = true;
    }

    public void EndDrag() {
        _isDragging = false;
        PositionCard();
    }

    private void PositionCard()
    {
        if (_card.CompareTag("EnemyCard") && _dropZone != null && _dropZone.CompareTag("EnemyDropZone"))
        {
            transform.SetParent(_dropZone.transform, false);
        }
        else if (!_card.CompareTag("EnemyCard") && _dropZone != null && !_dropZone.CompareTag("EnemyDropZone"))
        {
            transform.SetParent(_dropZone.transform, false);
        }
        else
        {
            transform.position = _startPosition;
            transform.SetParent(_startParent.transform, false);
        }
    } 
}
