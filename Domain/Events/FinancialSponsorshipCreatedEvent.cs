using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record FinancialSponsorshipCreatedEvent(

        Guid FinancialSponsorshipEntryId,

        string AwardingOrganization,

        string SponsorshipType,

        Money AmountFunded,

        string AdmissionNumber

    ) : IDomainEvent;
}
