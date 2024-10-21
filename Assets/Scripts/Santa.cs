
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    public float santan_Speed = 4f;
    public Vector3 startVec = Vector3.left;
    public Transform targetDirec;
    public Transform spawncandyPoint;

    public int reset = 0;
    public List<GameObject> foods = new List<GameObject>();
    public Animator animator; 
    
    public bool isRun = true;
    public bool isPush= false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        transform.Translate(startVec * Time.deltaTime * santan_Speed);
        animator.SetBool("isRun", isRun);

    }
    private void Update()
    {
        spawnCandy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("thung"))
        {
            isPush=true;
            animator.SetBool("isPush", isPush);
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("thung"))
        {
            isPush = false;
            animator.SetBool("isPush", isPush);
        }
    }
    public float coundowntime = 3f;
    public void spawnCandy()
    {
        if (coundowntime <= 0)
        {
            Instantiate(getRandomFood(), spawncandyPoint.position, getRandomFood().transform.rotation);
            coundowntime = 3;
        }
        else
        {
            coundowntime-=Time.deltaTime;
        }

    }
    public GameObject getRandomFood()
    {
        if (foods.Count <= 0) return null;
        int rand = Random.Range(0, foods.Count);
        return foods[rand];
    }
}
