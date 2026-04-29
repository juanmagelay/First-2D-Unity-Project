using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // 1. Referencias a los componentes que ya existen y reutilizamos
    private Movement movement;
    private Shooting shooting;
    private Health health;
    public System.Action shootAction;


    // 2. Variables de comportamiento configurables desde el Inspector
    public float shootCooldown = 2f;
    public float skillInterval = 5f;
    private float shootTimer = 0f;
    private float skillTimer = 0f;

    private GameObject player;

    void Awake()
    {
        // 3. Igual que CharacterControler, busca sus componentes en el mismo GameObject
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
        health = GetComponent<Health>();
        shootAction = shooting.Shot; // valor por defecto
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player == null) return;

        // 4. Persecución: calcula dirección al jugador y mueve/rota hacia él
        Vector2 direction = player.transform.position - transform.position;
        movement.Rotate(direction);
        movement.Move(1f); // siempre avanza hacia adelante

        // 5. Cooldown de disparo: acumula tiempo y dispara cada shootCooldown segundos
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCooldown)
        {
            shootAction?.Invoke();
            shootTimer = 0f;
        }

        // 6. Habilidad aleatoria cada skillInterval segundos
        skillTimer += Time.deltaTime;
        if (skillTimer >= skillInterval)
        {
            ApplyRandomSkill();
            skillTimer = 0f;
        }
    }

    void ApplyRandomSkill()
    {
        int roll = Random.Range(0, 3);
        switch (roll)
        {
            case 0: gameObject.AddComponent<MultiShotSkill>();    break;
            case 1: gameObject.AddComponent<PowerShotSkill>();    break;
            case 2: gameObject.AddComponent<HealOverTimeSkill>(); break;
        }
        Debug.Log("Enemigo obtuvo skill: " + roll);
    }
}