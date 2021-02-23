using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int gems = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            SceneManager.LoadScene("Game_Over");
        }
        if (other.tag == "Gem")
        {
            gems = gems + 1; 
        }
        if (other.tag == "Portal")
        {
            if (gems >= 3)
            {
                SceneManager.LoadScene("Victory"); 
            } 
        }
    }
}
