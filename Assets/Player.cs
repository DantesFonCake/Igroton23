using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health { get; private set; } = GameConst.MaxHealth;
    public HealthBar HealthBar;

    public void TakeDamage()
    {
        Health -= 20;
        HealthBar.UpdateHealthBar();
    }

    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(); 
        }
    }
}