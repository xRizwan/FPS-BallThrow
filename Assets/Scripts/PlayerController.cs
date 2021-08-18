using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ball;
    private GameManager gameManager;
    private bool canShoot = true;
    public GameObject displayBall;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            if (Input.GetMouseButtonDown(0) && canShoot) {
                
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0.1f;
                Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
                GameObject ballIn = (GameObject) Instantiate (ball);
                ballIn.transform.position = screenPos;

                ballIn.GetComponent<Rigidbody>().velocity = (screenPos - Camera.main.transform.position) * 500;
                StartCoroutine(ShootCooldown());
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * horizontal * Time.deltaTime * 30);
            transform.Translate(Vector3.forward * vertical * Time.deltaTime * 30);

            if (Input.GetKeyDown(KeyCode.Space)) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 700, ForceMode.Impulse);
            }
        }
    }

    IEnumerator ShootCooldown() {
        canShoot = false;
        displayBall.SetActive(false);
        yield return new WaitForSeconds(1);
        canShoot = true;
        displayBall.SetActive(true);
    }
}
