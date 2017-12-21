using UnityEngine;

public abstract class BaseGameState : MonoBehaviour
{
    [HideInInspector]
    public GameManager gm;

    [HideInInspector]
    public string stateName;

    public abstract void OnEnter(BaseGameState from);
    public abstract void OnExit(BaseGameState to);
    public abstract void OnTick();

    public string GetName()
    {
        return stateName;
    }
}
