using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ���P�������Ǫ�
    public Vector2 mapBottomLeft;
    public Vector2 mapTopRight;
    public float spawnInterval = 2f;   // �ͦ����j
    public int maxMonsters = 10;       // �̤j�ͦ��ƶq

    private int currentMonsterCount = 0; // ��e�w�ͦ����Ǫ��ƶq

    void Start()
    {
        StartCoroutine(SpawnMonstersOverTime());
    }

    IEnumerator SpawnMonstersOverTime()
    {
        while (currentMonsterCount < maxMonsters)
        {
            float randomX = Random.Range(mapBottomLeft.x, mapTopRight.x);
            float randomY = Random.Range(mapBottomLeft.y, mapTopRight.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // �H����ܩǪ�
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);
            Instantiate(monsterPrefabs[monsterIndex], spawnPosition, Quaternion.identity);

            currentMonsterCount++; // �W�[��e�Ǫ��ƶq

            yield return new WaitForSeconds(spawnInterval); // ���ݫ��w���j�A�ͦ�
        }
    }
}
