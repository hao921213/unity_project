using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public int Hp = 10; // ��l��q
    public PlayerAttack attack;
    public float knockbackForce = 5f; //�Q�������O�q
    private Rigidbody2D rb;
    int count = 0;

    public enemy_data ed;
    public enemy_data ed2;
    public enemy_data ed3;
    public enemy_data ed4;
    public enemy_data ed5;
    public player1 money;

    public bag player_bag;

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
            if(this.gameObject.name == "enemy1" || this.gameObject.name == "enemy1(Clone)" )
            {
                money.money += 20;
                print("money" + money.money);
                player_get(ed.item);
            }
            if (this.gameObject.name == "enemy2"|| this.gameObject.name == "enemy2(Clone)")
            {
                money.money += 40;
                print("money" + money.money);
                player_get(ed2.item);
            }
            if (this.gameObject.name == "enemy3"|| this.gameObject.name == "enemy3(Clone)")
            {
                money.money += 60;
                print("money" + money.money);
                player_get(ed3.item);
            }
            if (this.gameObject.name == "enemy4"|| this.gameObject.name == "enemy4(Clone)")
            {
                money.money += 80;
                print("money" + money.money);
                player_get(ed4.item);
            }
            if (this.gameObject.name == "enemy5"|| this.gameObject.name == "enemy4(Clone)")
            {
                money.money += 100;
                print("money" + money.money);
                player_get(ed5.item);
            }
        }

    }

    private void Die()
    {
        Debug.Log("�Ǫ����`�G" + gameObject.name);
        Destroy(gameObject); // �P���Ǫ�
    }

    void player_get(item item){
        Debug.Log(item);
        int full=-1;
        Debug.Log(player_bag.itemlist.Count);
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==item){
                player_bag.itemlist[i].held++;
                bag_controller.RefreshItem();
                return;
            }
        }
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==null){
                full=i;
                break;
            }
        }
        if(full!=-1){
            player_bag.itemlist[full]=item;
            bag_controller.RefreshItem();
        }
        else{
            Debug.Log("背包已滿");
        }
        return;
    }
}
