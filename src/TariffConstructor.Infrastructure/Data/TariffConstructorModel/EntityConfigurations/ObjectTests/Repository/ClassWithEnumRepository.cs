
using TariffConstructor.Domain.ObjectTests;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Interface;

namespace TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Repository
{
    public class ClassWithEnumRepository : IClassWithEnum
    {
        private readonly TariffConstructorContext _DbContext;
        public ClassWithEnumRepository(TariffConstructorContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        public void AddElement()
        {
            ClassWithEnum classWithEnum = new ClassWithEnum(1, "value", TimesOfDay.day);
            _DbContext.classWithEnums.AddRange(classWithEnum);
            _DbContext.SaveChanges();
        }
    }
}
