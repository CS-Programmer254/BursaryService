using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record FeeBalanceCreatedEvent(Guid Id, string AdmissionNumber, Money CurrentBalance) : IDomainEvent;
}