using Bogus;

namespace Challenge.Konsi.Tests.Unit.Common.Fixtures;

public abstract class BaseFixture
{
    public Faker Faker { get; set; }

    protected BaseFixture()
        => Faker = new Faker("pt_BR");
}
