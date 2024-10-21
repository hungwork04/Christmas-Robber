using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
/*    private GameObject woodBox;*/
    public Santa santa;

    public Vector3 startPos;
    private void Awake()
    {
/*        woodBox = GetComponent<GameObject>();*/
        santa = FindObjectOfType<Santa>();
    }
    private void Start()
    {
        startPos= this.transform.parent.position  ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("spawnpoint"))
        {
            santa.reset++;
            Transform pointChoosen = collision.transform;

            if (santa.startVec.x > 0)
            {
                santa.transform.position = new Vector3
                    (pointChoosen.transform.position.x + 5, pointChoosen.transform.position.y-3, pointChoosen.transform.position.z);
                
            }
            else if (santa.startVec.x < 0)
            {
                Vector3 pointPos = collision.transform.position;
                santa.transform.position = new Vector3(pointPos.x -5, pointPos.y+3, pointPos.z);
            }
            santa.startVec *= -1;
            Vector3 lscale = santa.transform.localScale;
            lscale.x *= -1;
            santa.transform.localScale = lscale;
        }
        if (santa.reset == 1)
        {
            santa.reset = 0;
            this.transform.parent.position = startPos;
        }
    }
/*    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("spawnpoint"))
        {
            collision.enabled=true;
        }
    }*/
}
