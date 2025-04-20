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
    public class BursaryApproval
    {
        [Key]
        public Guid ApprovalId { get; private set; }

        public string ApproverFullName { get; private set; }

        public string ApproverNationalIdentificationNumber { get; private set; }

        public string ApproverPhoneNumber { get; private set; }

        public string ApproverEmailAddress { get; private set; }

        public Guid BursaryApplicationId { get; private set; }

        public string ApprovalStatus { get; private set; }

        public string AssignedBatchNumber { get; private set; }

        public Money AmountAppliedFor { get; private set; }

        public Money AmountAllocated { get; private set; }

        public string Remark { get; private set; }

        public DateTime ApprovedDate { get; private set; }

        public virtual BursaryApplication BursaryApplication { get; private set; }

        public BursaryApproval() { }

        public BursaryApproval(
            Guid approvalId,
            string approverFullName,
            string approverNationalIdentificationNumber,
            string approverPhoneNumber,
            string approverEmailAddress,
            Guid bursaryApplicationId,
            string approvalStatus,
            string assignedBatchNumber,
            Money amountAppliedFor,
            Money amountAllocated,
            string remark,
            DateTime approvedDate)
        {
            ApprovalId = approvalId;

            ApproverFullName = approverFullName;

            ApproverNationalIdentificationNumber = approverNationalIdentificationNumber;

            ApproverPhoneNumber = approverPhoneNumber;

            ApproverEmailAddress = approverEmailAddress;

            BursaryApplicationId = bursaryApplicationId;

            ApprovalStatus = approvalStatus;

            AssignedBatchNumber = assignedBatchNumber;

            AmountAppliedFor = amountAppliedFor;

            AmountAllocated = amountAllocated;

            Remark = remark;

            ApprovedDate = approvedDate;

            var bursaryApprovalEvent = new BursaryApprovalCreatedEvent(
                approvalId,
                approverFullName,
                approverNationalIdentificationNumber,
                approverPhoneNumber,
                approverEmailAddress,
                bursaryApplicationId,
                approvalStatus,
                assignedBatchNumber,
                amountAppliedFor,
                amountAllocated,
                remark,
                approvedDate
            );
        }

        public static BursaryApproval CreateNewBursaryApproval(
            Guid approvalId,
            string approverFullName,
            string approverNationalIdentificationNumber,
            string approverPhoneNumber,
            string approverEmailAddress,
            Guid bursaryApplicationId,
            string approvalStatus,
            string assignedBatchNumber,
            Money amountAppliedFor,
            Money amountAllocated,
            string remark,
            DateTime approvedDate)
        {
            return new BursaryApproval(
                approvalId,
                approverFullName,
                approverNationalIdentificationNumber,
                approverPhoneNumber,
                approverEmailAddress,
                bursaryApplicationId,
                approvalStatus,
                assignedBatchNumber,
                amountAppliedFor,
                amountAllocated,
                remark,
                approvedDate
            );
        }

        private void ApplyEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case BursaryApprovalCreatedEvent e:
                    ApplyBursaryApprovalCreatedEvent(e);
                    break;

                case BursaryApprovalUpdatedEvent e:
                    ApplyBursaryApprovalUpdatedEvent(e);
                    break;

                case BursaryApprovalRejectedEvent e:
                    ApplyBursaryApprovalRejectedEvent(e);
                    break;
            }
        }

        public void ApplyBursaryApprovalCreatedEvent(BursaryApprovalCreatedEvent e)
        {
            ApprovalId = e.ApprovalId;

            ApproverFullName = e.ApproverFullName;

            ApproverNationalIdentificationNumber = e.ApproverNationalIdentificationNumber;

            ApproverPhoneNumber = e.ApproverPhoneNumber;

            ApproverEmailAddress = e.ApproverEmailAddress;

            BursaryApplicationId = e.BursaryApplicationId;

            ApprovalStatus = e.ApprovalStatus;

            AssignedBatchNumber = e.AssignedBatchNumber;

            AmountAppliedFor = e.AmountAppliedFor;

            AmountAllocated = e.AmountAllocated;

            Remark = e.Remark;

            ApprovedDate = e.ApprovedDate;
        }

        public void ApplyBursaryApprovalUpdatedEvent(BursaryApprovalUpdatedEvent e)
        {
            if (!string.IsNullOrEmpty(e.ApproverFullName)) ApproverFullName = e.ApproverFullName;

            if (!string.IsNullOrEmpty(e.ApproverNationalIdentificationNumber))
                ApproverNationalIdentificationNumber = e.ApproverNationalIdentificationNumber;

            if (!string.IsNullOrEmpty(e.ApproverPhoneNumber)) ApproverPhoneNumber = e.ApproverPhoneNumber;

            if (!string.IsNullOrEmpty(e.ApproverEmailAddress)) ApproverEmailAddress = e.ApproverEmailAddress;

            if (!string.IsNullOrEmpty(e.AssignedBatchNumber)) AssignedBatchNumber = e.AssignedBatchNumber;

            if (e.AmountAppliedFor != null) AmountAppliedFor = e.AmountAppliedFor;

            if (e.AmountAllocated != null) AmountAllocated = e.AmountAllocated;

            if (!string.IsNullOrEmpty(e.Remark)) Remark = e.Remark;

            ApprovedDate = e.ApprovedDate;
        }

        public void ApplyBursaryApprovalRejectedEvent(BursaryApprovalRejectedEvent e)
        {
            ApprovalId = e.ApprovalId;

            ApproverFullName = e.ApproverFullName;

            ApproverNationalIdentificationNumber = e.ApproverNationalIdentificationNumber;

            ApproverPhoneNumber = e.ApproverPhoneNumber;

            ApproverEmailAddress = e.ApproverEmailAddress;

            BursaryApplicationId = e.BursaryApplicationId;

            ApprovalStatus = e.ApprovalStatus;

            AssignedBatchNumber = e.AssignedBatchNumber;

            AmountAppliedFor = e.AmountAppliedFor;

            AmountAllocated = e.AmountAllocated;

            Remark = e.Remark;

            ApprovedDate = e.ApprovedDate;
        }

        public static BursaryApproval RehydrateBursaryApprovalFromEvents(List<IDomainEvent> events)
        {
            var bursaryApproval = new BursaryApproval();

            foreach (var @event in events)
            {
                bursaryApproval.ApplyEvent(@event);
            }

            return bursaryApproval;
        }
    }
}
