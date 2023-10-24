using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public Transform _enemy;
    //public Transform _target;
    //public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // _enemy.transform.position = Vector3.Lerp(_enemy.transform.position, _target.position, speed * Time.fixedDeltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Enemy.Create(Extension.MousePosition() + Extension.RandomPos());
        }
        {
            
            //GameObject enemy = Instantiate(_enemy.gameObject, new Vector3(Random.Range(10,20), Random.Range(10, 20) , 0) , Quaternion.identity);
            //Debug.Log(enemy.gameObject.transform.position);
            //Move(enemy);
        }
        
    }
    //public void Move(GameObject enemy)
    //{
    //    enemy.transform.position = Vector3.Lerp(enemy.transform.position, _target.position, speed * Time.fixedDeltaTime);

    //}
}
