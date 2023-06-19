using UnityEngine;

public class Brick : MonoBehaviour
{
    public enum BrickStatus
    {
        Green,
        Yellow,
        Red
    }

    public BrickStatus status;
    private int pointValue;
    private BoardManager boardManager;

    private float timer;
    private float timeLimit;

    private void Start()
    {
        boardManager = FindObjectOfType<BoardManager>();

        SetRandomStatus();

        timer = 0f;
        timeLimit = 2f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            ChangeColor();
            ResetTimer();
        }
    }

    private void ChangeColor()
    {
        float randomValue = Random.value;

        if (randomValue <= 0.2f)
            GetComponent<Renderer>().material.color = Color.green;
        else if (randomValue <= 0.5f)
            GetComponent<Renderer>().material.color = Color.yellow;
        else
            GetComponent<Renderer>().material.color = Color.red;
    }

    private void ResetTimer()
    {
        timer = 0f;
        timeLimit = Random.Range(1f, 3f);
    }

    public void SetRandomStatus()
    {
        float randomValue = Random.value;

        // Assign the status and point value based on probabilities
        if (randomValue <= 0.2f)
        {
            status = BrickStatus.Green;
            pointValue = 2;
        }
        else if (randomValue <= 0.5f)
        {
            status = BrickStatus.Yellow;
            pointValue = 1;
        }
        else
        {
            status = BrickStatus.Red;
            pointValue = -1;
        }

        // Set the color of the brick based on the status
        switch (status)
        {
            case BrickStatus.Green:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case BrickStatus.Yellow:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case BrickStatus.Red:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    private void OnMouseDown()
    {
        // Handle the logic when the brick is clicked
        boardManager.UpdateScore(pointValue);
        SetRandomStatus();
    }
}
