using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    [SerializeField] private GameObject DemoIsland;
    // Start is called before the first frame update
    void Start()
    {
        GenerateIslandMap();
    }


    private void GenerateIslandMap()
    {
        int islandNum = new System.Random().Next(6, 10);
        int LeftRightSwitch = (new System.Random().Next(0, 2));

        float totalDistance = 0;

        for (int i = 0; i < islandNum; i++)
        {

            int isLeft = ((i + LeftRightSwitch) % 2) * 2 - 1;
            float x = Random.Range(25, 70f);
            float y = Random.Range(-8, 16f);
            totalDistance += new System.Random().Next(60, 100);

            Quaternion islandRotation = new Quaternion(1, 0, 0, -1f);
            Instantiate(DemoIsland, new Vector3(x * isLeft, y, totalDistance), islandRotation);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
