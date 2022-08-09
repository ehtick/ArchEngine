﻿using System;
using System.Collections.Generic;

namespace ArchEngine.Core.ECS
{
    public class Scene
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public List<GameObject> gameObjects = new List<GameObject>(5);
        private bool isRunning = false;
        
        public void Init()
        {
            
            foreach (var c in gameObjects)
            {
                _log.Info("Initializing gameobject: " + c.name);
                c.Init();
            }
            
        }
        
        public void Start()
        {
            foreach (var c in gameObjects)
            {
                c.Start();
            }

            isRunning = true;
        }

        public void Update()
        {
            foreach (var c in gameObjects)
            {
                c.Update();
            }
        }
        
        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            if (isRunning)
            {
                gameObject.Init();
                gameObject.Start();
            }
               
            

        }
        
        public void RemoveGameObject(GameObject child)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].GetType() == typeof(GameObject) && gameObjects[i].Equals(child))
                {
                    gameObjects.RemoveAt(i);
                    return;
                }
            }
        }

        public GameObject GameObjectFind(String name)
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.name.Equals(name))
                    return gameObject;
            }

            return null;
        }
    }
}