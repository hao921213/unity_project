using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1; // �C���������ˮ`
    public float startTime = 1f; // �����Ұʩ���
    public float time = 0.001f; // ��������ɶ�

    private Animator anim;
    private PolygonCollider2D Collider2D;

    public player1 hp;
    public health_bar health_change;

    public float invincibleTime = 0.5f; // �L�Įɶ��]���^
    public bool isInvincible = false; // �O�_�B��L�Ī��A

    public Enemy_Hp h;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Collider2D = GetComponent<PolygonCollider2D>();
        Collider2D.enabled = false; // ��l�T�Χ����I����
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
        Collider2D.enabled = true; // �ҥΧ����I����
        anim.SetTrigger("onattack");
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime); // ����Ұ�
        Collider2D.enabled = true; // �ҥΧ����I����
        yield return new WaitForSeconds(time); // ��������ɶ�
        Collider2D.enabled = false; // �T�Χ����I����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�I���˴���G" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("enemy1"))
        {
            Debug.Log("�I��F�ĤH�G" + collision.gameObject.name);

            Vector2 knockbackDirection = collision.transform.position - transform.position;

            // ���չ�ĤH����
            Enemy_Hp enemyHp = collision.gameObject.GetComponent<Enemy_Hp>();
            if (enemyHp != null)
            {
                enemyHp.TakeDamage(damage, knockbackDirection);// �ǻ����h��V
                Debug.Log("�ĤH���򦩦�G" + h.Hp);
                //StartCoroutine(strong());
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isInvincible)
        {
            // �˴��O�_�I��ĤH
            if (collision.gameObject.CompareTag("enemy1"))
            {
                //Enemy_Hp enemyHp = collision.gameObject.GetComponent<Enemy_Hp>();
                //if (enemyHp != null)
                //{
                //    enemyHp.TakeDamage(damage); // ���Ǫ���q
                //    StartCoroutine(strong());
                //}
                health_change.TakeDamage(0.1f); // ���a����
                Debug.Log("���a��q�G" + hp.health);

                if (hp.health <= 0)
                {
                    Debug.Log("���a���`�A��������");
                    SceneManager.LoadScene("Home");
                    hp.money = 0;
                    hp.health = 10; // ���m��q
                }
            }
        }
    }

    private IEnumerator strong()
    {
        isInvincible = true; // �]�m���L��
        Debug.Log("�L�Ķ}");
        yield return new WaitForSeconds(invincibleTime); // ���ݵL�Įɶ�����
        isInvincible = false; // �L�ĵ���
        Debug.Log("�L����");
    }
}
