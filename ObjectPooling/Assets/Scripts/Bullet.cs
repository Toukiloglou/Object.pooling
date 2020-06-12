using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    private void OnEnable() {
        Invoke("Hide", destroyTime);
    }

    void Hide() {
        this.gameObject.SetActive(false);
    }
}
