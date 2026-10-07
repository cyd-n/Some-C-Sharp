using System;
using System.Text;
using System.Numerics;
using dungeon_crawler.Engine;
using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Components.Art;
using dungeon_crawler.Engine.Components.Objects;
using dungeon_crawler.Game;

class Program
{ // make collison work and use rigibody
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
        player.AddComponent(new PlayerComponent());
        player.AddComponent(new RigidbodyComponent());

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
        
        // Map manager
        GameObj mapLayerManager = new GameObj("MapLayerManager");
        mapLayerManager.AddComponent(new MapLayerManagerComponent());

        // set gameobjs
        gameObjs.Add(map);
        gameObjs.Add(player);
        gameObjs.Add(border);
        gameObjs.Add(mapLayerManager);

        foreach(GameObj gO in gameObjs) {
            gO.Start();
        }        

        while (true) {
            InputManager.instence.WaitForInput(gameObjs);

            foreach (GameObj gameObj in gameObjs) {
                gameObj.Update();
            }

            Renderer.instence.ClearBuffer();

            foreach (GameObj gameObj in gameObjs) {
                gameObj.Draw();
            }

            renderer.DrawTui(new Vector2(0,0), new Vector2(10,10), GuiType.BOX);

            renderer.DrawOnScreen();
        }
    }
}


