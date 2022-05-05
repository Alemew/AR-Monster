using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnTime = 4f;
    private GameObject monsterInstantiated;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                monsterInstantiated = Instantiate(monsterPrefab, transform.position, transform.rotation);
                monsterInstantiated.transform.parent = this.gameObject.transform;
                timer = spawnTime;
            }
        }
    }
}
