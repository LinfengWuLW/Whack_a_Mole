using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Brick[] bricks;
    public int activeBrickIndex = 0;
    private int score;

    private void Start()
    {
        // Set the initial active brick to green
        bricks[activeBrickIndex].status = Brick.BrickStatus.Green;
        bricks[activeBrickIndex].GetComponent<Renderer>().material.color = Color.green;

        // Set random statuses for the other bricks
        for (int i = 0; i < bricks.Length; i++)
        {
            if (i != activeBrickIndex)
            {
                bricks[i].SetRandomStatus();
            }
        }
    }

    public void UpdateScore(int pointValue)
    {
        score += pointValue;
        Debug.Log("Score: " + score);
    }


    public void NextBrick()
    {
        // Deactivate the current brick
        bricks[activeBrickIndex].status = Brick.BrickStatus.Red;
        bricks[activeBrickIndex].GetComponent<Renderer>().material.color = Color.red;

        // Activate the next brick
        activeBrickIndex = (activeBrickIndex + 1) % bricks.Length;
        bricks[activeBrickIndex].status = Brick.BrickStatus.Green;
        bricks[activeBrickIndex].GetComponent<Renderer>().material.color = Color.green;
    }
}
