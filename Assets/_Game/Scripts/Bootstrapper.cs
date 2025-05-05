using UnityEngine;

namespace Game
{
    internal class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        
        private InputSystem _inputSystem;
        private ReplaySystem _replaySystem;
        private PlayerFactory _playerFactory;
        private CloneFactory _cloneFactory;
        
        private void Awake()
        {
            InitializeSystems();
            InitializeFactories();
        }

        private void InitializeSystems()
        {
            _inputSystem = new InputSystem();
            _replaySystem = new ReplaySystem();
        }
        
        private void InitializeFactories()
        {
            var stats = Resources.Load<UnitStats>(Constance.Units.UnitStatsPath);
            var playerData = new PlayerData(stats);
            
            _cloneFactory = new CloneFactory(stats, playerData, _replaySystem, spawnPoint.position);
            _playerFactory = new PlayerFactory(playerData, _inputSystem, spawnPoint.position, _replaySystem, _cloneFactory);
        }

        private void Start()
        {
            _playerFactory.InstantiatePlayer();
        }

        private void Update()
        {
            _inputSystem.OnUpdate();
        }

        private void OnDestroy()
        {
            _playerFactory.Dispose();
            _cloneFactory.Dispose();
            _replaySystem.Dispose();
        }
    }
}

