using System;
using System.Text;
using System.Numerics;
using dungeon_crawler;
using dungeon_crawler.Game.GameObj;
using dungeon_crawler.Game;
using dungeon_crawler.Engine;
using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Components.Objects;

class Program
{
    public static void Main(string[] arg) {  
        Renderer renderer = new Renderer(30,15);
        InputManager input = new InputManager();

        List<GameObj> gameObjs = new List<GameObj>();

        // Player
        GameObj player = new GameObj("Player");
        player.position = new Vector2(4,6);

        AsciiComponent ascii = new AsciiComponent();
        ascii.SetIcon('@');

        player.AddComponent(ascii);

        // Map
        GameObj map = new GameObj("Player");
        MapAsciiComponent mapAscii = new MapAsciiComponent();

        mapAscii.SetMap(new char[,] {
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'},
            {'.','.','.','.','.', '.','.','.','.','.','.','.','.','.','.','.','.','.','.'}
        });

        map.AddComponent(mapAscii);

        GameObj border = new GameObj("Player");
        MapAsciiComponent borderAscii = new MapAsciiComponent();

        borderAscii.SetMap(new char[,] {
            {'#','#','#','#','#', '#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ', ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#', '#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
        });

        border.AddComponent(borderAscii);

        // set gameobjs
        gameObjs.Add(map);
        gameObjs.Add(player);
        gameObjs.Add(border);

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

            Renderer.instence.DrawOnScreen();

            InputManager.instence.WaitForInput(gameObjs);
        }
    }
}


