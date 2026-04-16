using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // REFERENCIA AL INPUT PLAYER PARA USAR SUS VARIABLES
    private InputPlayer _inputPlayer;
    
    // CREAR VARIABLE PARA LA VELOCIDAD DEL JUGADOR
    public float speed = 5f; // Velocity of the player

    // INICIALIZAMOS REFERENCIA AL INPUT PLAYER
    void Awake()
    {
        _inputPlayer = GetComponent<InputPlayer>();
    }

    void Update()
    {
        // VEO LOS INPUTS DE TECLADO QUE ME PASA EL INPUT PLAYER

        float h = _inputPlayer.h;
        float v = _inputPlayer.v;

        // MOVIMIENTO 2D
        Vector2 move = new Vector2(h, v).normalized;
        transform.Translate(move * speed * Time.deltaTime);


        // ROTACION HACIA EL MOUSE
        Vector3 mouseScreen = _inputPlayer.mousePosition;

        // importante: ajustar z para convertir bien
        mouseScreen.z = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        Vector2 direction = mouseWorld - transform.position;

        // el player apunta al mouse
        transform.up = direction;
    }
}