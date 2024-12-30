using R3;

namespace Core.GameResources
{
    public class ReactiveResource
    {
        private readonly ResourceData _origin;
        public string Id => _origin.Id;
        
        public readonly ReactiveProperty<long> Value;
        
        public ReactiveResource(ResourceData origin)
        {
            _origin = origin;
            Value = new ReactiveProperty<long>(origin.Value);
            Value.Subscribe(value => _origin.Value = value);
        }
    }
}