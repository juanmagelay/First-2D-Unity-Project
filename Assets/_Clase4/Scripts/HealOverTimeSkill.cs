using UnityEngine;

// Hereda de BaseSkill, no de MonoBehaviour directamente
// Hereda duration, Start(), Activate(), y SkillRoutine(). 
// Solo tiene que definir qué hacen ApplyEffect y RevertEffect.
public class HealOverTimeSkill : BaseSkill
{
    private Health health; // Necesito traerme de Health el currentHealth
    private float plusHealth = 1f; // Cantidad de vida que se suma cada segundo
    
    
    /*
        Busca el health en el mismo GameObject. 
        Usamos Awake en lugar de Start porque Start ya está ocupado en BaseSkill 
        para llamar Activate()
    */
    void Awake()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        HealthOverTime();
    }

    /*
        override es la palabra que dice: "esto es la implementación concreta 
        del método abstracto de la clase padre". 
    */
    protected override void ApplyEffect()
    {
        // Queda vacío porque no quiero hacer nada inmediato, solo la curación que se hace cada segundo en Update.
    }

    // Restaura el slot al valor original guardado. En CharacterController, el slot apunta al método Shot() 
    protected override void RevertEffect()
    {
        // Queda vacío porque no quiero revertir la curación que se hizo a 
        // cada segundo.
    }

    private void HealthOverTime()
    {
        health.Heal(plusHealth * Time.deltaTime); // Suma vida cada segundo, multiplicando por Time.deltaTime para que sea por segundo y no por frame
    }
}