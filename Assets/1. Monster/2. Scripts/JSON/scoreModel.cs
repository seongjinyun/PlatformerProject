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
    public int playedTime
    {
        get;
        set;
    }
    public string gamekind
    {
        get;
        set;
    }
    public string key
    {
        get;
        set;
    }

    public scoreModel(string playerName, int score, int playedTime, string gamekind, string key)
    {
        this.playerName = playerName;
        this.score = score;
        this.playedTime = playedTime;
        this.gamekind = gamekind;
        this.key = key;
    }
}
