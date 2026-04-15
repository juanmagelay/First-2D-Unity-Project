using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f; // velocidad de la bala
    public float lifeTime = 2f; // tiempo antes de destruirse

    void Start()
    {
        // destruimos la bala automaticamente despues de cierto tiempo
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // movemos la bala hacia la derecha local del objeto
        // esto depende de la rotacion con la que fue instanciada
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}