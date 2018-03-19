using UnityEngine;
using UnityEngine.UI;
public class GameMenuState : BaseGameState
{
    public Canvas myCanvas;
    public override string GetStateName()
    {
        return "GameMenu";
    }

    public override void Enter(BaseGameState from)
    {
        myCanvas.gameObject.SetActive(true);
        // TODO: Musica do menu
    }

    public override void Exit(BaseGameState to)
    {
        myCanvas.gameObject.SetActive(false);
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    // --- Metodos adicionais

    public void btnStartGame_Click()
    {
        gameManager.SwitchState("GameRunning");
    }

    public void btnSwitchMenuOption_Click(int dir)
    {
        
    }
}
