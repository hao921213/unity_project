using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    public Slider healthSlider;  // 血量條 Slider
    public float maxHealth = 5f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // 更新血量
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // 恢復血量
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // 更新血量條
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }
}
