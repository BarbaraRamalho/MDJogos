using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerVitals : MonoBehaviour
{
    private ThirdPersonCharacter charController;
    private ThirdPersonUserControl playerController;

    private float maxEnergy = 100;
    private float maxMotivation = 100;
    private float maxTemp = 60;

    public float energy;
    public float motivation;
    public float temp;

    public float energyMoveConsumption = .05f;
    public float energyJumpConsumption = .8f;
    public float motivationConsumption = .02f;

    public Image enb;
    public Image mnb;
    public Image tnb;
    
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<ThirdPersonCharacter>();
        playerController = GetComponent<ThirdPersonUserControl>();
        energy = maxEnergy;
        motivation = maxMotivation;
        temp = maxTemp / 2;
    }

    // Update is called once per frame
    void Update()
    {
        enb.fillAmount = energy / maxEnergy;
        mnb.fillAmount = motivation / maxMotivation;
        tnb.fillAmount = temp / maxTemp;
        
        energy -= Time.deltaTime / energyMoveConsumption;
        motivation -= Time.deltaTime / motivationConsumption;

       

        if (energy <= 0) energy = 0;
        else if (energy >= maxEnergy) energy = maxEnergy;
        if (motivation <= 0) motivation = 0;
        else if (motivation >= maxMotivation) motivation = maxMotivation;
        if (temp <= 0) temp = 0;
        else if (temp >= maxTemp) temp = maxTemp;

    }
    

}
