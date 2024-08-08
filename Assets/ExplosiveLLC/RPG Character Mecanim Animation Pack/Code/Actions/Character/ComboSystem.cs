using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private int comboStep;
    private float lastAttackTime;
    public float comboResetTime = 1.0f;

    void Update()
    {
        if (Time.time - lastAttackTime > comboResetTime || comboStep >= 3)
        {
            comboStep = 0; // Reset combo if time exceeds the combo reset time
        }
    }


    public void Attack()
    {
        lastAttackTime = Time.time;
        comboStep++;
        Debug.Log("ComboStep :" + comboStep);
        // Trigger light attack animation based on comboStep
    }

    public void LightAttack()
    {
        lastAttackTime = Time.time;
        comboStep++;
        // Trigger light attack animation based on comboStep
    }

    public void HeavyAttack()
    {
        lastAttackTime = Time.time;
        comboStep++;
        // Trigger heavy attack animation based on comboStep
    }

    public int GetComboStep()
    {
        return comboStep;
    }
}