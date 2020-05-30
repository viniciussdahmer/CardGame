using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    private int _attack;
    private int _life;
    
    public Text attackText;
    public Text lifeText;

    private const String PlayerCardTag = "PlayerCard";
    private const String EnemyCardTag = "EnemyCard";

    public void SetAttributes(bool isPlayerCard, GameObject parentArea)
    {
        SetGameObjectProperties(isPlayerCard, parentArea);
        SetCardAttributes();
        SetCardVisualProperties();
    }

    private void SetGameObjectProperties(bool isPlayerCard, GameObject parentArea)
    {
        if (isPlayerCard)
        {
            gameObject.tag = PlayerCardTag;
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.tag = EnemyCardTag;
            gameObject.GetComponent<Image>().color = Color.red;
        }
        gameObject.transform.SetParent(parentArea.transform, false);
    }
    
    private void SetCardAttributes()
    {
        _attack = Random.Range(1, 10);
        _life = Random.Range(1, 15);
    }

    private void SetCardVisualProperties()
    {
        attackText.text = _attack.ToString();
        lifeText.text = _life.ToString();
    }

}
