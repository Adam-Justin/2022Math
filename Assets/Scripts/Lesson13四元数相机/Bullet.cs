using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    private void Update()
    {
        this.transform.Translate(this.transform.forward * moveSpeed * Time.deltaTime);
    }
}
