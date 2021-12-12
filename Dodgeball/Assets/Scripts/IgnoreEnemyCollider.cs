using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemyCollider : MonoBehaviour
{
    void Awake() {
        Physics.IgnoreLayerCollision(10,11);
    }
}
