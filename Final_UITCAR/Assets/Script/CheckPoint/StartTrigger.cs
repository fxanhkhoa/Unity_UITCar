using UnityEngine;
using System.Collections;

public class StartTrigger : MonoBehaviour {

    public GameObject finish_trigger;

    private void OnTriggerEnter(Collider other)
    {
        finish_trigger.SetActive(true);
    }
}
