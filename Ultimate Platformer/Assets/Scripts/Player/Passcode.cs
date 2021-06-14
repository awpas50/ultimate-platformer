using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Passcode : MonoBehaviour
{
    //DEBUG
    public TextMeshProUGUI debug1;
    public TextMeshProUGUI debug2;
    public TextMeshProUGUI debug3;

    public PlayerHack playerHack;

    [HideInInspector] public string debugInput1;
    [HideInInspector] public string debugInput2;
    [HideInInspector] public string debugInput3;

    public TextMeshProUGUI AbilityText1;
    public TextMeshProUGUI AbilityText2;
    public TextMeshProUGUI AbilityText3;

    private string tempInput;

    private string password1 = "lokio";
    private string password2 = "juikk";
    private string password3 = "ukloi";

    private bool pw1Active = false;
    private bool pw2Active = false;
    private bool pw3Active = false;

    [HideInInspector] public int pw1Position = 0;
    [HideInInspector] public int pw2Position = 0;
    [HideInInspector] public int pw3Position = 0;

    public int correctInputAttempts = 0;

    public SpriteRenderer KeyA;
    public SpriteRenderer KeyB;
    public SpriteRenderer KeyC;
    [Header("indicator")]
    public Sprite KeyA1;
    public Sprite KeyA2;
    public Sprite KeyA3;
    public Sprite KeyA4;
    public Sprite KeyA5;
    public Sprite KeyB1;
    public Sprite KeyB2;
    public Sprite KeyB3;
    public Sprite KeyB4;
    public Sprite KeyB5;
    public Sprite KeyC1;
    public Sprite KeyC2;
    public Sprite KeyC3;
    public Sprite KeyC4;
    public Sprite KeyC5;

    public float a1;
    public float a2;
    public float a3;

    private float a2t;
    private void Start()
    {
        a2t = 8;
        playerHack = FindObjectOfType<PlayerHack>();
    }
    void Update()
    {
        a2t += Time.deltaTime;
        a1 = 15 - playerHack.invincibleTimer;
        a2 = 8 - a2t;
        a3 = 15 - playerHack.lowGravityTimer;
        if(a1 > 0f)
        {
            AbilityText1.text = "Heat resistance (" + a1.ToString("0.0") + "s)";
        }
        else
        {
            AbilityText1.text = "Heat resistance";
        }
        if (a2 > 0f)
        {
            AbilityText2.text = "EMP (" + a2.ToString("0.0") + "s)";
        }
        else
        {
            AbilityText2.text = "EMP";
        }
        if (a3 > 0f)
        {
            AbilityText3.text = "Low gravity (" + a3.ToString("0.0") + "s)";
        }
        else
        {
            AbilityText3.text = "Low gravity";
        }
        CheckPasswordState();
        if (debugInput1 == password1)
        {
            Debug.Log("Invinsible");
            AudioManager.instance.Play(SoundList.HeatResistance);
            pw1Position = 0;
            if (correctInputAttempts < 8)
            {
                Score.i.score += 400;
            }
            if (correctInputAttempts >= 8 && correctInputAttempts < 16)
            {
                Score.i.score += 400 * 1.8f;
            }
            if (correctInputAttempts >= 16 && correctInputAttempts < 24)
            {
                Score.i.score += 400 * 2.5f;
            }
            if (correctInputAttempts >= 24)
            {
                Score.i.score += 400 * 4f;
            }
            
            debugInput1 = "";
            playerHack.invincibleTimer = 0;
            pw1Active = false;
        }
        if (debugInput2 == password2)
        {
            Debug.Log("EMP");
            AudioManager.instance.Play(SoundList.EMP);
            pw2Position = 0;
            if (correctInputAttempts < 8)
            {
                Score.i.score += 400;
            }
            if (correctInputAttempts >= 8 && correctInputAttempts < 16)
            {
                Score.i.score += 400 * 1.8f;
            }
            if (correctInputAttempts >= 16 && correctInputAttempts < 24)
            {
                Score.i.score += 400 * 2.5f;
            }
            if (correctInputAttempts >= 24)
            {
                Score.i.score += 400 * 4f;
            }
            debugInput2 = "";
            playerHack.EMPattack();
            a2t = 0;
            pw2Active = false;
        }
        if (debugInput3 == password3)
        {
            Debug.Log("Low gravity");
            AudioManager.instance.Play(SoundList.LowGravity);
            pw3Position = 0;
            if (correctInputAttempts < 8)
            {
                Score.i.score += 400;
            }
            if (correctInputAttempts >= 8 && correctInputAttempts < 16)
            {
                Score.i.score += 400 * 1.8f;
            }
            if (correctInputAttempts >= 16 && correctInputAttempts < 24)
            {
                Score.i.score += 400 * 2.5f;
            }
            if (correctInputAttempts >= 24)
            {
                Score.i.score += 400 * 4f;
            }
            debugInput3 = "";
            playerHack.lowGravityTimer = 0;
            pw3Active = false;
        }

        debug1.text = debugInput1;
        debug2.text = debugInput2;
        debug3.text = debugInput3;
        if (Input.GetKeyDown(KeyCode.U))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("u");
            if(canCheckpw)
            {
                tempInput = "u";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("i");
            if (canCheckpw)
            {
                tempInput = "i";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("o");
            if (canCheckpw)
            {
                tempInput = "o";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("j");
            if (canCheckpw)
            {
                tempInput = "j";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("k");
            if (canCheckpw)
            {
                tempInput = "k";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            bool canCheckpw;
            canCheckpw = playerHack.HackPlatform("l");
            if (canCheckpw)
            {
                tempInput = "l";
                Checkpw1();
                Checkpw2();
                Checkpw3();
            }

        }
    }

    void Checkpw1()
    {
        char c1 = tempInput[0];
        if(!pw1Active)
        {
            if (password1[pw1Position] == c1)
            {
                pw1Position = 1;
                debugInput1 += tempInput;
                pw1Active = true;
            }
            if (password1[pw1Position] != c1)
            {
                return;
            }
        }
        else if (pw1Active)
        {
            if (password1[pw1Position] != c1)
            {
                pw1Position = 0;
                debugInput1 = "";
                pw1Active = false;
            }
            if (password1[pw1Position] == c1)
            {
                pw1Position++;
                debugInput1 += tempInput;
            }
        }
    }
    void Checkpw2()
    {
        char c2 = tempInput[0];
        if (!pw2Active)
        {
            if (password2[pw2Position] == c2)
            {
                pw2Position = 1;
                debugInput2 += tempInput;
                pw2Active = true;
            }
            if (password2[pw2Position] != c2)
            {
                return;
            }
        }
        else if (pw2Active)
        {
            if (password2[pw2Position] != c2)
            {
                pw2Position = 0;
                debugInput2 = "";
                pw2Active = false;
            }
            if (password2[pw2Position] == c2)
            {
                pw2Position++;
                debugInput2 += tempInput;
            }
        }
    }
    void Checkpw3()
    {
        char c3 = tempInput[0];
        if (!pw3Active)
        {
            if (password3[pw1Position] == c3)
            {
                pw3Position = 1;
                debugInput3 += tempInput;
                pw3Active = true;
            }
            if (password3[pw3Position] != c3)
            {
                return;
            }
        }
        else if (pw3Active)
        {
            if (password3[pw3Position] != c3)
            {
                pw3Position = 0;
                debugInput3 = "";
                pw3Active = false;
            }
            if (password3[pw3Position] == c3)
            {
                pw3Position++;
                debugInput3 += tempInput;
            }
        }
    }

    void CheckPasswordState()
    {
        if (debugInput1 == "") KeyA.sprite = KeyA1;
        if (debugInput1 == "l") KeyA.sprite = KeyA2;
        if (debugInput1 == "lo") KeyA.sprite = KeyA3;
        if (debugInput1 == "lok") KeyA.sprite = KeyA4;
        if (debugInput1 == "loki") KeyA.sprite = KeyA5;
        if (debugInput2 == "") KeyB.sprite = KeyB1;
        if (debugInput2 == "j") KeyB.sprite = KeyB2;
        if (debugInput2 == "ju") KeyB.sprite = KeyB3;
        if (debugInput2 == "jui") KeyB.sprite = KeyB4;
        if (debugInput2 == "juik") KeyB.sprite = KeyB5;
        if (debugInput3 == "") KeyC.sprite = KeyC1;
        if (debugInput3 == "u") KeyC.sprite = KeyC2;
        if (debugInput3 == "uk") KeyC.sprite = KeyC3;
        if (debugInput3 == "ukl") KeyC.sprite = KeyC4;
        if (debugInput3 == "uklo") KeyC.sprite = KeyC5;
    }
}
