using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ComboManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCombo = null;

    int currentCombo = 0;

    Animator myAnim;
    string animComboUp = "ComboUp";

    private void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        textCombo.text = string.Format("{0:#,##0}", currentCombo);

        if(currentCombo > 0)
        {
            myAnim.SetTrigger(animComboUp);
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        textCombo.text = string.Format("{0:#,##0}", currentCombo);
    }
}
