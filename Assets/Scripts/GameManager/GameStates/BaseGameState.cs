using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    [HideInInspector]
    public GameManager gm;

    [HideInInspector]
    public string stateName;

    public abstract void Enter(BaseGameState from);
    public abstract void Exit(BaseGameState to);
    public abstract void Tick();

    public string GetName()
    {
        return stateName;
    }
}
