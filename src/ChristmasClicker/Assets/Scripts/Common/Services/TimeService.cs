using UnityEngine;
using VContainer.Unity;

namespace Common.Services
{
    public interface ITimeService
    {
        float Speed { get; }
        float Delta { get; }
    }

    public class TimeService : ITickable, ITimeService
    {
        public float Speed { get; private set; } = 1f;
        public float Delta { get; private set; }

        public void SetSpeed(float value)
        {
            Speed = value;
        }

        public void Tick()
        {
            Delta = Time.deltaTime * Speed;
        }
    }
}