using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    
    public GameObject explosion;//Animação de explosao dos asteroides.
    public GameObject playerExplosion;//Animação de explosao do player.
    public int scoreValue;

    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) {
            return;
        }
        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);//Cria a animação de explosao dos asteroides.
        }
        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);//Cria a animação de explosao do player.
            gameController.GameOver();//Chama a função de fim de jogo.
        }
        
        //Destroy outros objetos
        Destroy(other.gameObject);
        //Destroy objetos que se colidirem
        Destroy(gameObject);

        //Adicionar pontos a score
        gameController.AddScore(scoreValue);
    }
}
