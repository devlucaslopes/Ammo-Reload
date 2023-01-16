using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;

    [Header("Shoot Settings")]
    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private float TimeBetweenShoots;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI TotalArrowsUI;

    private Rigidbody2D rb;
    private Animator anim;

    private bool _lookToRight = true;
    private float _timeToNextShoot;
    private int _totalArrows;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _timeToNextShoot && _totalArrows > 0)
        {
            _timeToNextShoot = Time.time + TimeBetweenShoots;
            anim.SetTrigger("isShooting");
        }
    }

    private void FixedUpdate()
    {
        float _direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_direction * Speed, rb.velocity.y);

        if (_direction == 1)
        {
            _lookToRight = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (_direction == -1)
        {
            _lookToRight = false;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        anim.SetBool("isWalking", _direction != 0);
    }

    public void Shooting()
    {
        Arrow arrow = Instantiate(ArrowPrefab, ShootPoint.position, ShootPoint.rotation).GetComponent<Arrow>();
        arrow.ToRight = _lookToRight;

        _totalArrows--;
        UpdateTotalArrows();
    }

    private void UpdateTotalArrows()
    {
        TotalArrowsUI.text = _totalArrows.ToString("00");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);

            _totalArrows++;
            UpdateTotalArrows();
        }
    }
}
