using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 0.7f;
    public float SecondUntilDestroy = 1.0f;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += Speed *this.gameObject.transform.forward;
        if(Time.time - startTime >= SecondUntilDestroy){
            Destroy(this.gameObject);
        }
    }
}
