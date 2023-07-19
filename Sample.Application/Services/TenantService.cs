using Sample.Application.Interface;
using Sample.Domain;

namespace Sample.Application.Services;
public class TenantService : ITenantGetter, ITenantSetter
{
    public Tenant Tenant { get; private set; } = default!;

    public void SetTenant(Tenant tenant)
    {
        Tenant = tenant;
    }
}
