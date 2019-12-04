using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public float timeSpawn = 5.0f;
    float timeLeft = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // Instanciar los objetos en el pool.
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        Debug.Log("Tiempo: " + timeLeft);
        if (timeLeft < 0)
        {
            GameObject nuevaSandia = GetPooledObject();
            if (nuevaSandia != null) { 
                nuevaSandia.transform.position = gameObject.transform.position;
                nuevaSandia.SetActive(true);
            }
            timeLeft = timeSpawn;
        }
    }

    // Recuperar un objeto del pool.
    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }
}
