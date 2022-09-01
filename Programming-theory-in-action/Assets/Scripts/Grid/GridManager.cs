using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Material cleanMat;
    GameObject[,] tileArray;
    public GameObject[,] TileArray { get {return tileArray; } }
    public Vector2Int GridSize { get { return gridSize; } }
    [SerializeField] int unityGridSize = 1;
    public int UnityGridSize {get { return unityGridSize; } }
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    int cleanTiles = 0;
    int dirtyTiles;
    public int CleanTiles { get { return cleanTiles; } }
    void Awake() 
    {
        CreateGrid();  
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }
        return null;
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;

    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }
    public void CleanTile(Vector2Int coordinates)
    {
        MeshRenderer meshRenderer = tileArray[coordinates.x,coordinates.y].GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = cleanMat;
        cleanTiles++;
        if (--dirtyTiles == 0)
        {
            GameManager.Instance.CompleteLevel();
        }
    }

    void CreateGrid()
    {
        int difficulty = (int)GameManager.Instance.difficulty;
        Vector2Int gridMultiplier = new Vector2Int(difficulty, difficulty);
        gridSize *= gridMultiplier;
        tileArray = new GameObject[gridSize.x, gridSize.y];  
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y< gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x,y);
                grid.Add(coordinates, new Node(coordinates, true));
                tileArray[x,y] = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity, transform);  
                dirtyTiles++;
            }
        }
        float offset;
        switch(difficulty)
        {
            case 1:
            offset = 0;
            break;
            case 2:
            offset = 0.5f;
            break;
            case 3:
            offset = 1;
            break;
            default:
            offset = 0;
            break;

        }
        Camera.main.transform.position = new Vector3(4.5f * difficulty, 9 * difficulty, 4.5f * difficulty + offset);
    }
}
