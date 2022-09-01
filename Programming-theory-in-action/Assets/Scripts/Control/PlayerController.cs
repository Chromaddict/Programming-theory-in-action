using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotateSpeed = 1f;
    GridManager gridManager;
    Vector2Int coords;
    
    void Start()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
    }

    
    void Update()
    {
        HandleInput();
        HandleExplored();
    }

    

    private void HandleInput() // ABSTRACTION
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(0, horizInput * rotateSpeed * Time.deltaTime, 0), Space.World);
        transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
        ConstrainMovementToGrid();

    }

    private void ConstrainMovementToGrid() // ABSTRACTION
    {
        if (transform.position.x > gridManager.GridSize.x - 1)
        {
            transform.localPosition = new Vector3(gridManager.GridSize.x - 1, transform.position.y, transform.position.z);
        }
        if (transform.position.z > gridManager.GridSize.y - 1)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, gridManager.GridSize.y - 1);
        }
        if (transform.position.x < 0)
        {
            transform.localPosition = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 0)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void HandleExplored() // ABSTRACTION
    {
        coords = gridManager.GetCoordinatesFromPosition(transform.position);
        if (!gridManager.GetNode(coords).isExplored)
        {
            gridManager.GetNode(coords).isExplored = true;
            gridManager.CleanTile(coords);
        }
    }
}
