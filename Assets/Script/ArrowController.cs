using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public static ArrowController Create(Vector3 position , Enemy enemy)
    {
        Transform prfArrow = Resources.Load<Transform>("Arrow");
        Transform arrow = Instantiate(prfArrow,position,Quaternion.identity);
        ArrowController _arrow = arrow.GetComponent<ArrowController>();
        _arrow.setTarget(enemy);
        return _arrow;
    }

    [SerializeField] float time;
    private float timeMax = 3f;
    public float speed = 2f;
    Rigidbody2D rb;
    Enemy enemy;
    private Transform lastEnemy;
    private Vector3 vectorNormalize;
    private bool TargetIsDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        time = timeMax;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TargetIsDestroy);
        if (enemy is not null)
        {
            Debug.Log("kka");
            
            //lastEnemy = enemy.transform;
            Transform target =enemy.transform;     
            vectorNormalize = (target.transform.position - transform.position).normalized;
            Debug.Log("halo");
            
        }
        else
        {
            Debug.Log("kk");
            //Vector3 vectorNormalize = (lastEnemy.position - transform.position).normalized;
            //Debug.Log("halo");
        }
        
        rb.velocity = vectorNormalize * speed;

        SetTimeToDestroy();
        ChangeRotation();
    }
    private void setTarget(Enemy enemy)
    {
        this.enemy = enemy;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("hello");
            //Destroy(collision.gameObject);
            TargetIsDestroy = true;
        }
    }

    private void SetTimeToDestroy()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            Destroy(gameObject);
        }
    }
    private void ChangeRotation()
    {
        float ZRotation = Mathf.Atan2(vectorNormalize.y, vectorNormalize.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,ZRotation);
    }
}
