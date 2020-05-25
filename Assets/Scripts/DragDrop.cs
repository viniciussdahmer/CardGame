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

    public void StartDrag()
    {
        if (IsParentADropZone())
        {
            _isDragging = false;
        }
        else
        {
            AssignCardAttributes();
            _isDragging = true;
        }
    }

    public void EndDrag() {
        _isDragging = false;
        PositionCard();
    }

    private void PositionCard()
    {
        if ((_card.CompareTag("EnemyCard") && _dropZone != null && _dropZone.CompareTag("EnemyDropZone")) ||
            (_card.CompareTag("PlayerCard") && _dropZone != null && _dropZone.CompareTag("PlayerDropZone")))
        {
            transform.SetParent(_dropZone.transform, false);
        }
        else
        {
            transform.position = _startPosition;
            transform.SetParent(_startParent.transform, false);
        }
    }

    private bool IsParentADropZone()
    {
        var parent = transform.parent;
        return parent.CompareTag("EnemyDropZone") || parent.CompareTag("PlayerDropZone");
    }

    private void AssignCardAttributes()
    {
        var localTransform = transform;
        _startParent = localTransform.parent.gameObject;
        _startPosition = localTransform.position;
        _card = localTransform.gameObject;
    }
}
