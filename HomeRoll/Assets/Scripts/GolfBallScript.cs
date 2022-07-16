using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallScript : MonoBehaviour
{
    public int hitPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitSetup();
    }

    public void HitSetup()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HitPwrSetup();
        }

    }

    public int HitPwrSetup()
    {
        bool powerSetupProgress = true;
        while (powerSetupProgress)
        {
            bool goingUp = true;
            while (goingUp)
            {
                hitPower++;
                Debug.Log(hitPower);
                if (hitPower == 100)
                {
                    goingUp = false;
                }
            }
            while (!goingUp)
            {
                hitPower--;
                Debug.Log(hitPower);
                if (hitPower == 0)
                {
                    goingUp = true;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                powerSetupProgress = false;
            }

        }
        
        Debug.Log(hitPower);
        return hitPower;
    }
}
