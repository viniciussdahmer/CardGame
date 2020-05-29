using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    private int _attack;
    private int _life;
    private GameObject _card;
    
    public Text attackText;
    public Text lifeText;

    private Boolean _isPlayerCard;
    private GameObject _parentArea;

    private const String PlayerCardTag = "PlayerCard";
    private const String EnemyCardTag = "EnemyCard";

    public void SetAttributes(bool isPlayerCard, GameObject parentArea)
    {
        _isPlayerCard = isPlayerCard;
        _parentArea = parentArea;
        
        _card = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        if (_isPlayerCard)
        {
            _card.tag = PlayerCardTag;
            _card.GetComponent<Image>().color = UnityEngine.Color.green;
        }
        else
        {
            _card.tag = EnemyCardTag;
            _card.GetComponent<Image>().color = UnityEngine.Color.red;
        }
        _card.transform.SetParent(_parentArea.transform, false);
    }

    void Start()
    {
        _attack = Random.Range(1, 10);
        _life = Random.Range(1, 15);
        SetCardVisualProperties();
    }

    private void SetCardVisualProperties()
    {
        attackText.text = _attack.ToString();
        lifeText.text = _life.ToString();
    }

}
