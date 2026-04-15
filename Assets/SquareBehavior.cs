using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    // 2. El objeto cambia de color a uno random
    SpriteRenderer m_SpriteRenderer; // Declara una variable de tipo SpriteRenderer
    Color colorCustom;
    Vector2 positionRandom;

    // 5. El objeto se mueve a la izq der arriba abajo
    public float speed = 3f; // Variable para controlar la velocidad de movimiento del objeto
    
    // 4. El objeto desactiva y activa el objeto Circle
    public GameObject circleObject; // Variable para almacenar la referencia al objeto Circle

    void Start()
    {
        // 2. El objeto cambia de color a uno random
        m_SpriteRenderer = GetComponent<SpriteRenderer>(); // Unity busca en el objeto del juego si tiene un componente SpriteRenderer y, si lo encuentra, lo guarda en mi variable.

        // 4. El objeto desactiva y activa el objeto Circle
        circleObject = GameObject.Find("Circle"); // Busca el objeto Circle en la escena y lo asigna a la variable
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Tecla control o clic izquierdo del mouse
		{
			// 1. El objeto cambia a un color aleatorio
            Debug.Log("Tocó el control o el clic izquierdo del mouse");
            
            // 2. El objeto cambia de color a uno random
            colorCustom = new Color( Random.Range(0F,1F), Random.Range(0F,1F), Random.Range(0F,1F)); // Crea un nuevo color con valores aleatorios para rojo, verde y azul.
            m_SpriteRenderer.color = colorCustom; // Cambia el valor del color del SpriteRenderer por el que tengo random en colorCustom.
            Debug.Log(m_SpriteRenderer.color); // Imprime el color actual del SpriteRenderer en la consola.
            
            // 3. El objeto se mueve a una posición aleatoria de +- 100 en x y
            positionRandom = new Vector2(
                transform.position.x + Random.Range(-2f, 2f),
                transform.position.y + Random.Range(-2f, 2f)
            );
            transform.position = positionRandom;
            Debug.Log(m_SpriteRenderer.transform.position); // Imprime la posición actual del SpriteRenderer.
            
            // 4. El objeto desactiva y activa el objeto Circle
            circleObject.SetActive(!circleObject.activeSelf);
            Debug.Log(circleObject.activeSelf); // Imprime el estado actual del objeto Circle
            }
        
        // 5. El objeto se mueve a la izq der arriba abajo
        if (Input.GetKey(KeyCode.UpArrow)) // Flecha arriba
        {
            Debug.Log("Tocó la flecha arriba");
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Flecha abajo
        {
            Debug.Log("Tocó la flecha abajo");
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Flecha izquierda
        {
            Debug.Log("Tocó la flecha izquierda");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Flecha derecha
        {
            Debug.Log("Tocó la flecha derecha");
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // 6. El objeto activa un timer y cuando termina destruye al propio objeto
        if (Input.GetKeyDown(KeyCode.Space)) // Barra espaciadora
        {
            Debug.Log("Tocó la barra espaciadora");
            Destroy(gameObject, 5f); // Destruye el objeto en 5 segundos
        }
    }
}
