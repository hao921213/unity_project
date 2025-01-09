using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1; // 每次攻擊的傷害
    public float startTime = 1f; // 攻擊啟動延遲
    public float time = 0.001f; // 攻擊持續時間

    private Animator anim;
    private PolygonCollider2D Collider2D;

    public player1 hp;
    public health_bar health_change;

    public float invincibleTime = 0.5f; // 無敵時間（秒）
    public bool isInvincible = false; // 是否處於無敵狀態

    public Enemy_Hp h;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
        Collider2D.enabled = false; // 初始禁用攻擊碰撞框
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack1();
        }
    }

    void Attack1()
    {
        Collider2D.enabled = true; // 啟用攻擊碰撞框
        anim.SetTrigger("onattack");
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime); // 延遲啟動
        Collider2D.enabled = true; // 啟用攻擊碰撞框
        yield return new WaitForSeconds(time); // 攻擊持續時間
        Collider2D.enabled = false; // 禁用攻擊碰撞框
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("碰撞檢測到：" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("enemy1"))
        {
            Debug.Log("碰到了敵人：" + collision.gameObject.name);

            Vector2 knockbackDirection = collision.transform.position - transform.position;

            // 嘗試對敵人扣血
            Enemy_Hp enemyHp = collision.gameObject.GetComponent<Enemy_Hp>();
            if (enemyHp != null)
            {
                enemyHp.TakeDamage(damage, knockbackDirection);// 傳遞擊退方向
                Debug.Log("敵人持續扣血：" + h.Hp);
                //StartCoroutine(strong());
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isInvincible)
        {
            // 檢測是否碰到敵人
            if (collision.gameObject.CompareTag("enemy1"))
            {
                //Enemy_Hp enemyHp = collision.gameObject.GetComponent<Enemy_Hp>();
                //if (enemyHp != null)
                //{
                //    enemyHp.TakeDamage(damage); // 扣怪物血量
                //    StartCoroutine(strong());
                //}
                health_change.TakeDamage(0.01f); // 玩家扣血
                Debug.Log("玩家血量：" + hp.health);

                if (hp.health <= 0)
                {
                    Debug.Log("玩家死亡，切換場景");
                    SceneManager.LoadScene("Home");
                    hp.health = 10; // 重置血量
                }
            }
        }
    }

    private IEnumerator strong()
    {
        isInvincible = true; // 設置為無敵
        Debug.Log("無敵開");
        yield return new WaitForSeconds(invincibleTime); // 等待無敵時間結束
        isInvincible = false; // 無敵結束
        Debug.Log("無敵關");
    }
}
