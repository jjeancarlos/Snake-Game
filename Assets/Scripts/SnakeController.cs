using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeController : MonoBehaviour
{
    public GameObject segmentPrefab;
    public float moveInterval = 0.15f;

    private List<Transform> segments = new List<Transform>();
    private Vector2Int direction = Vector2Int.right;
    private Vector2Int pendingDirection = Vector2Int.right;
    private float timer;

    private void Start()
    {
        segments.Add(transform);
    }

    private void Update()
    {
        HandleInput();

        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            timer = 0f;
            Move();
        }
    }

    private void HandleInput()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.upArrowKey.wasPressedThisFrame && direction != Vector2Int.down)
            pendingDirection = Vector2Int.up;
        else if (kb.downArrowKey.wasPressedThisFrame && direction != Vector2Int.up)
            pendingDirection = Vector2Int.down;
        else if (kb.leftArrowKey.wasPressedThisFrame && direction != Vector2Int.right)
            pendingDirection = Vector2Int.left;
        else if (kb.rightArrowKey.wasPressedThisFrame && direction != Vector2Int.left)
            pendingDirection = Vector2Int.right;
    }

    private void Move()
    {
        direction = pendingDirection;

        Vector2Int currentHeadPos = new Vector2Int(
            Mathf.RoundToInt(segments[0].position.x),
            Mathf.RoundToInt(segments[0].position.y)
        );

        Vector2Int newHeadPos = currentHeadPos + direction;

        if (newHeadPos.x < 0 || newHeadPos.x >= GameManager.Instance.gridWidth ||
            newHeadPos.y < 0 || newHeadPos.y >= GameManager.Instance.gridHeight)
        {
            GameManager.Instance.GameOver();
            return;
        }

        foreach (var seg in segments)
        {
            Vector2Int segPos = new Vector2Int(Mathf.RoundToInt(seg.position.x), Mathf.RoundToInt(seg.position.y));
            if (segPos == newHeadPos)
            {
                GameManager.Instance.GameOver();
                return;
            }
        }

        bool ateFood = newHeadPos == GameManager.Instance.GetFoodPosition();

        Vector3 prevPos = segments[0].position;
        segments[0].position = new Vector3(newHeadPos.x, newHeadPos.y, 0);

        for (int i = 1; i < segments.Count; i++)
        {
            Vector3 temp = segments[i].position;
            segments[i].position = prevPos;
            prevPos = temp;
        }

        if (ateFood)
        {
            GameObject newSeg = Instantiate(segmentPrefab, prevPos, Quaternion.identity);
            segments.Add(newSeg.transform);
            GameManager.Instance.SpawnFood();
        }
    }
}