using UnityEngine;

// Hereda de BaseSkill, no de MonoBehaviour directamente
// Hereda duration, Start(), Activate(), y SkillRoutine(). 
// Solo tiene que definir qué hacen ApplyEffect y RevertEffect.
public class MultiShotSkill : BaseSkill
{
    private CharacterControler characterControler;
    private EnemyController enemyController;

    //  Antes de swapear el slot, guardamos lo que había. 
    // Sin esto no podríamos restaurarlo en RevertEffect.
    private System.Action originalShootAction;

    
    /*
        Busca el CharacterControler en el mismo GameObject. 
        Usamos Awake en lugar de Start porque Start ya está ocupado en BaseSkill 
        para llamar Activate()
    */
    void Awake()
    {
        characterControler = GetComponent<CharacterControler>();
        enemyController = GetComponent<EnemyController>();

    }

    
    /*
        override es la palabra que dice: "esto es la implementación concreta 
        del método abstracto de la clase padre". 
        Primero guarda el slot original, 
        después lo reemplaza con MultiShot.
    */
    protected override void ApplyEffect()
    {
        if (characterControler != null)
        {
            originalShootAction = characterControler.shootAction;
            characterControler.shootAction = MultiShot;
        }
        else if (enemyController != null)
        {
            originalShootAction = enemyController.shootAction;
            enemyController.shootAction = MultiShot;
        }
    }

    // Restaura el slot al valor original guardado. En CharacterController, el slot apunta al método Shot() 

    protected override void RevertEffect()
    {
        if (characterControler != null)
            characterControler.shootAction = originalShootAction;
        else if (enemyController != null)
            enemyController.shootAction = originalShootAction;
    }
    private void MultiShot()
    {
        Shooting shooting = GetComponent<Shooting>();
        shooting.Shot();
        shooting.Shot(shooting.shootPoint.up * 0.3f);
        shooting.Shot(shooting.shootPoint.up * 0.6f);
    }
}