namespace Puzzles
{
    using System;

    public class Debouncer
    {
        private readonly float _delay;
        private float _timer = -1f;
        private Action _callback;
        private bool _active = false;

        public Debouncer(float delaySeconds)
        {
            _delay = delaySeconds;
        }

        public void Trigger(Action action)
        {
            _callback = action;
            _timer = _delay;
            _active = true;
        }

        public void Cancel()
        {
            _active = false;
            _timer = -1f;
            _callback = null;
        }

        public void Tick(float deltaTime)
        {
            if (!_active) return;

            _timer -= deltaTime;

            if (!(_timer <= 0f)) return;
            
            _active = false;
            _callback?.Invoke();
        }
    }

}