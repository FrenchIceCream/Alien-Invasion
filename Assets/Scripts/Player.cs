using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float playerSpeed = 5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(rawInput.x, rawInput.y, 0) * Time.deltaTime * playerSpeed;
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }
}
