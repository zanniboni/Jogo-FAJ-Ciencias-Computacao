using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void EndGame(){
        bool areAllEnemiesDead = Enemy_Patrol.count == 0;
        Debug.Log("LOG DE CONTAGEM DE INIMIGOS: " + Enemy_Patrol.count);
        if(gameHasEnded == false){
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            //Reiniciar jogo
            Invoke("Restart", restartDelay);
        }

        if(areAllEnemiesDead){
            Invoke("victory", restartDelay);
        }
        
    }
    
    void victory(){
        SceneManager.LoadScene("Win");
    }
        
    
    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
