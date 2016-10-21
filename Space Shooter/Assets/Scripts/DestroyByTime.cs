using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    //Tempo que os efeitos das explosoes ira demorar para serem deletadas da instacia.
    public float lifetime;

    void Start() {
        Destroy(gameObject, lifetime);
    }
}
