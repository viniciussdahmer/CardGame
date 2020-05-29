using UnityEngine;
using UnityEngine.UI;

public class CardVisualAttributes : MonoBehaviour
{
    public Text attackLabel;
    public Text attackText;
    public Text lifeLabel;
    public Text lifeText;
    
    void Start()
    {
        SetAttributesVisibility();
    }

    public void EndDrag()
    {
        SetAttributesVisibility();
    }
    
    private bool IsParentAnEnemyArea()
    {
        return gameObject.transform.parent.CompareTag("EnemyArea");
    }

    private void SetAttributesVisibility()
    {
        if (IsParentAnEnemyArea())
        {
            attackLabel.enabled = false;
            attackText.enabled = false;
            lifeLabel.enabled = false;
            lifeText.enabled = false;
        }
        else
        {
            attackLabel.enabled = true;
            attackText.enabled = true;
            lifeLabel.enabled = true;
            lifeText.enabled = true;
        }
    }
}
