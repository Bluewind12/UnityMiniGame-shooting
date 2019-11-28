using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject target;
    private void Start()
    {
        InvokeRepeating("TargetSpawn", 1, 1);
    }
     void TargetSpawn()
    {
        Instantiate(target, new Vector3(Random.Range(-2.5f,2.5f),6,0), Quaternion.identity);
    }
}
