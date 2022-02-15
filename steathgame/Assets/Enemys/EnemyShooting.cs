using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject theBullet;
    public Transform barrelEnd;
	public int state = 0;
    public int bulletSpeed;
    public float despawnTime = 3.0f;
	public AudioSource playSound;
  
    public float waitBeforeNextShot = 0.25f;
    bool SpotPlayer = false;

	
//starts shooting when the player enters the box collider
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
           //StartCoroutine (ShootingYield ());
			Switching();
			state = 1;
		} 
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
			Switching();
            state = 0;
        } 
    }

	void Switching()
		{
		switch (state)
        	{
        		case 0:
				Debug.Log("stopped");
            	StopCoroutine (ShootingYield ());
            	break;

        	case 1:
            	Debug.Log("started");
				StartCoroutine (ShootingYield ());
				break;

			default:
            	print ("not attacking");
            	break;
		}
	}

    IEnumerator ShootingYield ()
    {
        //code to let player put cool down on single shots like player
		if(state == 1)
		{
        	Shoot();
			 playSound.Play();

            yield return new WaitForSeconds(waitBeforeNextShot);
            
           	StartCoroutine(ShootingYield());
		}
    }
    void Shoot ()
    {
		if(state == 1)
		{
        Debug.Log("shooting");
        for (int i = 0; i < 1; i++)
        {
            var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            Destroy(bullet, despawnTime);
        }
		}
        
    }
	
}