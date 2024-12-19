using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    private void Update()
    {


        if(WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 4);
            CountingDown = 1;
            StartCoroutine(CountDown());
            switch (QTEGen)
            {
                case 1:
                    WaitingForKey = 1;
                    DisplayBox.GetComponent<Text>().text = "[E]";
                    break;
                case 2:
                    WaitingForKey = 2;
                    DisplayBox.GetComponent<Text>().text = "[R]";
                    break;
                case 3:
                    WaitingForKey = 3;
                    DisplayBox.GetComponent<Text>().text = "[T]";
                    break;
            }
        }

        if (Input.anyKeyDown)
        {
            switch (QTEGen)
            {
                case 1:
                    if (Input.GetButtonDown("EKey"))
                    {
                        CorrectKey = 1;
                    }
                    else
                    {
                        CorrectKey = 2;
                    }
                    StartCoroutine(KeyPressing());
                    break;
                case 2:
                    if (Input.GetButtonDown("RKey"))
                    {
                        CorrectKey = 1;
                    }
                    else
                    {
                        CorrectKey = 2;
                    }
                    StartCoroutine(KeyPressing());
                    break;
                case 3:
                    if (Input.GetButtonDown("TKey"))
                    {
                        CorrectKey = 1;
                    }
                    else
                    {
                        CorrectKey = 2;
                    }
                    StartCoroutine(KeyPressing());
                    break;
            }
        }

        IEnumerator KeyPressing()
        {
            QTEGen = 4;
            switch (CorrectKey)
            {
                case 1:
                    CountingDown = 2;
                    PassBox.GetComponent<Text>().text = "PASS!";
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 2:
                    CountingDown = 2;
                    PassBox.GetComponent<Text>().text = "FAIL!";
                    yield return new WaitForSeconds(1.5f);
                    break;
            }

            if (CorrectKey == 1 || CorrectKey == 2)
            {
                CorrectKey = 0;
                PassBox.GetComponent<Text>().text = "";
                DisplayBox.GetComponent<Text>().text = "";
                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
            }

        }

        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(1.5f);
            if (CountingDown == 1)
            {
                QTEGen = 4;
                CountingDown = 2;
                PassBox.GetComponent<Text>().text = "FAIL!!!!";
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                PassBox.GetComponent<Text>().text = "";
                DisplayBox.GetComponent<Text>().text = "";
                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
            }

        }

    }
}
