using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] internal float speed = 1.5f;
    internal PlayerController target;
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.LookAt(target.transform.position + new Vector3(0, 0.25f, 0));
        transform.Translate(Vector3.forward * speed * Time.deltaTime * GameManager.Instance.difficulty);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }    
    }
}
