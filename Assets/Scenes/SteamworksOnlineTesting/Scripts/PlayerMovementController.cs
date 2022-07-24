using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovementController : NetworkBehaviour
{
    public float speed;
    private Rigidbody body;

    void Start()
    {
        body = transform.GetChild(0).GetComponent<Rigidbody>();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game") {
            if (!transform.GetChild(0).gameObject.activeSelf) {
                transform.position = new Vector3(Random.Range(-5, 5), 5, Random.Range(-5, 5));
                transform.GetChild(0).gameObject.SetActive(true);
            }
            float xDir = (UnityEngine.Input.GetKey(KeyCode.A) ? -1 : 0) + (UnityEngine.Input.GetKey(KeyCode.D) ? 1 : 0);
            float yDir = (UnityEngine.Input.GetKey(KeyCode.S) ? -1 : 0) + (UnityEngine.Input.GetKey(KeyCode.W) ? 1 : 0);

            Debug.Log(xDir + ", " + yDir);

            Vector3 moveDir = new Vector3(xDir, 0, yDir).normalized;

            body.velocity = moveDir * Time.deltaTime * speed;
        }
    }
}