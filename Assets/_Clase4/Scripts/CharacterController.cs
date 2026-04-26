using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private InputCharacterController input;
    private Movement movement;
    private Shooting shooting;

    void Awake()
    {
        input = GetComponent<InputCharacterController>();
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        movement.Move(input.Movement);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(input.MouseScreenPosition);

        Vector2 direction = mouseWorld - transform.position;

        movement.Rotate(direction);

        if (input.ShootPressed)
        {
            shooting.Shot();
        }
    }
}