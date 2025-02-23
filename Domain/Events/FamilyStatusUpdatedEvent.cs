using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public record FamilyStatusUpdatedEvent(

         Guid Id,

         string AdmissionNumber,

         bool? IsOrphan,

         bool? IsSingleParent,

         int? NumberOfSiblings,

         int? NumberOfSiblingsInInstitutionOfHigherLearning

     ) : IDomainEvent;
}
