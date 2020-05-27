using UnityEngine;
using UnityEngine.UI;

public class CardAttributes : MonoBehaviour
{
    private int _attack;
    public Text attackText;
    void Start()
    {
        _attack = Random.Range(1, 10);
        SetCardVisualProperties();
    }

    public int GetAttack()
    {
        return _attack;
    }

    private void SetCardVisualProperties()
    {
        attackText.text = _attack.ToString();
    }
}
