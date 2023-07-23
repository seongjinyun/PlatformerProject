using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class scoreModel
{
    public string playerName
    {
        get;
        set;
    }
    public int score
    {
        get;
        set;
    }
    public int timer
    {
        get;
        set;
    }
    public string gameKind
    {
        get;
        set;
    }
    public string key
    {
        get;
        set;
    }

    public scoreModel(string playerName, int score, int timer, string gameKind, string key)
    {
        this.playerName = playerName;
        this.score = score;
        this.timer = timer;
        this.gameKind = gameKind;
        this.key = key;
    }
}
