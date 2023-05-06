using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health { get; private set; } = GameConst.MaxHealth;
    public HealthBar HealthBar;
    public ScaneChange ScaneChange;

    public void TakeDamage()
    {
        Health -= 20;
        Debug.Log($"Current HP: {Health}");
        HealthBar.UpdateHealthBar();
    }

    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(); 
        }

        if (Health <= 0)
        {
            ScaneChange.MoveToDieScene();
        }
    }
}