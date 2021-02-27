using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float padding = 1f;

    [SerializeField] GameObject footballprefab;

    [SerializeField] float projectileSpeed = 20f;

    [SerializeField] float projectileFiringTime = 0.1f;

    // boundary coordinates
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(shootContinuously());
        }


    }

    private void Move()
    {
        //var is used as a generic variable. VS allows us to use var and it will set its type depending on the value it will have
        // deltaX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        var deltaY = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;


        

        // the current x position (for the player) is changed with the slight change of deltaX EVERY frame
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        // Mathf.Clamp restricts the new x coorindate to be within the xMin and xMax values.
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        //setup the boundaries of the movement according to the camera
        Camera gameCamera = Camera.main;

        

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;


        


    }

    private void Shoot()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {

            StartCoroutine(shootContinuously());
        }
    }

    IEnumerator shootContinuously()
    {
        //while the coroutine is running  
        while (true)
        {
            //create an instance of the laserPrefab,
            //at the position of the spaceship (this)
            //with default rotation
            GameObject football = Instantiate(footballprefab, this.transform.position, Quaternion.identity) as GameObject;

            //give a velocity to the laser
            football.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringTime);
        }

    }




}
