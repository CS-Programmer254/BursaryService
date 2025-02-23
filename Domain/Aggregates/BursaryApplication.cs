using Domain.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Aggregates
{
    public class BursaryApplication
    {
        public Guid ApplicationId { get; private set; }

        public string ApplicantFullName { get; private set; }

        public string ApplicantPhoneNumber { get; private set; }

        public string EmailAddress { get; private set; }

        public string AdmissionNumber { get; private set; }

        public string NationalIdentificationNumber { get; private set; }

        public string SchoolName { get; private set; }

        public string DepartmentName { get; private set; }

        public string EnrolledCourse { get; private set; }

        public string YearOfStudy { get; private set; }

        public string PreviousAcademicYearGrade { get; private  set; }

        public string SponsorshipType { get; private set; }

        public string AnyFormOfDisability { get; private set; }

        public string ApplicationStatus { get; private set; }

        public DateTime ApplicationDate { get; private set; }

        public Money AmountAppliedFor { get;private set; }

        public string County { get; private set; }

        public string BatchNumber { get; private set; } = "Not Yet Assigned ";

        public BursaryApplication() { }

        public BursaryApplication(Guid applicationId, string applicantFullName, string applicantPhoneNumber, string emailAddress, string admissionNumber, string nationalIdentificationNumber, string schoolName, string departmentName, string enrolledCourse, string yearOfStudy, string previousAcademicYearGrade, string sponsorshipType, string anyFormOfDisability, string applicationStatus, DateTime applicationDate, Money amountAppliedFor, string county)
        {

            ApplicationId = applicationId;

            ApplicantFullName = applicantFullName;

            ApplicantPhoneNumber = applicantPhoneNumber;

            EmailAddress = emailAddress;

            AdmissionNumber = admissionNumber;

            NationalIdentificationNumber = nationalIdentificationNumber;

            SchoolName = schoolName;

            DepartmentName = departmentName;

            EnrolledCourse = enrolledCourse;

            YearOfStudy = yearOfStudy;

            PreviousAcademicYearGrade = previousAcademicYearGrade;

            SponsorshipType = sponsorshipType;

            AnyFormOfDisability = anyFormOfDisability;

            ApplicationStatus = applicationStatus;

            ApplicationDate = applicationDate;

            AmountAppliedFor = amountAppliedFor;

            County = county;

            var bursaryAppliedEvent = new BursaryApplicationCreatedEvent(

                Guid.NewGuid(),

                applicantFullName,

                applicantPhoneNumber,

                emailAddress,

                admissionNumber,

                nationalIdentificationNumber,

                schoolName,

                departmentName,

                enrolledCourse,

                yearOfStudy,

                previousAcademicYearGrade,

                sponsorshipType,

                anyFormOfDisability,

                applicationStatus,

                applicationDate,

                amountAppliedFor,
                
                county
            );

        }

        public static BursaryApplication CreateNewBursaryApplication(Guid applicationId, string applicantFullName,string applicantPhoneNumber, string emailAddress, string admissionNumber, string nationalIdentificationNumber, string schoolName, string departmentName, string enrolledCourse, string yearOfStudy, string previousAcademicYearGrade, string sponsorshipType, string anyFormOfDisability, string applicationStatus, DateTime applicationDate, Money amountAppliedFor, string county)
        {
            return new BursaryApplication(

                applicationId,

                applicantFullName,

                applicantPhoneNumber,

                emailAddress,

                admissionNumber,

                nationalIdentificationNumber,

                schoolName,

                departmentName,

                enrolledCourse,

                yearOfStudy,

                previousAcademicYearGrade,

                sponsorshipType,

                anyFormOfDisability,

                applicationStatus,

                applicationDate,

                amountAppliedFor,
                
                county
             );

        }

        private void ApplyEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case BursaryApplicationCreatedEvent e:

                    ApplyBursaryApplicationCreatedEvent(e);

                    break;

                case BursaryApplicationApprovedEvent e:

                    ApplyBursaryApplicationApprovedEvent(e);

                    break;

                case BursaryApplicationRejectedEvent e:

                    ApplyBursaryApplicationRejectedEvent(e);

                    break;
            }

        }

        public void ApplyBursaryApplicationCreatedEvent(BursaryApplicationCreatedEvent e)
        {

            ApplicationId = e.ApplicationId;
            
            ApplicantFullName = e.ApplicantFullName;

            ApplicantPhoneNumber = e.ApplicantPhoneNumber;

            EmailAddress = e.EmailAddress;

            AdmissionNumber = e.AdmissionNumber;

            NationalIdentificationNumber = e.NationalIdentificationNumber;

            SchoolName = e.SchoolName;

            DepartmentName = e.DepartmentName;

            EnrolledCourse = e.EnrolledCourse;

            YearOfStudy = e.YearOfStudy;

            PreviousAcademicYearGrade = e.previousAcademicYearGrade;

            SponsorshipType = e.SponsorshipType;

            AnyFormOfDisability = e.AnyFormOfDisability;

            ApplicationStatus = "Pending";

            ApplicationDate = e.ApplicationDate;

            AmountAppliedFor = e.AmountAppliedFor;

            County = e.County;
        }
        public void ApplyBursaryApplicationUpdatedEvent(BursaryApplicationUpdatedEvent e)
        {

            if (!string.IsNullOrEmpty(e.ApplicantFullName)) ApplicantFullName = e.ApplicantFullName;

            if (!string.IsNullOrEmpty(e.ApplicantPhoneNumber)) ApplicantPhoneNumber = e.ApplicantPhoneNumber;

            if (!string.IsNullOrEmpty(e.EmailAddress)) EmailAddress = e.EmailAddress;

            if (!string.IsNullOrEmpty(e.AdmissionNumber)) AdmissionNumber = e.AdmissionNumber;

            if (!string.IsNullOrEmpty(e.NationalIdentificationNumber)) NationalIdentificationNumber = e.NationalIdentificationNumber;

            if (!string.IsNullOrEmpty(e.SchoolName)) SchoolName = e.SchoolName;

            if (!string.IsNullOrEmpty(e.DepartmentName)) DepartmentName = e.DepartmentName;

            if (!string.IsNullOrEmpty(e.EnrolledCourse)) EnrolledCourse = e.EnrolledCourse;

            if (!string.IsNullOrEmpty(e.YearOfStudy)) YearOfStudy = e.YearOfStudy;

            if (!string.IsNullOrEmpty(e.previousAcademicYearGrade)) PreviousAcademicYearGrade = e.previousAcademicYearGrade;

            if (!string.IsNullOrEmpty(e.SponsorshipType)) SponsorshipType = e.SponsorshipType;

            if (!string.IsNullOrEmpty(e.AnyFormOfDisability)) AnyFormOfDisability = e.AnyFormOfDisability;

            if (!string.IsNullOrEmpty(e.ApplicationStatus)) ApplicationStatus = e.ApplicationStatus;

            if (e.AmountAppliedFor != null) AmountAppliedFor = e.AmountAppliedFor;

            if (!string.IsNullOrEmpty(e.County)) County = e.County;

        }
        public void ApplyBursaryApplicationApprovedEvent(BursaryApplicationApprovedEvent e)
        {
            ApplicationStatus = "Approved";
        }
        public void ApplyBursaryApplicationRejectedEvent(BursaryApplicationRejectedEvent e)
        {
            ApplicationStatus = "Rejected";
        }
        public static BursaryApplication RehydrateBursaryApplicationFromEvents(List<IDomainEvent> events)
        {

            var bursaryApplication = new BursaryApplication();


            foreach (var @event in events)
            {

                bursaryApplication.ApplyEvent(@event);

            }

            return bursaryApplication;

        }


    }
}
