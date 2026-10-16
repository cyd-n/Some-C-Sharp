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
        
        Renderer renderer = new Renderer(70,30);
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

        MapAsciiComponent mapAscii = new MapAsciiComponent();
        mapAscii.SetMap("Level.coll", new Vector2(151,63));

        map.AddComponent(mapAscii);

        GameObj border = new GameObj("Border");

        MapAsciiComponent borderAscii = new MapAsciiComponent();
        borderAscii.SetMap("Level.map", new Vector2(151,63));

        border.AddComponent(borderAscii);

        // Map manager
        GameObj mapLayerManager = new GameObj("MapLayerManager");
        mapLayerManager.AddComponent(new MapLayerManagerComponent());

        // set gameobjs
        gameObjs.Add(border);
        gameObjs.Add(map);
        gameObjs.Add(player);

        gameObjs.Add(mapLayerManager);

        foreach(GameObj gO in gameObjs) {
            gO.SetState(LifeCycleState.AWAKE);
        }   

        foreach(GameObj gO in gameObjs) {
            gO.SetState(LifeCycleState.START);
        }        

        while (true) {
            foreach (GameObj gameObj in gameObjs) {
                gameObj.SetState(LifeCycleState.UPDATE);
            }

            Renderer.instence.ClearBuffer();

            foreach (GameObj gameObj in gameObjs) {
                gameObj.SetState(LifeCycleState.DRAW);
            }

            renderer.DrawOnScreen();

            InputManager.instence.WaitForInput(gameObjs);
        }
    }
}


