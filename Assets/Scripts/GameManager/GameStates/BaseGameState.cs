using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;

    [HideInInspector]
    public string stateName;

    public abstract string GetStateName();
    public abstract void Enter(BaseGameState from);
    public abstract void Exit(BaseGameState to);
    public abstract void Tick();  
}
