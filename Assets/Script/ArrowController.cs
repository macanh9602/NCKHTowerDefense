using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //public static ArrowController Create(Vector3 position , Enemy enemy )
    //{
    //    Transform prfArrow = Resources.Load<Transform>("Arrow");
    //    Transform arrow = Instantiate(prfArrow,position,Quaternion.identity);
    //    ArrowController _arrow = arrow.GetComponent<ArrowController>();
    //    _arrow.setTarget(enemy);
    //    return _arrow;
    //}

    //[SerializeField] float time;
    //private float timeMax = 3f;
    //public float speed = 2f;
    //Rigidbody2D rb;
    //Enemy targetEnemy;
    //private Transform lastEnemy;
    //private Vector3 vectorNormalize;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    time = timeMax;
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Move();
    //    SetTimeToDestroy();
    //    ChangeRotation();
    //}

    //private void Move()
    //{
    //    if(targetEnemy != null)
    //    {
    //        vectorNormalize = (targetEnemy.transform.position - transform.position).normalized;
    //    }
       
    //    rb.velocity = vectorNormalize * speed;
    //}

    //private void setTarget(Enemy enemy)
    //{
    //    this.targetEnemy = enemy;
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Monster")
    //    {
    //        Debug.Log("hello");
    //        //Destroy(collision.gameObject);
    //    }
    //}

    //private void SetTimeToDestroy()
    //{
    //    time -= Time.deltaTime;
    //    if(time < 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    //private void ChangeRotation()
    //{
    //    float ZRotation = Mathf.Atan2(vectorNormalize.y, vectorNormalize.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0,0,ZRotation);
    //}
    
    public static ArrowController Create(Vector3 position ,Enemy enemy)
    {
        Transform prefArrow = Resources.Load<Transform>("Arrow");
        Transform arrow = Instantiate(prefArrow,position, Quaternion.identity);
        ArrowController _arrow = arrow.GetComponent<ArrowController>();
        _arrow.setEnemy(enemy);
        Debug.Log(arrow.position + " va" + position);
        return _arrow;
        
    }

    Enemy enemy;
    float speed = 5f;
    Vector3 normalize;
    private float time = 2f;
    public void setEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }
    private void Update()
    {
        //di chuyen
        Move();
        ChangeRotation();
        SetTimeToDestroy();
    }
    public void Move()
    {
        //can vi tri cua target
        //huong
        //dk neu enemy bi destroy
        if(enemy != null)
        {
            normalize = (enemy.transform.position - transform.position).normalized;
        }
        //dich chuyen theo farme
        transform.position += normalize * speed * Time.deltaTime;
    }
    public void ChangeRotation()
    {
        float zIndex = Mathf.Atan2(normalize.y, normalize.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(collision.gameObject);
        }
    }
    private void SetTimeToDestroy()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }
}
