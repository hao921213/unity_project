using UnityEngine;
using System.Collections;
using System.Threading;


public class day7monster : MonoBehaviour
{
   public GameObject[] monsterPrefabs; // 不同種類的怪物
    public Vector2 mapBottomLeft;
    public Vector2 mapTopRight;
    public float spawnInterval = 2f;   // 生成間隔
    public int maxMonsters = 10;       // 最大生成數量

    public time1 time1;

    private int currentMonsterCount = 0; // 當前已生成的怪物數量

    void Start()
    {
        
         
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(time1.day % 7 == 0 && time1.hour > 19)
        {
            StartCoroutine(SpawnMonstersOverTime());  
        }
    }

    IEnumerator SpawnMonstersOverTime()
    {
        while (currentMonsterCount < maxMonsters)
        {
            float randomX = Random.Range(mapBottomLeft.x, mapTopRight.x);
            float randomY = Random.Range(mapBottomLeft.y, mapTopRight.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // 隨機選擇怪物
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);
            Instantiate(monsterPrefabs[monsterIndex], spawnPosition, Quaternion.identity);

            currentMonsterCount++; // 增加當前怪物數量

            yield return new WaitForSeconds(spawnInterval); // 等待指定間隔再生成
        }
    }
}
