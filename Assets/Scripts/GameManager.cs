using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int gridWidth = 20;
    public int gridHeight = 20;

    public GameObject foodPrefab;
    private GameObject currentFood;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        if (currentFood != null)
            Destroy(currentFood);

        Vector2Int pos = new Vector2Int(
            Random.Range(0, gridWidth),
            Random.Range(0, gridHeight)
        );

        currentFood = Instantiate(foodPrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    }

    public Vector2Int GetFoodPosition()
    {
        return currentFood != null
            ? new Vector2Int(Mathf.RoundToInt(currentFood.transform.position.x), Mathf.RoundToInt(currentFood.transform.position.y))
            : new Vector2Int(-1, -1);
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f; // pausa o jogo
    }
}