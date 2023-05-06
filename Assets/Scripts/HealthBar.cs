using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    public void UpdateHealthBar(float currentHealth)
    {
        healthBarImage.fillAmount = Mathf.Clamp(currentHealth / (GameConst.MaxHealth * GameConst.WaveCount), 0, 1f);
    }
}