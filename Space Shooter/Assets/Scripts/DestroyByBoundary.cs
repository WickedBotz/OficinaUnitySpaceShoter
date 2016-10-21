using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    //Destroy qualquer objeto que tocar a parede.
    void OnTriggerExit(Collider other) {
        Destroy(other.gameObject);
    }
}
