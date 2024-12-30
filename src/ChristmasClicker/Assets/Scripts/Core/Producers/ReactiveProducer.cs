using R3;

namespace Core.Producers
{
    public class ReactiveProducer
    {
        private readonly ProducerData _origin;

        public string Id => _origin.Id;
        public readonly ReactiveProperty<long> Level;

        public ReactiveProducer(ProducerData origin)
        {
            _origin = origin;
            Level = new(origin.Level);
            Level.Subscribe(level => _origin.Level = level);
        }
    }
}