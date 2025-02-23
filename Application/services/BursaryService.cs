using Application.Commands.Bursary;
using Application.services;
using Domain.Aggregates;
using Domain.Repositories;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class BursaryService : IBursaryService
    {
        private readonly IBursaryRepository _bursaryRepository;

        public BursaryService(IBursaryRepository bursaryRepository)
        {
            _bursaryRepository = bursaryRepository ?? throw new ArgumentNullException(nameof(bursaryRepository));
        }
        public async Task<bool> SaveBursaryApplicationAsync(Guid id,CreateBursaryApplicationCommand createBursaryApplicationCommand)
        {
           
            if (createBursaryApplicationCommand == null)

                throw new ArgumentNullException(nameof(createBursaryApplicationCommand));

            int currentYear = DateTime.UtcNow.Year;

            var existingBursary = await _bursaryRepository.GetBursaryApplicationByIdAsync(id);

            if (existingBursary != null)

                throw new InvalidOperationException("A bursary with the same ID already exists.");

            var existingApplications = await _bursaryRepository.GetByPhoneNumberAsync(createBursaryApplicationCommand.ApplicantPhoneNumber);

            var hasAppliedThisYear = existingApplications.Any(b =>b.ApplicationDate.Year == currentYear ||  b.AdmissionNumber == createBursaryApplicationCommand.AdmissionNumber);

            if (hasAppliedThisYear)

                throw new InvalidOperationException("You can only apply for a bursary once per year.");

            var pendingApplication = existingApplications.FirstOrDefault(b => b.ApplicationStatus == "Pending");

            if (pendingApplication != null)

                throw new InvalidOperationException("You already have a pending bursary application.");

            var bursaryApplication = BursaryApplication.CreateNewBursaryApplication(

              Guid.NewGuid(),

              createBursaryApplicationCommand.ApplicantFullName,

              createBursaryApplicationCommand.ApplicantPhoneNumber,

              createBursaryApplicationCommand.EmailAddress,

              createBursaryApplicationCommand.AdmissionNumber,

              createBursaryApplicationCommand.NationalIdentificationNumber,

              createBursaryApplicationCommand.SchoolName,

              createBursaryApplicationCommand.DepartmentName,

              createBursaryApplicationCommand.EnrolledCourse,

              createBursaryApplicationCommand.YearOfStudy,

              createBursaryApplicationCommand.PreviousAcademicYearGrade,

              createBursaryApplicationCommand.SponsorshipType,

              createBursaryApplicationCommand.AnyFormOfDisability,

              "Pending",

              DateTime.UtcNow,

              createBursaryApplicationCommand.AmountAppliedFor,

              createBursaryApplicationCommand.County
              
              );

            await _bursaryRepository.SaveBursaryApplicationAsync(bursaryApplication);

            return true;
        }

        public async Task<IEnumerable<BursaryApplication?>> GetAllBursaryApplicationsAsync()
        {
            return await _bursaryRepository.GetAllBursaryApplicationsAsync();
        }

        public async Task<BursaryApplication?> GetBursaryApplicationByIdAsync(Guid applicationId)
        {
            return await _bursaryRepository.GetBursaryApplicationByIdAsync(applicationId);
        }

        public async Task<BursaryApplication?> GetBursaryApplicationByPhoneNumberAsync(string phoneNumber)
        {
            var applications = await _bursaryRepository.GetByPhoneNumberAsync(phoneNumber);

            return applications.FirstOrDefault();
        }

        public async Task<bool> UpdateBursaryApplicationByIdAsync(Guid id, UpdateBursaryApplicationCommand updateBursaryApplicationCommand)
        {
            if (updateBursaryApplicationCommand == null)

                throw new ArgumentNullException(nameof(updateBursaryApplicationCommand));

            var existingApplication = await _bursaryRepository.GetBursaryApplicationByIdAsync(id);

            if (existingApplication == null)

                throw new KeyNotFoundException("Bursary application not found.");

            var updatedApplication = new BursaryApplication(

                existingApplication.ApplicationId,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.ApplicantFullName) ? existingApplication.ApplicantFullName : updateBursaryApplicationCommand.ApplicantFullName,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.ApplicantPhoneNumber) ? existingApplication.ApplicantPhoneNumber : updateBursaryApplicationCommand.ApplicantPhoneNumber,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.EmailAddress) ? existingApplication.EmailAddress : updateBursaryApplicationCommand.EmailAddress,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.AdmissionNumber) ? existingApplication.AdmissionNumber : updateBursaryApplicationCommand.AdmissionNumber,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.NationalIdentificationNumber) ? existingApplication.NationalIdentificationNumber : updateBursaryApplicationCommand.NationalIdentificationNumber,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.SchoolName) ? existingApplication.SchoolName : updateBursaryApplicationCommand.SchoolName,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.DepartmentName) ? existingApplication.DepartmentName : updateBursaryApplicationCommand.DepartmentName,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.EnrolledCourse) ? existingApplication.EnrolledCourse : updateBursaryApplicationCommand.EnrolledCourse,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.YearOfStudy) ? existingApplication.YearOfStudy : updateBursaryApplicationCommand.YearOfStudy,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.PreviousAcademicYearGrade) ? existingApplication.PreviousAcademicYearGrade : updateBursaryApplicationCommand.PreviousAcademicYearGrade,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.SponsorshipType) ? existingApplication.SponsorshipType : updateBursaryApplicationCommand.SponsorshipType,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.AnyFormOfDisability) ? existingApplication.AnyFormOfDisability : updateBursaryApplicationCommand.AnyFormOfDisability,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.ApplicationStatus) ? existingApplication.ApplicationStatus : updateBursaryApplicationCommand.ApplicationStatus,

                existingApplication.ApplicationDate,

                existingApplication.AmountAppliedFor,

                string.IsNullOrEmpty(updateBursaryApplicationCommand.County) ? existingApplication.County : updateBursaryApplicationCommand.County

            );

          
            await _bursaryRepository.UpdateBursaryApplicationAsync(updatedApplication);

            return true;
        }

        public Task<IEnumerable<BursaryApplication?>> GetAllBursaryApplicationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
