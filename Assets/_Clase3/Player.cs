using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // velocidad del jugador
    public int health = 100; // vida del jugador

    public GameObject bulletPrefab; // prefab de la bala
    public Transform shootPoint; // punto desde donde se dispara


    void Update()
    {
        // -------- MOVIMIENTO --------

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(h, v).normalized;

        transform.Translate(move * speed * Time.deltaTime);


        // -------- ROTACION HACIA EL MOUSE --------

        Vector3 mouseScreen = Input.mousePosition;

        // importante: ajustar z para convertir bien
        mouseScreen.z = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        Vector2 direction = mouseWorld - transform.position;

        // el player apunta al mouse
        transform.up = direction;


        // -------- DISPARO --------

        // cuando se hace click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        // instanciamos la bala en el shootPoint
        // usamos su rotacion para que salga en la direccion correcta
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }


    // -------- VIDA --------

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}