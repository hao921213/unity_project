using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public int Hp = 10; // 初始血量
    public PlayerAttack attack;
    public float knockbackForce = 5f; //被擊飛的力量
    private Rigidbody2D rb;
    int count = 0;

    public player1 money;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        Hp -= damage; // 扣血
        Debug.Log("怪物血量剩餘：" + Hp);

        // 如果血量大於 0，施加擊退效果
        if (Input.GetKeyDown(KeyCode.E) || Hp > 0)
        {
            rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
        if(Hp <= 0)
        {
            Die(); // 血量歸零時死亡
            if(this.gameObject.name == "enemy1")
            {
                money.money += 1000;
                print("money" + money.money);
            }
            if (this.gameObject.name == "enemy2")
            {
                money.money += 500;
                print("money" + money.money);
            }
            if (this.gameObject.name == "enemy3")
            {
                money.money += 1500;
                print("money" + money.money);
            }
            if (this.gameObject.name == "enemy4")
            {
                money.money += 300;
                print("money" + money.money);
            }
            if (this.gameObject.name == "enemy5")
            {
                money.money += 2000;
                print("money" + money.money);
            }
        }

    }

    private void Die()
    {
        Debug.Log("怪物死亡：" + gameObject.name);
        Destroy(gameObject); // 銷毀怪物
    }
}
