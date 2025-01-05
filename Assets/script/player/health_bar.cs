using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    public Slider healthSlider;  // ��q�� Slider
    public float maxHealth = 10f;
    public player1 player;

    private void Start()
    {
        UpdateHealthBar();
    }
    

    // ��s��q
    public void TakeDamage(float damage)
    {
        player.health -= damage;
        player.health = Mathf.Clamp(player.health, 0, maxHealth);
        UpdateHealthBar();
    }

    // ��_��q
    public void Heal(float amount)
    {
        player.health += amount;
        player.health = Mathf.Clamp(player.health, 0, maxHealth);
        UpdateHealthBar();
    }

    // ��s��q��
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = player.health / maxHealth;
        }
    }
}
