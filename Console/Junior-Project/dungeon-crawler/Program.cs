using System;
using System.Text;
using System.Numerics;
using dungeon_crawler;
using dungeon_crawler.Game.GameObj;

class Program
{
    public static void Main(string[] arg) {  
        List<GameObj> gameObjs = new List<GameObj>();

        gameObjs.Add(new GameObj("Player", "Player", new Vector2(4,7)));

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


