using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Vector3 startVec = Vector3.right;
    public float maxPos;
    public float minPos;
    private Transform thisOBJ;
    public bool canMove = true;
    private void Awake()
    {
        thisOBJ = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (canMove == false) return;
        getVector(startVec);
        transform.Translate(startVec*Time.deltaTime*moveSpeed);
    }

    public void getVector(Vector3 startv)
    {
        if (canMove == false) return;
        if (transform.position.x >= maxPos)
        {
            thisOBJ.Rotate(0, 180, 0);
        }else if (transform.position.x <= minPos) 
        {
            thisOBJ.Rotate(0, 180, 0);
        }
        
    }
}
