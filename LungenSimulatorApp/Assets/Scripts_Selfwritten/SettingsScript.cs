using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Text title1_1, title1_2, title1_3, tutorialText1, tutorialText2, 
        footerText, siteMenu, fontSize, settingsTitle, settingsText1;
    public Dropdown menu, sizeChoser;
    public RawImage fhLogo;

    public int size = 16;
    
    public int footerTextHeight = 70;
    public int footerTextWidth = 520;
    public int widthSiteChoser = 200;
    public int widthFontSizeChoser = 160;
    public int height = 30;
    public int imageW = 160;
    public int imageH = 100;


    //public int title1_1X = -230;
    public int title1_2X = -10;
    public int title1_3X = 105;

    public int tut1Y_Original = 535;
    public int tut2Y_Original = -5;
    public int footerY_Original = -725;

    public int footerY = -725;
    public int tut1Y = 535;
    public int tut2Y = -5;


    public int siteChoserX = -220;
    public int fontSizeChoserX = 190;

    public void ChangeFontSize(int index)
    {
        switch (index)
        {
            case (0): //size 16px
                size = 16;
                widthSiteChoser = 200;
                widthFontSizeChoser = 160;
                footerTextHeight = 70;
                height = 30;
                imageH = 100;
                imageW = 160;
                title1_2X = -10;
                title1_3X = 105;
                tut1Y = 535;
                tut2Y = -5;
                footerY = -725;
                fontSizeChoserX = 190;
                siteChoserX = -220;
                break; 
            case (1): //size 8px
                size = 8;
                widthSiteChoser = 100;
                widthFontSizeChoser = 90;
                footerTextHeight = 70;
                height = 30;
                imageH = 100;
                imageW = 160;
                imageW = 160;
                title1_2X = -25;
                title1_3X = 60;
                tut1Y = 535;
                tut2Y = 30;
                footerY = -725;
                fontSizeChoserX = 150;
                siteChoserX = -270;
                break;
            case (2): //size 12px
                size = 12;
                widthSiteChoser = 150;
                widthFontSizeChoser = 120;
                footerTextHeight = 70;
                height = 30;
                imageH = 100;
                imageW = 160;
                title1_2X = -10;
                title1_3X = 95;
                tut1Y = 535;
                footerY = -725;
                tut2Y = 20;
                fontSizeChoserX = 170;
                siteChoserX = -245;
                break;
            case (3): //size 20px
                size = 20;
                widthSiteChoser = 200;
                widthFontSizeChoser = 160;
                footerTextHeight = 100;
                height = 40;
                imageH = 100;
                imageW = 160;
                title1_2X = 5;
                title1_3X = 145;
                tut1Y = 525;
                tut2Y = -40;
                footerY = -725;
                fontSizeChoserX = 190;
                siteChoserX = -220;
                break;
            case (4): //size 24px
                size = 24;
                widthSiteChoser = 250;
                widthFontSizeChoser = 200;
                footerTextHeight = 150;
                height = 40;
                imageH = 150;
                imageW = 200;
                title1_2X = 10;
                title1_3X = 160;
                tut1Y = 520;
                tut2Y = -55;
                footerY = -725;
                fontSizeChoserX = 210;
                siteChoserX = -195;
                break;
            case (5): //size 30px
                size = 30;
                widthSiteChoser = 300;
                widthFontSizeChoser = 200;
                footerTextHeight = 200;
                height = 50;
                imageH = 150;
                imageW = 200;
                title1_2X = 20;
                title1_3X = 190;
                tut1Y = 515;
                tut2Y = -110;
                footerY = -705;
                fontSizeChoserX = 210;
                siteChoserX = -170;
                break;
        }

        title1_1.fontSize = size+40;
        title1_2.fontSize = size+40;
        title1_3.fontSize = size+40;
        tutorialText1.fontSize = size;
        tutorialText2.fontSize = size;
        footerText.fontSize = size;
        settingsTitle.fontSize = size +8;
        settingsText1.fontSize = size;
        siteMenu.fontSize = size-2;
        fontSize.fontSize = size-2;

        changePositionDropdown(menu, siteChoserX);
        changePositionDropdown(sizeChoser, fontSizeChoserX);

        changePositionTextX(title1_2, title1_2X);
        changePositionTextX(title1_3, title1_3X);

        changePositionTextY(tutorialText1, tut1Y_Original, tut1Y);
        changePositionTextY(tutorialText2, tut2Y_Original, tut2Y);
        changePositionTextY(footerText, footerY_Original, footerY);

        resizeImage(fhLogo, imageW, imageH);

        changeTextFieldSize(footerText, footerTextWidth, footerTextHeight);

        changeMenuSize(menu, widthSiteChoser, height);
        changeMenuSize(sizeChoser, widthFontSizeChoser, height);
    }



    public void changePositionDropdown(Dropdown dd, int x)
    {
        dd.gameObject.transform.position = new Vector3(dd.gameObject.transform.position.x - (dd.gameObject.transform.position.x - (x + 360)), dd.gameObject.transform.position.y, dd.gameObject.transform.position.z);
    }

    public void changePositionTextY(Text t,int org, int y)
    {
        t.transform.position = new Vector3(t.transform.position.x, t.transform.position.y - (org - y), t.transform.position.z);
    }

    public void changePositionTextX(Text t, int x)
    {
        t.transform.position = new Vector3(t.transform.position.x - (t.transform.position.x - (x + 360)), t.transform.position.y, t.transform.position.z);
    }

    public void resizeImage(RawImage image, int w, int h)
    {
        RectTransform rt = image.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(200, 150);
    }

    public void changeTextFieldSize(Text t, int w, int h)
    {
        RectTransform rt = t.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(w, h);
    }

    public void changeMenuSize(Dropdown dropdown, int w, int h)
    {
        RectTransform rt = dropdown.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(w, h);
    }
}
