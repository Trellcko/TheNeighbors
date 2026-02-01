using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Trellcko.Gameplay.House
{
    public class HouseGenerator : MonoBehaviour
    {
        [SerializeField] private Room[] _roomPrefabs;
        
        [SerializeField] private Wall _wallPrefab;
        [SerializeField] private Wall _wallWithRoomPrefab;
        
        [SerializeField] private Wall[] _spawnedWalls;
        [SerializeField] private List<int> _spawnIndexes;

        private List<Room> _spawnedRooms = new();
        
        private DiContainer _container;


        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Awake()
        {
            GenerateManualHouse();
        }

        [Button]
        public void GenerateRandomHouse()
        {
            List<int> usedIndexes = new();

            GenerateRandomPlaceForRooms(usedIndexes);
            GenerateRooms(usedIndexes);
            ClearUselessDoors(usedIndexes);
        }

        public void GenerateManualHouse()
        {
            ClearOldRooms();
            GenerateManualPlaceForRooms(_spawnIndexes);
            GenerateRooms(_spawnIndexes);
            ClearUselessDoors(_spawnIndexes);
        }

        private void ClearUselessDoors(List<int> usedIndexes)
        {
            for (int i = 0; i < _spawnedWalls.Length; i++)
            {
                if(_spawnedWalls[i].WallType == WallType.Normal || usedIndexes.Contains(i))
                    continue;
                ChangeWall(i, _wallPrefab);
            }

        }

        private void ClearOldRooms()
        {
            foreach (Room room in _spawnedRooms)
            {
                Destroy(room.gameObject);
            }

            _spawnedRooms.Clear();
        }

        private void GenerateRandomPlaceForRooms(List<int> usedIndexes)
        {
            foreach (Room room in _roomPrefabs)
            {
                int counts = 0;
                int pointIndex = -1;
                do
                {
                    if (counts > 100)
                    {
                        Debug.LogError("Can't generate a house at this time");
                        GenerateNormalHouse();
                        usedIndexes.Clear();
                        return;
                    }
                    counts++;
                    pointIndex = Random.Range(0, _spawnedWalls.Length);
                }
                while (usedIndexes.Contains(pointIndex));
                usedIndexes.Add(pointIndex);
                if(_spawnedWalls[pointIndex].WallType == WallType.WithDoor)
                    continue;
                ChangeWall(pointIndex, _wallWithRoomPrefab);
            }
        }

        private void GenerateManualPlaceForRooms(List<int> spawnIndexes)
        {
            foreach (int index in spawnIndexes.Where(index => _spawnedWalls[index].WallType != WallType.WithDoor))
            {
                ChangeWall(index, _wallWithRoomPrefab);
            }
        }

        private void GenerateNormalHouse()
        {
            for (int i = 0; i < _spawnedWalls.Length; i++)
            {
                if(_spawnedWalls[i].WallType == WallType.Normal)
                    continue;
                ChangeWall(i, _wallWithRoomPrefab);
            }
        }

        private void ChangeWall(int index, Wall wallPrefab)
        {
            Wall oldWall = _spawnedWalls[index];
            Transform spawnedWallTransform = _spawnedWalls[index].transform;
            _spawnedWalls[index] = _container
                .InstantiatePrefab(wallPrefab.gameObject, spawnedWallTransform.position, 
                    spawnedWallTransform.rotation, transform)
                .GetComponent<Wall>();
            _container.Inject(_spawnedWalls[index]);
            Destroy(oldWall.gameObject);
        }

        private void GenerateRooms(List<int> usedIndexes)
        {
            for (int i = 0; i < _roomPrefabs.Length; i++)
            {
               _spawnedRooms.Add(_container.InstantiatePrefab(_roomPrefabs[i].gameObject,
                    _spawnedWalls[usedIndexes[i]].transform.position, 
                    _spawnedWalls[usedIndexes[i]].transform.rotation, transform)
                   .GetComponent<Room>());
            }
        }
    }
}