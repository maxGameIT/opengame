using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class frame_animation : MonoBehaviour {

    public Sprite[] frame_sprites;
    public float duration = 0.2f;
    public bool is_loop = false;
    public bool play_onload = false;
    private bool is_playing = false;
    private float played_time = 0f;
    private Image img;
    private bool _isOver;

	// Use this for initialization
	void Start () {
        this.img = this.GetComponent<Image>();
        if (this.play_onload)
        {
            if (this.is_loop)
            {
                this.play_loop();
            }
            else
            {
                this.play_once();
            }
        }


	}

    public bool isAttack
    {
        get;
        private set;
    }



    public bool isOver()
    {
        return this._isOver;
    }

    public void play_once()
    {
        if (this.frame_sprites.Length <=1)
        {
            return;
        }
        this.played_time = 0;
        this.is_playing = true;
        this.is_loop = false;
        this._isOver = false;
        once2 = true;
    }

    public void play_loop()
    {
        if (this.frame_sprites.Length <= 1)
        {
            return;
        }
        this.played_time = 0;
        this.is_playing = true;
        this.is_loop = true;
        this._isOver = false;
        once2 = true;
    }

    public void stop_anima()
    {
        this.is_playing = false;
    }
    bool once2 = true;
    bool once = true;

    void Update () {
        if (this.is_playing == false)
        {
            return;
        }
        this.played_time += Time.deltaTime;
        int index = (int)(this.played_time / duration);
        if (isAttack)
        {
            isAttack = false;
        }
        if (index  == 1 && once)
        {
            once = false;
            isAttack = true;
        }
        else if (index != 1)
        {
            once = true;
        }
        

        if (_isOver)
        {
            _isOver = false;
        }
        if (index == this.frame_sprites.Length -1 && once2)
        {
            _isOver = true;
            once2 = false;
        }
        else if (index != this.frame_sprites.Length - 1)
        {
            once2 = true;
        }

        if (!this.is_loop)
        {
            if (this.frame_sprites.Length <= index)
            {
                this.is_playing = false;
                this.played_time = 0f;
            }
            else
            {
                this.img.sprite = this.frame_sprites[index];
            }
        }
        else
        {
            
            while (index >= this.frame_sprites.Length)
            {
                this.played_time -= (this.frame_sprites.Length * duration);
                index -= this.frame_sprites.Length;
            }
            this.img.sprite = this.frame_sprites[index];
        }




    }
}
