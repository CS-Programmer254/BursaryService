using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Aggregates
{
    public class FamilyStatus
    {
        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string AdmissionNumber { get; private set; }

        [Required]
        public bool IsOrphan { get; private set; }

        [Required]
        public bool IsSingleParent { get; private set; }

        [Required]
        public int NumberOfSiblings { get; private set; }

        [Required]
        public int NumberOfSiblingsInInstitutionOfHigherLearning { get; private set; }

        public  FamilyStatus() { }

        private FamilyStatus(Guid id, string admissionNumber, bool isOrphan, bool isSingleParent, int numberOfSiblings, int numberOfSiblingsInInstitutionOfHigherLearning)
        {
            Id = id;
            AdmissionNumber = admissionNumber;
            IsOrphan = isOrphan;
            IsSingleParent = isSingleParent;
            NumberOfSiblings = numberOfSiblings;
            NumberOfSiblingsInInstitutionOfHigherLearning = numberOfSiblingsInInstitutionOfHigherLearning;

            var familyStatudCreatedEvent = new FamilyStatusCreatedEvent(id, admissionNumber, isOrphan, isSingleParent, numberOfSiblings, numberOfSiblingsInInstitutionOfHigherLearning);
        }

        public static FamilyStatus CreateNewFamilyStatus(Guid id, string admissionNumber, bool isOrphan, bool isSingleParent, int numberOfSiblings, int numberOfSiblingsInInstitutionOfHigherLearning)
        {
            return new FamilyStatus(id, admissionNumber, isOrphan, isSingleParent, numberOfSiblings, numberOfSiblingsInInstitutionOfHigherLearning);
        }

       
        public void ApplyEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case FamilyStatusCreatedEvent e:

                    ApplyCreatedEvent(e);
                    break;
                case FamilyStatusUpdatedEvent e:
                    ApplyUpdatedEvent(e);
                    break;
            }
        }

        private void ApplyCreatedEvent(FamilyStatusCreatedEvent e)
        {
            Id = e.Id;
            AdmissionNumber = e.AdmissionNumber;
            IsOrphan = e.IsOrphan;
            IsSingleParent = e.IsSingleParent;
            NumberOfSiblings = e.NumberOfSiblings;
            NumberOfSiblingsInInstitutionOfHigherLearning = e.NumberOfSiblingsInInstitutionOfHigherLearning;
        }

        private void ApplyUpdatedEvent(FamilyStatusUpdatedEvent e)
        {
            if (!string.IsNullOrEmpty(e.AdmissionNumber)) AdmissionNumber = e.AdmissionNumber;
            if (e.IsOrphan.HasValue) IsOrphan = e.IsOrphan.Value;
            if (e.IsSingleParent.HasValue) IsSingleParent = e.IsSingleParent.Value;
            if (e.NumberOfSiblings.HasValue) NumberOfSiblings = e.NumberOfSiblings.Value;
            if (e.NumberOfSiblingsInInstitutionOfHigherLearning.HasValue) NumberOfSiblingsInInstitutionOfHigherLearning = e.NumberOfSiblingsInInstitutionOfHigherLearning.Value;
        }

        public static FamilyStatus RehydrateFromEvents(IEnumerable<IDomainEvent> events)
        {
            var familyStatus = new FamilyStatus();

            foreach (var @event in events)
            {
                familyStatus.ApplyEvent(@event);
            }
            return familyStatus;
        }
    }
}
