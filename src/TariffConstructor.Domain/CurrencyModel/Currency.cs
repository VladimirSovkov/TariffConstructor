using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.CurrencyModel
{
    public class Currency : Entity, IAggregateRoot
    {
        public Currency(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public int Code { get; private set; }
        public string Name { get; private set; }

        public void SetCode(int code)
        {
            Code = code;
        }

        public void SetName(string name)
        {
            Name = name;
        }
        
        protected Currency()
        {
        }
    }
}
