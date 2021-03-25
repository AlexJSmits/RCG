using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyboardCanvas : MonoBehaviour
{
    #region Image Key Declaration
    private List<Image> KeyDisplayArray = new List<Image>();
    private Image Q;
    private Image W;
    private Image E;
    private Image R;
    private Image T;
    private Image Y;
    private Image U;
    private Image I;
    private Image O;
    private Image P;
    private Image A;
    private Image S;
    private Image D;
    private Image F;
    private Image G;
    private Image H;
    private Image J;
    private Image K;
    private Image L;
    private Image Z;
    private Image X;
    private Image C;
    private Image V;
    private Image B;
    private Image N;
    private Image M;
    private Image Space;
    #endregion

    public CharControl character;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private bool holdingDown;

    // Start is called before the first frame update
    void Start()
    {

        #region Image Component Get
        Q = transform.GetChild(0).GetComponent<Image>();
        W = transform.GetChild(1).GetComponent<Image>();
        E = transform.GetChild(2).GetComponent<Image>();
        R = transform.GetChild(3).GetComponent<Image>();
        T = transform.GetChild(4).GetComponent<Image>();
        Y = transform.GetChild(5).GetComponent<Image>();
        U = transform.GetChild(6).GetComponent<Image>();
        I = transform.GetChild(7).GetComponent<Image>();
        O = transform.GetChild(8).GetComponent<Image>();
        P = transform.GetChild(9).GetComponent<Image>();
        A = transform.GetChild(10).GetComponent<Image>();
        S = transform.GetChild(11).GetComponent<Image>();
        D = transform.GetChild(12).GetComponent<Image>();
        F = transform.GetChild(13).GetComponent<Image>();
        G = transform.GetChild(14).GetComponent<Image>();
        H = transform.GetChild(15).GetComponent<Image>();
        J = transform.GetChild(16).GetComponent<Image>();
        K = transform.GetChild(17).GetComponent<Image>();
        L = transform.GetChild(18).GetComponent<Image>();
        Z = transform.GetChild(19).GetComponent<Image>();
        X = transform.GetChild(20).GetComponent<Image>();
        C = transform.GetChild(21).GetComponent<Image>();
        V = transform.GetChild(22).GetComponent<Image>();
        B = transform.GetChild(23).GetComponent<Image>();
        N = transform.GetChild(24).GetComponent<Image>();
        M = transform.GetChild(25).GetComponent<Image>();
        Space = transform.GetChild(26).GetComponent<Image>();

        KeyDisplayArray.Add(Q);
        KeyDisplayArray.Add(W);
        KeyDisplayArray.Add(E);
        KeyDisplayArray.Add(R);
        KeyDisplayArray.Add(T);
        KeyDisplayArray.Add(Y);
        KeyDisplayArray.Add(U);
        KeyDisplayArray.Add(I);
        KeyDisplayArray.Add(O);
        KeyDisplayArray.Add(P);
        KeyDisplayArray.Add(A);
        KeyDisplayArray.Add(S);
        KeyDisplayArray.Add(D);
        KeyDisplayArray.Add(F);
        KeyDisplayArray.Add(G);
        KeyDisplayArray.Add(H);
        KeyDisplayArray.Add(J);
        KeyDisplayArray.Add(K);
        KeyDisplayArray.Add(L);
        KeyDisplayArray.Add(Z);
        KeyDisplayArray.Add(X);
        KeyDisplayArray.Add(C);
        KeyDisplayArray.Add(V);
        KeyDisplayArray.Add(B);
        KeyDisplayArray.Add(N);
        KeyDisplayArray.Add(M);
        KeyDisplayArray.Add(Space);
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    // kCode.
                    if (character.jumpKey == keyCode | character.leftKey == keyCode | character.rightKey == keyCode | character.crouchKey == keyCode)
                    {
                        for (int i = 0; i < KeyDisplayArray.Count; i++)
                        {
                            if (KeyDisplayArray[i].gameObject.name == keyCode.ToString())
                            {
                                KeyDisplayArray[i].color = new Color32(0, 255, 0, 255);
                            }
                            else if (KeyDisplayArray[i].gameObject.name != keyCode.ToString())
                            {
                                KeyDisplayArray[i].color = new Color32(255, 255, 255, 80);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < KeyDisplayArray.Count; i++)
                        {
                            if (KeyDisplayArray[i].gameObject.name == keyCode.ToString())
                            {
                                KeyDisplayArray[i].color = new Color32(255, 0, 0, 255);
                            }
                            else if (KeyDisplayArray[i].gameObject.name != keyCode.ToString())
                            {
                                KeyDisplayArray[i].color = new Color32(255, 255, 255, 80);
                            }
                        }
                    }
                }
            }
        }

        if (Input.anyKey)
        {
            holdingDown = true;
        }

        if (!Input.anyKey && holdingDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                for (int i = 0; i < KeyDisplayArray.Count; i++)
                {
                    if (KeyDisplayArray[i].gameObject.name == keyCode.ToString())
                    {
                        KeyDisplayArray[i].color = new Color32(255, 255, 255, 80);
                    }
                }
            }
            holdingDown = false;
        }
    }
}
