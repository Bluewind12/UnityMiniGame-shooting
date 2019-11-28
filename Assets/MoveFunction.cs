using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFunction : MonoBehaviour
{
    public GameObject shoot;
    public GameObject gText;
    public GameObject sText;
    public bool shootFlag = true;
    public float coolTime = 0.0f;
    public GameObject shootChargeBar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && this.gameObject.GetComponent<Transform>().position.x <= 2.5)
        {
            //右キー
            this.gameObject.transform.Translate(0.1f,0,0);
        }else if (Input.GetKey(KeyCode.LeftArrow) && this.gameObject.GetComponent<Transform>().position.x >= -2.5)
        {
            //左キー
            this.gameObject.transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && shootFlag)
        {
            //たま射出
            Instantiate(shoot, transform.position, Quaternion.identity);
            shootFlag = false;
            coolTime = 1.5f;

        }
        if (!shootFlag)
        {
            shootChargeBar.GetComponent<Transform>().localScale = new Vector3(0.25f, coolTime * 1.5f, 1f);
        }
        if (coolTime >= 0.0f)
        {
            coolTime -= 0.01f;
        }
        else
        {
            shootFlag = true;
            shootChargeBar.GetComponent<Transform>().localScale = new Vector3(0.25f, 0, 1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            sText.GetComponent<Score>().gameFlag = false;
            gText.GetComponent<TextMesh>().text = "GAME\nOVER";
            Destroy(this.gameObject);
        }
    }
}
