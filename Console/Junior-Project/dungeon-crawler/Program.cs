using System;
using System.Text;
using System.Numerics;
using dungeon_crawler;
using dungeon_crawler.Game.GameObj;
using dungeon_crawler.Game;

class Program
{
    public static void Main(string[] arg) {  
        List<GameObj> gameObjs = new List<GameObj>();

        GameObj player = new GameObj("Player");

        AsciiComponent ascii = new AsciiComponent();
        ascii.SetIcon('@');

        player.AddComponent(ascii);

        gameObjs.Add(player);

        foreach(GameObj gO in gameObjs) {
            gO.Start();
        }

        while (true) { // have no delta time
            foreach(GameObj gO in gameObjs) {
                gO.Update();
            }

            foreach(GameObj gO in gameObjs) {
                gO.Draw();
            }
        }
    }
}


