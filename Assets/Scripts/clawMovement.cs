using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawMovement : MonoBehaviour
{
    public float min_Z=-57, max_Z=57;
    public float rotate_Speed = 50f;

    public float rotate_Angle;
    public bool rotate_Right;
    public bool canRotate;

    public float moveSpeed = 7f;
    public float start_moveSpeed;

    public float min_Y = -5;
    public float min_X = -8.1f;
    public float max_X = 8.1f;
    public float start_Y;

    public Collider2D clawColli;

    public bool moveDown;
    public bool canNotTake=false;

    public RopeMovement ropeMovement;
    public ElfMovement elfMovement;

    public Transform holdPos;
    public GameObject candyHolded;
    private bool candyisholded=false;
    public InGameFunction inGameFunction;

    private void Awake()
    {
/*        scoreManager = FindObjectOfType<ScoreManager>();*/
        ropeMovement = GetComponent<RopeMovement>();
        clawColli = GetComponent<Collider2D>();
        elfMovement = FindObjectOfType<ElfMovement>();
        inGameFunction= FindObjectOfType<InGameFunction>();
    }
    private void Start()
    {
        start_Y = transform.position.y;
        start_moveSpeed = moveSpeed;
        canRotate = true;
    }
    private void Update()
    {
        getInput();
        Rotate();
        moveRode();
        updateCandyPos();
        if (Time.timeScale == 0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void updateCandyPos()
    {
        if (canNotTake==true)
        {
            moveDown = false;
        }
        if (candyHolded!=null && candyisholded == true && canNotTake==false)
        {
            candyHolded.gameObject.GetComponent<Transform>().position = holdPos.position;
        }else if (candyHolded != null && candyisholded == true && canNotTake == true)
        {
            candyHolded.gameObject.GetComponent<Transform>().position = candyHolded.gameObject.GetComponent<Transform>().position;
            candyHolded= null;
            moveSpeed = start_moveSpeed;
        }
        
        if (canRotate == true && candyHolded != null)
        {
            candyHolded = null;
        }

    }

    private void Rotate()
    {
        if (!canRotate)
        {
            return;
        }
        if (rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        } else
            rotate_Angle -= rotate_Speed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if (rotate_Angle >= max_Z)
        {
            rotate_Right = false;
        }
        else if (rotate_Angle <= min_Z)
        {
            rotate_Right = true;
        }
    }
    void getInput()
    {
        if (InGameFunction.runOutOfTime == true) return;
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("keo");
            if (canRotate == true)
            {
                Debug.Log("down");
                canRotate = false;
                moveDown = true;
            }
            else return;
        }
    }
    void moveRode()
    {
        if (canRotate == true) return;
            Vector3 temp= transform.position;
            if (moveDown)
            {
                temp -= transform.up*Time.deltaTime*moveSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime*moveSpeed;
            }

            transform.position = temp;

            if (temp.y <= min_Y || temp.x >= max_X || temp.x<=min_X)
            {
                moveDown = false;
            }
            if(temp.y>= start_Y)
            {
                canRotate = true;
                ropeMovement.RenderLine(temp, false);
                moveSpeed = start_moveSpeed;
            }
            if (candyisholded && candyHolded != null && canRotate==true)
            {
                /*candyHolded.SetActive(false);*/
                Destroy(candyHolded);
                if (candyHolded.gameObject.CompareTag("food"))
                {
                    ScoreManager.food_count ++;
                    Debug.Log("food:");
                }
                else if (candyHolded.gameObject.CompareTag("NPC"))
                {
                    ScoreManager.elf_count ++;
                    Debug.Log ("elf:");
                }
                else if (candyHolded.gameObject.CompareTag("toy"))
                {
                    ScoreManager.toy_count++;
                    Debug.Log("toy:");
                }
                else if (candyHolded.gameObject.CompareTag("gift"))
                {
                    ScoreManager.gift_count++;
                    Debug.Log("gift");
                }
                candyHolded = null; // Reset đối tượng kẹo
                candyisholded = false; // Reset trạng thái giữ kẹo
            }
            ropeMovement.RenderLine(transform.position, true);
        
    }
    
    //reduce the speed !! rmb
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food")&&candyHolded==null)
        {
            candyisholded = true;
            candyHolded= collision.gameObject;
            moveDown = false;
            moveSpeed = 5f;
        }
        if (collision.gameObject.CompareTag("toy") && candyHolded == null)
        {
            candyisholded = true;
            candyHolded = collision.gameObject;
            moveDown = false;
            moveSpeed = 4f;
        }
        if (collision.gameObject.CompareTag("gift") && candyHolded == null)
        {
            candyisholded = true;
            candyHolded = collision.gameObject;
            moveDown = false;
            moveSpeed = 4f;
        }
        if (collision.gameObject.CompareTag("NPC") && candyHolded==null && moveDown==true)
        {
            collision.gameObject.GetComponent<ElfMovement>().canMove = false;
            candyisholded = true;
            candyHolded = collision.gameObject;
            moveDown = false;
            moveSpeed = 2f;
        }

        if (collision.gameObject.CompareTag("santa")||collision.gameObject.CompareTag("thung"))
        {
            canNotTake = true;
            this.transform.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("santa")|| collision.gameObject.CompareTag("thung"))
        {
            canNotTake =false;
        }
        if(collision.gameObject.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<ElfMovement>().canMove = true;
        }
    }
}
