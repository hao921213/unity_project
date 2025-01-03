using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public enum Status { idle, walk, attack};
    public Status status;
    public bool IsFaceRight;
    public enum Face { Left, Right};
    public Face face;
    public float speed;
    private Transform myTransform;
    public Transform playerTransfrom;
    public float distance;
    void Start()
    {

        //update
        status = Status.idle; //一開始是等待狀態
        if (this.transform.GetComponent<SpriteRenderer>().flipX)
        {
            face = Face.Left;
        }
        else
        {
            face = Face.Right;
        }
        myTransform = this.transform;
        playerTransfrom = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        float dis = Vector3.Distance(myTransform.position,playerTransfrom.position);

        switch (status)
        {
            case Status.idle:
                if(dis <= distance)
                {
                    status = Status.walk;
                }
                break;

            case Status.walk:
                if (dis > distance)
                {
                    status = Status.idle;
                }

                if (playerTransfrom)
                {
                    if (myTransform.position.x >= playerTransfrom.position.x)
                    {
                        face = Face.Left;
                    }
                    else
                    {
                        face = Face.Right;
                    }
                }
                switch (face)
                {
                    case Face.Left:
                        if(myTransform.position.y >= playerTransfrom.position.y)
                        {
                            myTransform.position -= new Vector3(speed * deltaTime, speed*deltaTime, 0);
                        }
                        else
                        {
                            myTransform.position -= new Vector3(speed * deltaTime, -speed * deltaTime, 0);
                        }
                        break;
                    case Face.Right:
                        if (myTransform.position.y >= playerTransfrom.position.y)
                        {
                            myTransform.position += new Vector3(speed * deltaTime, -speed * deltaTime, 0);
                        }
                        else
                        {
                            myTransform.position += new Vector3(speed * deltaTime, speed * deltaTime, 0);
                        }
                        break;

                }
                break;
        }
    }
}
