using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalForce;
    public float horizontalTValue;

    public float decay;

    public Bounds bounds;

    private Rigidbody2D rigid;
    private Vector3 touchesEnded;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        touchesEnded = new Vector3();
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            touchesEnded = worldTouch;
        }

        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector2(0.0f, horizontalForce));
            Debug.Log("jump");
        }

        if (touchesEnded.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(this.transform.position.x, touchesEnded.x, horizontalTValue), this.transform.position.y);
        }
        
    }

    private void CheckBounds()
    {
        //Left Boundary
        if (transform.position.x < bounds.min)
        {
            this.transform.position = new Vector2(bounds.min, transform.position.y);
        }

        //Right Boundary
        if (transform.position.x > bounds.max)
        {
            this.transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
