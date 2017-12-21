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



	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
