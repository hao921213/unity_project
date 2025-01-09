using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public int Hp = 10; // ��l��q
    public PlayerAttack attack;
    public float knockbackForce = 5f; //�Q�������O�q
    private Rigidbody2D rb;
    int count = 0;

    public player1 money;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        Hp -= damage; // ����
        Debug.Log("�Ǫ���q�Ѿl�G" + Hp);

        // �p�G��q�j�� 0�A�I�[���h�ĪG
        if (Input.GetKeyDown(KeyCode.E) || Hp > 0)
        {
            rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }
        if(Hp <= 0)
        {
            Die(); // ��q�k�s�ɦ��`
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
        Debug.Log("�Ǫ����`�G" + gameObject.name);
        Destroy(gameObject); // �P���Ǫ�
    }
}
