using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private InputCharacterController input;
    private Movement movement;
    private Shooting shooting;
    // El "slot" para la habilidad de disparo, puede ser null o apuntar a cualquier método que queramos
    public System.Action shootAction; // Se necesita public para poder asignarle métodos desde las skills


    void Awake()
    {
        input = GetComponent<InputCharacterController>();
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
        
        // Variable para que el character controller no tenga que conocer el shooting si es con o sin habilidad. Le asignamos el método Shot por default, pero podríamos asignar cualquier otro método con la misma firma o dejarlo como null para que no haga nada al disparar
        shootAction = shooting.Shot; 

    }

    void Update()
    {
        movement.Move(input.Movement);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(input.MouseScreenPosition);

        Vector2 direction = mouseWorld - transform.position;

        movement.Rotate(direction);

        if (input.ShootPressed)
        {
            // Llama a lo que sea que esté en el slot
            shootAction?.Invoke();     
        }
        
    }
}