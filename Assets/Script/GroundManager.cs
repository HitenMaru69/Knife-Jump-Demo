using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GroundManager : MonoBehaviour
{
    public static GroundManager Instance;

    [SerializeField] GameObject[] spawnPos;
    [SerializeField] GameObject groundPrefab;

    public bool isSpwan;

    private void Awake()
    {
        Instance = this;
    }


    public void SpwanGround()
    {
        GameObject random  = spawnPos[Random.Range(0, spawnPos.Length)];

        Instantiate(groundPrefab, random.transform.position, Quaternion.identity);
    }

}
