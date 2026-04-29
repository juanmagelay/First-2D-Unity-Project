using UnityEngine;

// Hereda de BaseSkill, no de MonoBehaviour directamente
// Hereda duration, Start(), Activate(), y SkillRoutine(). 
// Solo tiene que definir qué hacen ApplyEffect y RevertEffect.
public class PowerShotSkill : BaseSkill
{
    // Necesito traerme de Shooting la bulletSpeed
    private Shooting shooting;
    
    //  Antes de swapear el slot, guardamos lo que había. 
    // Sin esto no podríamos restaurarlo en RevertEffect.
    private float originalBulletSpeed;
    private float powerShotMultiplier = 5f; // Multiplicador para la velocidad de la bala   
    
    /*
        Busca el Shooting en el mismo GameObject. 
        Usamos Awake en lugar de Start porque Start ya está ocupado en BaseSkill 
        para llamar Activate()
    */
    void Awake()
    {
        shooting = GetComponent<Shooting>();
    }
    
    /*
        override es la palabra que dice: "esto es la implementación concreta 
        del método abstracto de la clase padre". 
    */
    protected override void ApplyEffect()
    {
        originalBulletSpeed = shooting.bulletSpeed; // Guarda la velocidad original para poder restaurarla después
        PowerShot();
    }

    // Restaura el slot al valor original guardado. 
    protected override void RevertEffect()
    {
        shooting.bulletSpeed = originalBulletSpeed;
    }

    private void PowerShot()
    {
        shooting.bulletSpeed = originalBulletSpeed * powerShotMultiplier;
    }
}