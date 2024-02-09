using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cars_select : MonoBehaviour
{
    private GameObject[] cars;
    private int index;

    private void Start() 
    {
        index = PlayerPrefs.GetInt("SelectCar");
        cars = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) 
        {
            cars[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in cars)
        {
            go.SetActive(false);
        }

        if (cars[index])
        {
            cars[index].SetActive(true);
        }
    }

    public void SelectLeft() 
    {
        cars[index].SetActive(false);
        index--;
        if (index < 0) 
        {
            index = cars.Length - 1;
        }
        cars[index].SetActive(true);
    }

    public void SelectRight() 
    {
        cars[index].SetActive(false);
        index++;
        if (index == cars.Length) 
        {
            index = 0;
        }
        cars[index].SetActive(true);
    }

    public void MapScene() {
        PlayerPrefs.SetInt("SelectCar", index);
        SceneManager.LoadScene("2d_map");
    }
}
