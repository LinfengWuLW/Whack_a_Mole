using UnityEngine;

public class Mole : MonoBehaviour
{
    public float minAppearTime = 1f; // Minimum time for the mole to appear
    public float maxAppearTime = 3f; // Maximum time for the mole to appear

    public float appearTime;

    private Animator animator;
    private bool isUp = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomAppearTime();
        HideMole();
    }

    private void Update()
    {
        if (!isUp)
        {
            // Wait for the appear time to pass
            if (Time.time >= appearTime)
            {
                Appear();
            }
        }
    }

    private void SetRandomAppearTime()
    {
        appearTime = Time.time + Random.Range(minAppearTime, maxAppearTime);
    }

    private void Appear()
    {
        isUp = true;
        animator.SetBool("isUp", true);
        Invoke("HideMole", 1f); // Call HideMole() after 1 second
    }

    private void HideMole()
    {
        isUp = false;
        animator.SetBool("isUp", false);
        SetRandomAppearTime();
    }

    private void OnMouseDown()
    {
        if (isUp)
        {
            // Mole was whacked!
            // Implement your scoring or game logic here
            HideMole();
        }
    }
}
