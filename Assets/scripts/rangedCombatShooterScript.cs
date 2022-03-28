using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedCombatShooterScript : MonoBehaviour {

    public Camera cam;
    public float offset;

    public GameObject projectile;
    public Transform projectilePositioner;
	
	void Update () {


        if (Input.GetKey(KeyCode.LeftShift))
        {
            rangedCombatFire();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    void rangedCombatFire()
    {
        //Vector3 difference = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x,
        //                                 Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y,
        //                                 Camera.main.ScreenToWorldPoint(Input.mousePosition).z - transform.position.z);

        //Vector3 mousePosition = Input.mousePosition;
        //Vector3 difference = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
        //transform.up = difference;

        Vector3 difference = cam.ScreenToWorldPoint(new Vector3((Input.mousePosition).x - transform.position.x,
                                                                (Input.mousePosition).y - transform.position.y,
                                                                 10f));
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        print(rotZ);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, projectilePositioner.position, transform.rotation);
        }
    }
}
