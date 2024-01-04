using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class super_light : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circlePrefab; // ���骺�w�m��
    public float minX = -1.4f;
    public float maxX = 25f;
    public float yPos = -4.25f;
    public float minDelay = 10f;
    public float maxDelay = 20f;
    public Transform player;
    public bool incircle()
    {
        if(player.position.x< circlePrefab.transform.position.x+5f && player.position.x > circlePrefab.transform.position.x - 5f && circlePrefab.activeSelf==true)
        {
            return true;
        }
        return false;
    }
    IEnumerator Start()
    {
        circlePrefab.SetActive(false);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay)); // �H�����ݮɶ�

            Vector3 circlePosition = GetRandomPosition();
            GenerateCircle(circlePosition);

            yield return new WaitForSeconds(2.5f); // �������ɶ�
        }
    }
    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, yPos, 0f);
    }

    void GenerateCircle(Vector3 position)
    {
        circlePrefab.SetActive(true);
        circlePrefab.transform.position = position;
        StartCoroutine(wait());
        //Destroy(newCircle, 4f); // 2 ���۰ʺR�����骫��
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        circlePrefab.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
