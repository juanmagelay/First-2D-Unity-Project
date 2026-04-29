using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // pickupRadius es la distancia a la que el jugador puede recoger el objeto.
    public float pickupRadius = 20f;
    
    // player es una referencia al GameObject del jugador, 
    // que se encuentra en Start() usando su tag.
    private GameObject player;

    void Start()
    {
        // Busca el GameObject con el tag "Player" y lo asigna a la 
        // variable player
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Verifica si el jugador no está cerca
        if (player == null)
        {
            Debug.Log("Player es null");
            return;
        }   

        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distancia: " + distance);

        if (distance <= pickupRadius)
        {
            Debug.Log("Se recogió el objeto");
            ApplyRandomSkill();
            Destroy(gameObject); // Destruye el objeto de recogida después de aplicar la habilidad  
        }
    }

    void ApplyRandomSkill()
    {
        int randomSkill = Random.Range(0, 3); // 0, 1 o 2

        switch (randomSkill)
        {
            case 0:
                player.AddComponent<HealOverTimeSkill>();
                Debug.Log("¡Has recogido una curación!");
                break;
            case 1:
                player.AddComponent<MultiShotSkill>();
                Debug.Log("¡Has recogido un multi disparo!");
                break;
            case 2:
                player.AddComponent<PowerShotSkill>();
                Debug.Log("¡Has recogido un poderoso disparo!");
                break;
        }
    }
}
