using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Vector3 spawnPoint;

    public string activeGem;

    public bool hasRed;
    public bool hasBlue;
    public bool hasYellow;

    public Image redImage;
    public Image blueImage;
    public Image yellowImage;

    public GameObject[] redObjects;
    public GameObject[] blueObjects;
    public GameObject[] yellowObjects;

    // Start is called before the first frame update
    void Start()
    {
        redObjects = GameObject.FindGameObjectsWithTag("red");
        blueObjects = GameObject.FindGameObjectsWithTag("blue");
        yellowObjects = GameObject.FindGameObjectsWithTag("yellow");

        if (!hasRed)
        {
            disableRedObjects();
            disableBlueObjects();
            disableYellowObjects();
        }
        else
        {
            disableBlueObjects();
            disableYellowObjects();
        }

        spawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if ((activeGem == "red") && hasBlue)
            {
                setActiveGem("blue");
            }
            else if ((activeGem == "blue") && hasYellow)
            {
                setActiveGem("yellow");
            }
            else if (activeGem == "blue")
            {
                setActiveGem("red");
            }
            else if (activeGem == "yellow")
            {
                setActiveGem("red");
            }
        }

        if (Input.GetKeyDown("q"))
        {
            if ((activeGem == "red") && hasYellow)
            {
                setActiveGem("yellow");
            }
            else if ((activeGem == "red") && hasBlue)
            {
                setActiveGem("blue");
            }
            else if (activeGem == "blue")
            {
                setActiveGem("red");
            }
            else if (activeGem == "yellow")
            {
                setActiveGem("blue");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
        }

        if (player.transform.position.y <= -1)
        {
            respawn();
        }
    }

    public void giveRed()
    {
        hasRed = true;
    }

    public void giveBlue()
    {
        hasBlue = true;
    }

    public void giveYellow()
    {
        hasYellow = true;
    }

    public void setActiveGem(string gemColor)
    {
        if (string.IsNullOrEmpty(activeGem) && gemColor == "red")
        {
            enableRedObjects();
            redImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "red" && gemColor == "blue")
        {
            enableBlueObjects();
            disableRedObjects();
            redImage.rectTransform.sizeDelta = new Vector2(40, 40);
            blueImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "red" && gemColor == "yellow")
        {
            enableYellowObjects();
            disableRedObjects();
            redImage.rectTransform.sizeDelta = new Vector2(40, 40);
            yellowImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "blue" && gemColor == "red")
        {
            enableRedObjects();
            disableBlueObjects();
            blueImage.rectTransform.sizeDelta = new Vector2(40, 40);
            redImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "blue" && gemColor == "yellow")
        {
            enableYellowObjects();
            disableBlueObjects();
            blueImage.rectTransform.sizeDelta = new Vector2(40, 40);
            yellowImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "yellow" && gemColor == "red")
        {
            enableRedObjects();
            disableYellowObjects();
            yellowImage.rectTransform.sizeDelta = new Vector2(40, 40);
            redImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        else if (activeGem == "yellow" && gemColor == "blue")
        {
            enableBlueObjects();
            disableYellowObjects();
            yellowImage.rectTransform.sizeDelta = new Vector2(40, 40);
            blueImage.rectTransform.sizeDelta = new Vector2(60, 60);
        }
        activeGem = gemColor;
    }

    public void enableRedObjects()
    {
        foreach (GameObject redObject in redObjects)
        {
            redObject.GetComponent<MeshRenderer>().enabled = true;
            redObject.GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void disableRedObjects()
    {
        foreach (GameObject redObject in redObjects)
        {
            redObject.GetComponent<MeshRenderer>().enabled = false;
            redObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    public void enableBlueObjects()
    {
        foreach (GameObject blueObject in blueObjects)
        {
            blueObject.GetComponent<MeshRenderer>().enabled = true;
            blueObject.GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void disableBlueObjects()
    {
        foreach (GameObject blueObject in blueObjects)
        {
            blueObject.GetComponent<MeshRenderer>().enabled = false;
            blueObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    public void enableYellowObjects()
    {
        foreach (GameObject yellowObject in yellowObjects)
        {
            yellowObject.GetComponent<MeshRenderer>().enabled = true;
            yellowObject.GetComponent<MeshCollider>().enabled = true;
        }
    }

    public void disableYellowObjects()
    {
        foreach (GameObject yellowObject in yellowObjects)
        {
            yellowObject.GetComponent<MeshRenderer>().enabled = false;
            yellowObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    public void respawn()
    {
        player.transform.position = spawnPoint;
    }
}
