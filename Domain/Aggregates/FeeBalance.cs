using Domain.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class FeeBalance
    {
        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string AdmissionNumber { get; private set; }

        [Required]
        public Money CurrentBalance { get; private set; }

        public FeeBalance() { }

        public FeeBalance(Guid id, string admissionNumber, Money currentBalance)
        {
            Id = id;
            AdmissionNumber = admissionNumber;
            CurrentBalance = currentBalance;

            var feeBalanceCreatedEvent = new FeeBalanceCreatedEvent(
                id,
                admissionNumber,
                currentBalance
            );
        }

        public static FeeBalance CreateNewFeeBalance(Guid id, string admissionNumber, Money currentBalance)
        {
            return new FeeBalance(id, admissionNumber, currentBalance);
        }

        public void ApplyEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case FeeBalanceCreatedEvent e:
                    ApplyCreatedEvent(e);
                    break;

                case FeeBalanceUpdatedEvent e:
                    ApplyUpdatedEvent(e);
                    break;
            }
        }

        private void ApplyCreatedEvent(FeeBalanceCreatedEvent e)
        {
            Id = e.Id;
            AdmissionNumber = e.AdmissionNumber;
            CurrentBalance = e.CurrentBalance;
        }

        private void ApplyUpdatedEvent(FeeBalanceUpdatedEvent e)
        {
            if (!string.IsNullOrEmpty(e.AdmissionNumber)) AdmissionNumber = e.AdmissionNumber;
            if (e.CurrentBalance != null) CurrentBalance = e.CurrentBalance;
        }

        public static FeeBalance RehydrateFromEvents(IEnumerable<IDomainEvent> events)
        {
            var feeBalance = new FeeBalance();

            foreach (var domainEvent in events)
            {
                feeBalance.ApplyEvent(domainEvent);
            }

            return feeBalance;
        }

    }
}
