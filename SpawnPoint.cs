using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    public float timeElapsed =0f;
    public float ItemCycle = 1.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeElapsed += Time.deltaTime;
        if(timeElapsed > ItemCycle){
            GameObject temp;
            temp = (GameObject)Instantiate(enemy);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(Random.Range(-21f,21f),0.0f,Random.Range(6.0f,18.0f));
            timeElapsed -= ItemCycle;
        }



    
    }
}
