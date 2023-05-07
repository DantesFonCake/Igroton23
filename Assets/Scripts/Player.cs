using UnityEngine;


public class Player : MonoBehaviour
{
    public float Health { get; private set; } = GameConst.MaxHealth * GameConst.WaveCount;
    
    public HealthBar healthBar;
    public SceneChange sceneChange;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConst.Tags.Enemy))
        {
            sceneChange.MoveToDieScene();
        }
        
    }
    
    public void TakeDamage(float value = 20)
    {
        Health -= value;
        //Debug.Log($"Current HP: {Health}");
        healthBar.UpdateHealthBar(Health);
    }

    private void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }

        if (Health <= 0)
        {
            sceneChange.MoveToDieScene();
        }
    }
}