using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour
{
    public Dropdown whatToDo, fontSizeChoser;
    public Text title1_1, title1_2, title1_3,
        tutorialText1, tutorialText2, tutorialText3,
        settingsLabel, settingsText1;
    public RawImage backgroundChanger, fhLogo;
    public GameObject original;
    public GameObject merge;
    public GameObject splitup;
    public GameObject animate;
    public GameObject functions;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    public void DropDownHandler(int selected)
    {
        switch (selected)
        {
            case 0: //Original no object
                fontSizeChoser.gameObject.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                setUp_Tutorials(false);
                merge.SetActive(false);
                original.SetActive(true);
                splitup.SetActive(false);
                animate.SetActive(false);
                functions.SetActive(false);
                break;
            case 1: //Split Up object
                fontSizeChoser.gameObject.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                setUp_Tutorials(false);
                original.SetActive(false);
                merge.SetActive(false);
                splitup.SetActive(true);
                animate.SetActive(false);
                functions.SetActive(false);
                break;
            case 2: //Merge object
                fontSizeChoser.gameObject.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                original.SetActive(false);
                setUp_Tutorials(false);
                merge.SetActive(true);
                splitup.SetActive(false);
                animate.SetActive(false);
                functions.SetActive(false);
                break;
            case 3: //Animate object
                fontSizeChoser.gameObject.SetActive(false);
                original.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                setUp_Tutorials(false);
                merge.SetActive(false);
                splitup.SetActive(false);
                animate.SetActive(true);
                functions.SetActive(false);
                break;
            case 4: //Schow Functions of the object
                fontSizeChoser.gameObject.SetActive(false);
                original.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                setUp_Tutorials(false);
                merge.SetActive(false);
                splitup.SetActive(false);
                animate.SetActive(false);
                functions.SetActive(true);
                break;
            case 5: //Tutorials
                fontSizeChoser.gameObject.SetActive(false);
                settingsLabel.gameObject.SetActive(false);
                settingsText1.gameObject.SetActive(false);
                setUp_Tutorials(true);
                removeAllLunSimObjects();
                break;
            case 6: //Settings
                setUp_Tutorials(false);
                backgroundChanger.gameObject.SetActive(true);
                fhLogo.gameObject.SetActive(true);
                title1_1.gameObject.SetActive(true);
                title1_2.gameObject.SetActive(true);
                title1_3.gameObject.SetActive(true);
                tutorialText1.gameObject.SetActive(false);
                tutorialText2.gameObject.SetActive(false);
                tutorialText3.gameObject.SetActive(true);
                fontSizeChoser.gameObject.SetActive(true);
                settingsLabel.gameObject.SetActive(true);
                settingsText1.gameObject.SetActive(true);
                removeAllLunSimObjects();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            /*if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }*/

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        //Maybe put in sth later
    }

    void OnSwipeDown()
    {
        //Maybe put in sth later
    }

    void OnSwipeLeft()
    {
        whatToDo.value += + 1;
    }

    void OnSwipeRight()
    {
        whatToDo.value -= whatToDo.value;
    }

    void setUp_Tutorials(bool b)
    {
        backgroundChanger.gameObject.SetActive(b);
        fhLogo.gameObject.SetActive(b);
        title1_1.gameObject.SetActive(b);
        title1_2.gameObject.SetActive(b);
        title1_3.gameObject.SetActive(b);
        tutorialText1.gameObject.SetActive(b);
        tutorialText2.gameObject.SetActive(b);
        tutorialText3.gameObject.SetActive(b);
    }

    void removeAllLunSimObjects()
    {
        original.SetActive(false);
        merge.SetActive(false);
        splitup.SetActive(false);
        animate.SetActive(false);
        functions.SetActive(false);
    }
}


