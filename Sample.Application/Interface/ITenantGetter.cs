using Sample.Application.Services;
using Sample.Domain;

namespace Sample.Application.Interface;

public interface ITenantGetter
{
    Tenant Tenant { get; }
}
