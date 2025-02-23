using Domain.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class FinancialSponsorship
    {
        public Guid FinancialSponsorshipEntryId { get; private set; }

        public string AwardingOrganization { get; private set; }

        public string SponsorshipType { get; private set; }

        public Money AmountFunded { get; private set; }

        public string AdmissionNumber { get; private set; }

        public FinancialSponsorship() { }

        public FinancialSponsorship(Guid financialSponsorshipEntryId, string awardingOrganization, string sponsorshipType, Money amountFunded, string admissionNumber)
        {
            FinancialSponsorshipEntryId = financialSponsorshipEntryId;

            AwardingOrganization = awardingOrganization;

            SponsorshipType = sponsorshipType;

            AmountFunded = amountFunded;

            AdmissionNumber = admissionNumber;
          
            var financialSponsorshipCreatedEvent = new FinancialSponsorshipCreatedEvent(
               
                financialSponsorshipEntryId,

                awardingOrganization,
                
                sponsorshipType,

                amountFunded,

                admissionNumber
            );

        }

        public static FinancialSponsorship CreateNewFinancialSponsorship(Guid financialSponsorshipEntryId, string awardingOrganization, string sponsorshipType, Money amountFunded, string admissionNumber)
        {
            return new FinancialSponsorship(financialSponsorshipEntryId, awardingOrganization, sponsorshipType, amountFunded, admissionNumber);
        }

        public void ApplyEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case FinancialSponsorshipCreatedEvent e:

                    ApplyCreatedEvent(e);

                    break;
                case FinancialSponsorshipUpdatedEvent e:

                    ApplyUpdatedEvent(e);
                    break;
            }
        }

        private void ApplyCreatedEvent(FinancialSponsorshipCreatedEvent e)
        {
            FinancialSponsorshipEntryId = e.FinancialSponsorshipEntryId;
            AwardingOrganization = e.AwardingOrganization;
            SponsorshipType = e.SponsorshipType;
            AmountFunded = e.AmountFunded;
            AdmissionNumber = e.AdmissionNumber;
        }
        private void ApplyUpdatedEvent(FinancialSponsorshipUpdatedEvent e)
        {
            if (!string.IsNullOrEmpty(e.AwardingOrganization)) AwardingOrganization = e.AwardingOrganization;
            if (!string.IsNullOrEmpty(e.SponsorshipType)) SponsorshipType = e.SponsorshipType;
            if (e.AmountFunded != null) AmountFunded = e.AmountFunded;
            if (!string.IsNullOrEmpty(e.AdmissionNumber)) AdmissionNumber = e.AdmissionNumber;
        }

        public static FinancialSponsorship RehydrateFinancialSponsorshipFromEvents(IEnumerable<IDomainEvent> events)
        {
            var sponsorship = new FinancialSponsorship();

            foreach (var domainEvent in events)
            {
                sponsorship.ApplyEvent(domainEvent);
            }

            return sponsorship;
        }

    }
}
