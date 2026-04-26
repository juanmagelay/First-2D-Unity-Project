using System.Collections; // Necesario para que C# reconozca IEnumerator
using UnityEngine;
public abstract class BaseSkill : MonoBehaviour
{
    public float duration = 5f; 
    
    /* 
        Automáticamente cuando el componente aparece en el GameObject. 
        Esto es clave: cuando AddComponent<MultiShotSkill>() lo agregue en runtime, 
        Start() se ejecuta solo y la skill arranca.
    */
    void Start()
    {
        Activate();
    }

    // Es público porque Pickup lo va a llamar desde afuera si hace falta. Solo lanza la coroutine.
    public void Activate()
    {
        StartCoroutine(SkillRoutine());
    }

    private IEnumerator SkillRoutine()
    {
        ApplyEffect(); // Activa el efecto inmediatamente
        yield return new WaitForSeconds(duration); // Pausa esta función X segundos, sin bloquear nada más
        RevertEffect(); // Revierte el efecto
        Destroy(this); // Destruye solo el componente skill, no el GameObject
    }

    /*
        Abstract: Significa que no tiene {cuerpo} acá, cada subclase debe definirlo.
        Protected: Solo las subclases pueden verlo, no código externo.    
    */
    protected abstract void ApplyEffect();
    protected abstract void RevertEffect();
}
