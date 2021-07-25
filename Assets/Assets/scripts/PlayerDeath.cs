using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Transform player;
    private Transform respawn;

    void Ontrigger2d(Collider2D other)
    {
        player.transform.position = respawn.transform.position;
    }
}
