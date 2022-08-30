using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float speed;

    private InputAdapter _input;

    private Vector2 GetDirection() => _input.GetDirection();

    private void Update()
    {
        var dir = GetDirection();
        SetPosition(dir);
    }

    private void SetPosition(Vector2 dir)
    {
        transform.position += new Vector3(dir.x, dir.y, 0) * Time.deltaTime * speed;
    }

    public void SetConfigureInput(InputAdapter adapter)
    {
        _input = adapter;
    }

}
