namespace TariffConstructor.Domain.ObjectTests
{
    public class ClassWithEnum
    {
        public ClassWithEnum(int id
            , string value
            , TimesOfDay times
            )
        {
            Id = id;
            Value = value;
            Time = times;
        }

        protected ClassWithEnum()
        { 
        }

        public int Id { get; private set; }
        public string Value { get; private set; }

        public TimesOfDay Time { get; private set; }

    }
}
