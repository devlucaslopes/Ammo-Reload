using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float TimeToDestroy = 3;

    private Rigidbody2D rb;

    private bool _toRight;

    public bool ToRight { get { return _toRight; } set { _toRight = value; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (_toRight)
        {
            rb.velocity = Vector2.right * Speed;
        } else
        {
            rb.velocity = Vector2.left * Speed;
        }

        

        Destroy(gameObject, TimeToDestroy);
    }
}
