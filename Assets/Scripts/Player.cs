using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    float paddingHorizontal;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shoot;

    void Awake()
    {
        paddingHorizontal = GetComponent<SpriteRenderer>().bounds.extents.x;
        shoot = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }
    
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector3 offset = rawInput * Time.deltaTime * playerSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + offset.x, minBounds.x + paddingHorizontal, maxBounds.x - paddingHorizontal), 
                                         Mathf.Clamp(transform.position.y + offset.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop));
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue)
    {
        if (shoot != null)
            shoot.isFiring = inputValue.isPressed;
    }
}
