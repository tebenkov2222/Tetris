using UnityEngine;

namespace Version1.Controllers
{
    public class LevelUpController
    {
        private float _lastTime;
        private float _deltaTime = 60;
        private MoveShapeController _moveShapeController;
        public LevelUpController(MoveShapeController moveShapeController)
        {
            _lastTime = Time.time;
            _moveShapeController = moveShapeController;
        }
        
        public void Update()
        {
            if (Time.time - _lastTime > _deltaTime)
            {
                _lastTime = Time.time;
                _moveShapeController.DevideDeltaTime();
            }
        }
    }
}
