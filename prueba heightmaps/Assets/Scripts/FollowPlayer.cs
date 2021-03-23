using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Se va a crear un vector para poner coordenadas
    //public Vector3 offset = new Vector3(x:0, y:12, z:-20);
    private Vector3 playerPreviousPos = Vector3.zero;
    private float distance = 20f;
    private void Update()
    {
        Vector3 offset = player.transform.position - playerPreviousPos;
        // la siguiente linea se agrega si hay un tilileo debido a que el movimiento es poco ,
        // en ese caso no hacer nada si se mueve menos de medio metro
        /*
        if (offset.magnitude < 0.5f)
        {
            return;
            
        }
        */
        offset.Normalize();
        this.transform.position = player.transform.position - offset * distance;
        transform.LookAt(player.transform.position);
        playerPreviousPos = player.transform.position;
        
    }
}