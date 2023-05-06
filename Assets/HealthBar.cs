using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public Player player;

    public void UpdateHealthBar()
    {
        //Debug.Log(player.Health / GameConst.MaxHealth * GameConst.WaveCount);
        healthBarImage.fillAmount = Mathf.Clamp(player.Health / (GameConst.MaxHealth * GameConst.WaveCount), 0, 1f);
    }
}