using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefabs = null;
    [SerializeField] private Transform[] spawnPoints = null;

     public int ItemCount = 20;

    //������ Ǯ�� ���� ť
    Queue<GameObject> itemQueue = new Queue<GameObject>();

    private List<GameObject> cubes = null;



    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0; i < ItemCount; i++)
        {   
            //������
            GameObject cube = Instantiate(cubePrefabs, Vector3.zero,Quaternion.identity);
            itemQueue.Enqueue(cube);
            cube.SetActive(false);
        }
        SpawnCube();
    }

    void SpawnCube()
    {
        for(int i =0; i < spawnPoints.Length; i++)
        {
            //ť���� ������
            GameObject cube = itemQueue.Dequeue();
            //Ȱ��ȭ��Ű��
            cube.SetActive(true);
            cubes[i] = cube;
            // �������� ��ġ�� ����ش�
            cube.transform.position = spawnPoints[i].transform.position;
        }
    }
    
    //�ڸ��� ��ĭ�� �ű��
    void ChangePosition()
    {
        for(int i = 1; i < spawnPoints.Length; i++)
        {
            cubes[i].transform.Translate(Vector3.back, Space.Self);
        }
        GameObject cube = itemQueue.Dequeue();
        cube.SetActive(true);
        cubes.Add(cube);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
