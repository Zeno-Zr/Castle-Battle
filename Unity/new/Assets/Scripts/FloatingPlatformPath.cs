using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformPath : MonoBehaviour
{
    //set Layer to ground, rigidbody2D body type to kinematic
    public float length = 0f;
    public float height = 0f;
    public int pathNumber = 0;
    public float speed = 10f;
    public float delayTime = 0f;

    Rigidbody2D rb;
    float TimeX;
    float TimeY;
    bool IsDone = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pathNumber = pathNumber%14;
        if (speed != 0)
        {
            TimeX = length / speed;
            TimeY = height / speed;
            StartCoroutine(DelayBeforeStart());
        }
    }

    void Update()
    {
        if (speed != 0 && IsDone == true)
        {
            IsDone = false;
            StartCoroutine(Wander(pathNumber));
        }
    }

    IEnumerator DelayBeforeStart()
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(Wander(pathNumber));
    }

    IEnumerator Wander(int WanderPath)
    {
        // Moves clockwise, starts with x++
        if (WanderPath == 0)
        {
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        // Moves Anticlockwise, starts with y--
        else if (WanderPath == 13)
        {
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
        }

        // Taking reference to a clock face, moves from centre to the input number
        // Moves one axis at a time
        else if (WanderPath == 1)
        {
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        else if (WanderPath == 2)
        {
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        else if (WanderPath == 3)
        {
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        else if (WanderPath == 4)
        {
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        if (WanderPath == 5)
        {
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        if (WanderPath == 6)
        {
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        if (WanderPath == 7)
        {
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        if (WanderPath == 8)
        {
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        if (WanderPath == 9)
        {
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        if (WanderPath == 10)
        {
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
        }
        if (WanderPath == 11)
        {
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseX();
            yield return new WaitForSeconds(TimeX);
            IncreaseX();
            yield return new WaitForSeconds(TimeX);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
        }
        if (WanderPath == 12)
        {
            IncreaseY();
            yield return new WaitForSeconds(TimeY);
            DecreaseY();
            yield return new WaitForSeconds(TimeY);
        }

        IsDone = true;
    }

    void IncreaseX()
    {
        rb.velocity = new Vector2(speed, 0f);
    }

    void IncreaseY()
    {
        rb.velocity = new Vector2(0f, speed);
    }

    void DecreaseX()
    {
        rb.velocity = new Vector2(-speed, 0f);
    }

    void DecreaseY()
    {
        rb.velocity = new Vector2(0f, -speed);
    }
}
