using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentFruits;

    public Text fruitText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFruits(int fruitsToAdd)
    {
        currentFruits += fruitsToAdd;
        fruitText.text = "Fruits Collected: " + currentFruits;
    }


}
