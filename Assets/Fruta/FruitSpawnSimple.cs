using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnSimple : MonoBehaviour
{
    public GameObject objToSpawn;
    public float timeSpawn = 5.0f;
    float timeLeft = 1f;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
            timeLeft = timeSpawn;
        }
    }
}
