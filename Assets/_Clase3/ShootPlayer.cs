using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    private InputPlayer _inputPlayer;
    public GameObject bulletPrefab; // prefab de la bala
    public Transform shootPoint; // punto desde donde se dispara


    // INICIALIZAMOS REFERENCIA AL INPUT PLAYER
    void Awake()
    {
        _inputPlayer = GetComponent<InputPlayer>();
    }

    void Update()
    {

        // SHOOT

        // cuando se hace click izquierdo
        if (_inputPlayer.mouseLeftClick)
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
}