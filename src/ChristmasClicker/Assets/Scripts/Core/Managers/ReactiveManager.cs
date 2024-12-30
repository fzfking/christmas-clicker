using R3;

namespace Core.Managers
{
    public class ReactiveManager
    {
        private readonly ManagerData _origin;

        public string Id => _origin.Id;
        public readonly ReactiveProperty<bool> Bought;

        public ReactiveManager(ManagerData origin)
        {
            _origin = origin;

            Bought = new(_origin.Bought);
            Bought.Subscribe(bought => _origin.Bought = bought);
        }
    }
}