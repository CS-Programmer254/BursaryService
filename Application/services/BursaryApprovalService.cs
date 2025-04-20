using Application.Commands.Bursary;
using Application.services;
using Domain.Aggregates;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BursaryApprovalService : IBursaryApprovalService
    {
        private readonly IBursaryApprovalRepository _bursaryApprovalRepository;

        public BursaryApprovalService(IBursaryApprovalRepository bursaryApprovalRepository)
        {
            _bursaryApprovalRepository = bursaryApprovalRepository ?? throw new ArgumentNullException(nameof(bursaryApprovalRepository));
        }

        public async Task<bool> SaveBursaryApproval(ApproveRejectBursaryCommand approveBursaryCommand)
        {
            if (approveBursaryCommand == null)
                throw new ArgumentNullException(nameof(approveBursaryCommand));


            var bursaryApproval = BursaryApproval.CreateNewBursaryApproval(

                Guid.NewGuid(),
                approveBursaryCommand.ApproverFullName,
                approveBursaryCommand.ApproverNationalIdentificationNumber,
                approveBursaryCommand.ApproverPhoneNumber,
                approveBursaryCommand.ApproverEmailAddress,
                approveBursaryCommand.BursaryApplicationId,
                approveBursaryCommand.ApprovalStatus,
                approveBursaryCommand.AssignedBatchNumber,
                approveBursaryCommand.AmountAppliedFor,
                approveBursaryCommand.AmountAllocated,
                approveBursaryCommand.Remark,
                approveBursaryCommand.ApprovedDate
            );

            return await _bursaryApprovalRepository.SaveBursaryApprovalAsync(bursaryApproval);
        }

        public async Task<BursaryApproval?> GetBursaryApprovalById(Guid approvalId)
        {
            if (approvalId == Guid.Empty)

                throw new ArgumentException("Invalid approval ID", nameof(approvalId));

            return await _bursaryApprovalRepository.GetBursaryApprovalByIdAsync(approvalId);
        }

        public async Task<IEnumerable<BursaryApproval?>> GetAllBursaryApprovals()
        {
            return await _bursaryApprovalRepository.GetAllBursaryApprovalAsync();
        }

        public async Task<BursaryApproval?> GetBursaryApprovalByBursaryApplicationId(Guid BursaryApplicationId)
        {
           return await _bursaryApprovalRepository.GetBursaryApprovalByBursaryApplicationIdAsync(BursaryApplicationId);
        }
    }
}
