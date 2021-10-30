using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    private Vector3 mouseWorldPosition;

    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = (mouseWorldPosition - this.transform.position).normalized;

        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

    }
}
