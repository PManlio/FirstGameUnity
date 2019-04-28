using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
        }
    }
}
