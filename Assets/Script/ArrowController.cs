using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowController : MonoBehaviour
{
    public static ArrowController Create(Vector3 position ,Enemy enemy)
    {
        Transform prefArrow = Resources.Load<Transform>("Arrow");
        Transform arrow = Instantiate(prefArrow,position, Quaternion.identity);
        ArrowController _arrow = arrow.GetComponent<ArrowController>();
        _arrow.setEnemy(enemy);
        _arrow.setPos(position);
        Debug.Log(arrow.position + " va" + position);
        return _arrow;
        
    }

    Enemy enemy;
    float speed = 4f;
    Vector3 normalize;
    private float time = 3f;
    [SerializeField] float damage;
    Vector3 lastEnemyPosition;
    Vector3 PosSpawn;

    public void setPos(Vector3 pos)
    {
        this.PosSpawn = pos;
    }
    public void setEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        //di chuyen
        Move();
        Debug.Log(lastEnemyPosition);
        //dich chuyen theo farme
        transform.position += normalize * speed * Time.deltaTime;
        ChangeRotation();
        SetTimeToDestroy();
    }
    public void Move()
    {
        //can vi tri cua target
        //huong
        //dk neu enemy bi destroy
        if (enemy != null)
        {
            normalize = (enemy.transform.position - PosSpawn).normalized;
            lastEnemyPosition = enemy.transform.position;
        }      
        else
        {
            if(lastEnemyPosition == transform.position)
            {
                Destroy(gameObject);
            }
            normalize = (lastEnemyPosition - PosSpawn).normalized;
            //Debug.Log(lastEnemyPosition);
           
        }

        

        
    }
    
    public void ChangeRotation()
    {
        float zIndex = Mathf.Atan2(normalize.y, normalize.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemy != null)
        {
            if (collision.gameObject.tag == enemy.gameObject.tag)
            {
                HealthSysterm health = collision.GetComponent<HealthSysterm>();
                health.OnDamage(damage);
                health.IsHealthChange();
                Debug.Log("hha");
                Destroy(gameObject);
            }
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
