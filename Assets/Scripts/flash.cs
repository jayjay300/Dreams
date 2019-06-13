using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class flash : MonoBehaviour
{
    public bool loop = true;
    private string[] password;
    private int index = 0;
    private GameObject insert;
    // Use this for initialization
    void Start()
    {
        password = new string[] { "space" };
        insert = GameObject.Find("text");
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown(password[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
            }
            else
            {
                index = 0;
            }
            if (index == password.Length)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private IEnumerator Flash()
    {
        while (true)
        {

            insert.SetActive(false);
            // process pre-yield
            yield return new WaitForSeconds(1.0f);
            // process post-yield
            insert.SetActive(true);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
