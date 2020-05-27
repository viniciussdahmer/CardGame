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
    
    void Start()
    {
        _attack = Random.Range(1, 10);
        _life = Random.Range(1, 15);
        SetCardVisualProperties();
    }

    public int GetAttack()
    {
        return _attack;
    }

    private void SetCardVisualProperties()
    {
        attackText.text = _attack.ToString();
        lifeText.text = _life.ToString();
    }

}
