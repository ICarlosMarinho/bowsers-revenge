using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSerJr : MonoBehaviour

{
    public int lifePoints = 100;
    public Transform positionTeleport1, positionTeleport2, positionTeleport3;
    public int contTeleport = 0;
    public float tempCont = 0;
    public bool teleportReady = true;
    public GameObject yoshiPrefab, toadPrefab;
    private bool aux;
    private int currentPosition = 0;
    public Transform positionEnemy;
    public Animator JrController;
  



    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints > 1)
        {
            tempCont += Time.deltaTime;
            ResetTempCont();

            aux = teleportR();

            if (aux)
            {
                //  enemySpawn();
            }
        }else
        {
            Invoke("StageClearMenu", 3.0f);
        }   
    }

    public void ResetTempCont()
    {
        if(tempCont >= 5)
        {
            tempCont = 0;
            teleportReady = true;
        }
    }

    public bool teleportR()
    {
        int random;
        if(tempCont >= 4 & teleportReady)
        {
            random = RandomRangeExcept(currentPosition);
            teleportReady = false;
            JrController.SetBool("Teleport", true);
       
            if(random == 0)
            {
                transform.position = new Vector3 (positionTeleport1.position.x,positionTeleport1.position.y,positionTeleport1.position.z);
                
            }
            else if(random == 1)
            {
                transform.position = new Vector3(positionTeleport2.position.x, positionTeleport2.position.y, positionTeleport2.position.z);
            }
            else
            {
                transform.position = new Vector3(positionTeleport3.position.x, positionTeleport3.position.y, positionTeleport3.position.z);
            }
            currentPosition = random;
            JrController.SetBool("Teleport", false);
            return true;
        }
        return false;
    }
    public void enemySpawn()
    {
        int random;
        random = Random.Range(0, 1);
        JrController.SetBool("Attack", true);
        if(random == 0)
        {
            Destroy(yoshiPrefab);
            Destroy(toadPrefab);
            Instantiate(yoshiPrefab, positionEnemy);
        }
        else
        {
            Destroy(yoshiPrefab);
            Destroy(toadPrefab);
            Instantiate(toadPrefab,positionEnemy);
        }
        JrController.SetBool("Attack", false);
    }
    public int RandomRangeExcept(int except){
        int number;
        do {
        number = Random.Range(0, 3);
    
        }while (number == except) ;
        
    return number;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Projectile"))
        {
            lifePoints -= 5;
        }else if (other.tag.Equals("Player"))
        {
            lifePoints -= 33;
        }


    }

}


