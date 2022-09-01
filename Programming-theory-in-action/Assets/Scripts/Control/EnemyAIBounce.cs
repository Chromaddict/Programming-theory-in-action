using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIBounce : EnemyAI
{
    [SerializeField] float bounceMultiplyer = 1;
    Rigidbody enemyRb;
    GridManager gridManager;
    
    
    void Start()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
        target = GameObject.FindObjectOfType<PlayerController>();
        enemyRb = GetComponent<Rigidbody>();
    }
    public override void Move()
    {
        //transform.LookAt(target.transform.position + new Vector3(0, transform.position.y, 0));
        //enemyRb.AddForce(Vector3.forward * bounceMultiplyer * -1 * Time.deltaTime);
        //ConstrainHeight();
        //ConstrainMovementToGrid();
    }

    private void ConstrainHeight()
    {
        if (enemyRb.position.y > 1.5f)
        {
            enemyRb.position = new Vector3(enemyRb.position.x, 1.5f, enemyRb.position.z);
        }
    }
    private void ConstrainMovementToGrid()
    {
        if (transform.position.x > gridManager.GridSize.x - 1)
        {
            transform.localPosition = new Vector3(gridManager.GridSize.x - 1.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.z > gridManager.GridSize.y - 1)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, gridManager.GridSize.y - 1.1f);
        }
        if (transform.position.x < 0)
        {
            transform.localPosition = new Vector3(0.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 0)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0.1f);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("ground");
            //enemyRb.AddForce(Vector3.up * bounceMultiplyer);
            enemyRb.AddForce(Vector3.up * bounceMultiplyer + (target.transform.position - transform.position)*2 + new Vector3(0, transform.position.y, 0));
        }   
    }
    private void OnCollisionExit(Collision other) {
        Debug.Log(gameObject.name);
    }
}
