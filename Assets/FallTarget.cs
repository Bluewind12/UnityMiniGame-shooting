using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTarget : MonoBehaviour
{
    float rand;
    float fallSpeed;
    float rotateSpeed;
    bool rotateFlag;
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.value;
        fallSpeed = rand * 0.1f;
        rotateSpeed = rand * 5;
        rotateFlag = (Random.value >= 0.5f) ;

        textObj = GameObject.Find("ScoreGameText");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0, -fallSpeed, 0,Space.World);
        if (rotateFlag)
        {
            this.gameObject.transform.Rotate(rotateSpeed*Random.Range(-1,1), rotateSpeed * Random.Range(-1, 1), rotateSpeed);
        }
        else
        {
            this.gameObject.transform.Rotate(rotateSpeed * Random.Range(-1, 1), rotateSpeed * Random.Range(-1, 1), -rotateSpeed);
        }

        if (this.gameObject.GetComponent<Transform>().position.y <= -5)
        {
            textObj.GetComponent<Score>().resultScore += 100;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shoot")
        {
            textObj.GetComponent<Score>().resultScore += 1;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
