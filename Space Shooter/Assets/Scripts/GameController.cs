using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    private Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start() {
        spawnValues.x = 7;
        spawnValues.y = 0;
        spawnValues.z = 16;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);//Esperar antes de prosseguir(Começo de jogo)
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                //Posição randomica dentro da caixa de jogo.
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //Cria o asteriode dentro da caixa conforme o valor randomico gerado.
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);//Esperar antes de prosseguir(Gerar asteroide)
            }
            yield return new WaitForSeconds(waveWait);//Esperar antes de prosseguir(Conjuntos de asteroides)

            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }


        }

    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore() {
        scoreText.text = "Score : " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!!";
        gameOver = true;
    }
}

