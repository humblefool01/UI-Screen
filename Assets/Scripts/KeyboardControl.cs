using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardControl : MonoBehaviour {

    public Sprite kick_off_basic, kick_off_selected, career_mode_basic, career_mode_selected, fut_basic, fut_selected, wc_basic, wc_selected;
    public Button kick_off_button, career_mode_button, button_3, button_4;
    private int right = 0;


    public void Start() {
        ChangeBackground(kick_off_button, kick_off_selected, 1f);
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.RightArrow) && right < 2) {
            right += 1;
            Highlight(right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && right > 0) {
            right -= 1;
            Highlight(right);
        }
        if (right == 2 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeBackground(button_3, wc_basic, 0.68f);
            ChangeBackground(button_4, fut_selected, 1f);
        }
        if (right == 2 && Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangeBackground(button_4, fut_basic, 0.68f);
            ChangeBackground(button_3, wc_selected, 1f);
        }
    }

    private void Highlight(int right) {
        switch (right) {
            case 0:
                ChangeBackground(career_mode_button, career_mode_basic, 0.68f);                
                ChangeBackground(kick_off_button, kick_off_selected, 1f);
                break;
            case 1:
                ChangeBackground(kick_off_button, kick_off_basic, 0.68f);
                ChangeBackground(button_3, wc_basic, 0.68f);
                ChangeBackground(button_4, fut_basic, 0.68f);
                ChangeBackground(career_mode_button, career_mode_selected,1f);
                break;
            case 2:
                ChangeBackground(career_mode_button, career_mode_basic, 0.68f);
                ChangeBackground(button_3, wc_selected, 1f);
                break;
        }   
    }

    private void ChangeBackground(Button b, Sprite s, float alpha) {
        Color temp = b.image.color;
        temp.a = alpha;
        b.image.sprite = s;
        b.image.color = temp;
    }
}
