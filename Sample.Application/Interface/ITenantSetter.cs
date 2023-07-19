using Sample.Application.Services;
using Sample.Domain;

namespace Sample.Application.Interface;

public interface ITenantSetter
{
    void SetTenant(Tenant key);
}