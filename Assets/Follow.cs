using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject player;//Référence au joueur


    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
