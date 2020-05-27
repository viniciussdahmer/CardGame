using UnityEngine;

public class CardAttributes : MonoBehaviour
{
    private int _attack;
    void Start()
    {
        _attack = Random.Range(1, 10);
    }

    public int getAttack()
    {
        return _attack;
    }
}
