using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record FinancialSponsorshipUpdatedEvent(

     Guid FinancialSponsorshipId,

     string AwardingOrganization,

     string SponsorshipType,

     Money AmountFunded,

     string AdmissionNumber

 ) : IDomainEvent;
}
