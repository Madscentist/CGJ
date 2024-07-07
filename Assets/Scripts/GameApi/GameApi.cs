using System.Collections.Generic;
using UnityEngine;

namespace GameApi
{
    public class GameApi : Environment<GameApi>
    {

        public GameManager manager;
        public List<Transform> targetBornPositions;
        
        public void GetKey()
        {
            //TODO  
            print("Get Key");
        }

        public void AddOneBlood()
        {
            //TODO
            print("add one blood");
        }

        public Transform Player()
        {
            return GameObject.FindWithTag("Player").transform;
        }
        
        public void Die()
        {
            //TODO
            print("playerDie");
        }

        public void TouchTarget()
        {
            print("get target");
            manager.GotKey();
            SetTargetPosition();
        }

        public Vector3 GetTargetPosition()
        {
            return GameObject.FindWithTag("Target").transform.position;
            
        }

        public void SetTargetPosition()
        {
            var po = targetBornPositions[Random.Range(0, targetBornPositions.Count)].position;
            GameObject.FindWithTag("Target").transform.position = po;
        }

        public void MonsterGetPlayer()
        {
            print("monter Get player");
        }
    }
}