using System;
using System.Text;
using System.Numerics;
using dungeon_crawler.Engine;
using dungeon_crawler.Engine.Components;
using dungeon_crawler.Engine.Components.Art;
using dungeon_crawler.Engine.Objects;
using dungeon_crawler.Game;
using dungeon_crawler.Engine.Grid;

class Program
{ // make collison work and use rigibody
    public static void Main(string[] arg) {  
        Renderer renderer = new Renderer(40,20);
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
        GameObj map = new GameObj("underGround");

        int height = 18;
        int width = 32;

        Cell[] grid = new Cell[height * width];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                int index = y * width + x;

                grid[index] = new Cell('.', new Vector2(x, height - 1 - y));
            }
        }

        MapAsciiComponent mapAscii = new MapAsciiComponent();
        mapAscii.SetMap(new GridObj(
            grid,
            new Vector2(width, height),
            0
        ));

        map.AddComponent(mapAscii);

        // Border
        GameObj border = new GameObj("Border");
        MapAsciiComponent borderAscii = new MapAsciiComponent();

        Cell[] borderGrid = new Cell[height * width];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                int index = y * width + x;

                bool isBorder = x == 0 || x == width - 1 ||  y == 0 || y == height - 1;

                char character = isBorder ? '#' : ' ';

                borderGrid[index] = new Cell(
                    character,
                    new Vector2(x, width - 1 - y)
                );
            }
        }

        borderAscii.SetMap(new GridObj(
            borderGrid,
            new Vector2(width, height),
            0
        ));

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
            gO.Awake();
        }   

        foreach(GameObj gO in gameObjs) {
            gO.Start();
        }        

        while (true) {
            foreach (GameObj gameObj in gameObjs) {
                gameObj.Update();
            }

            Renderer.instence.ClearBuffer();

            foreach (GameObj gameObj in gameObjs) {
                gameObj.Draw();
            }

            renderer.DrawOnScreen();

            InputManager.instence.WaitForInput(gameObjs);
        }
    }
}


