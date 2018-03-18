using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager eh a maquina de estados, trocando os estados de acordo com o estado atual do jogo.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Implementacao Singleton
    protected static GameManager gmInstance;
    public static GameManager GMInstance
    {
        get { return gmInstance;  }
    }


    /**** Controle dos estados do jogo ***/

    // Vetor para adicionar os estados do jogo pelo inspector
    public BaseGameState[] gameStates;

    // dicionario de estados do jogo
    protected Dictionary<string, BaseGameState> gameStateDic = new Dictionary<string, BaseGameState>();

    // pilha dos estados
    protected List<BaseGameState> stateStack = new List<BaseGameState>();

    // ultimo estado (topo da pilha)
    public BaseGameState topState
    {
        get
        {
            if (stateStack.Count == 0)
                return null;

            return stateStack[stateStack.Count - 1];
        }
    }

    // preenchendo o dicionario com os estados possiveis
    private void FillGameStateDic()
    {
        // zerando o dicionario
        gameStateDic.Clear();

        if (gameStates.Length == 0)
            return;

        for (int i = 0; i < gameStates.Length; ++i)
        {
            gameStates[i].gm = this;
            gameStateDic.Add(gameStates[i].GetName(), gameStates[i]);
        }

        stateStack.Clear();

        // colocando o primeiro estado na pilha
        PushState(gameStates[0].GetName());
    }

    // colocar um novo estado na pilha
    public void PushState(string name)
    {
        BaseGameState state;
        if (!gameStateDic.TryGetValue(name, out state))
        {
            Debug.LogError("O estado " + name + " nao foi encontrado!");
            return;
        }

        if (gameStateDic.Count > 0)
        {
            stateStack[stateStack.Count - 1].Exit(state);
            state.Enter(stateStack[stateStack.Count - 1]);
        }
        else
        {
            state.Enter(null);
        }
        stateStack.Add(state);
    }

    // tirar o ultimo estado (topo) da pilha
    public void PopState()
    {
        if (stateStack.Count < 2)
        {
            Debug.LogError("Nao foi possivel remover o estado, existe apenas o mesmo na pilha.");
            return;
        }

        stateStack[stateStack.Count - 1].Exit(stateStack[stateStack.Count - 2]);
        stateStack[stateStack.Count - 2].Enter(stateStack[stateStack.Count - 2]);
        stateStack.RemoveAt(stateStack.Count - 1);
    }

    // trocando o estado
    public void SwitchState(string newState)
    {
        BaseGameState state = FindState(newState);
        if (state == null)
        {
            Debug.LogError("Nao foi encontrado um estado com o nome " + newState);
            return;
        }

        stateStack[stateStack.Count - 1].Exit(state);
        state.Enter(stateStack[stateStack.Count - 1]);
        stateStack.RemoveAt(stateStack.Count - 1);
        stateStack.Add(state);
    }

    // procurando um estado pelo nome
    public BaseGameState FindState(string stateName)
    {
        BaseGameState state;
        if (!gameStateDic.TryGetValue(stateName, out state))
        {
            return null;
        }

        return state;
    }


    // MonoBehaviour

    protected void OnEnable()
    {
        // setando a instancia do singleton para este objeto
        gmInstance = this;

        // preenchendo o dicionario com os estados possiveis
        FillGameStateDic();
    }

    protected void Update()
    {
        if (stateStack.Count > 0)
        {
            stateStack[stateStack.Count - 1].Tick();
        }
    }
}
