using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputCharacterController : MonoBehaviour
{
    public float Movement { get; private set; }
    public Vector3 MouseScreenPosition { get; private set; }
    public bool ShootPressed { get; private set; }

    void Update()
    {
        Movement = Input.GetAxis("Vertical");
        MouseScreenPosition = Input.mousePosition;
        ShootPressed = Input.GetMouseButtonDown(0);
    }
}
