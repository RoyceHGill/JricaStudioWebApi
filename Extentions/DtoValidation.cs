
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.enums;
using JricaStudioWebAPI.Entities;
using JricaStudioSharedLibrary.Dtos.Admin;
using System.Globalization;

namespace JricaStudioWebAPI.Extentions
{
    public static class DtoValidation
    {
        public static bool Validate(this UpdateAppointmentSubmissionDto appointmentSubmission)
        {

            if (!ValidateFirstName(appointmentSubmission.FirstName)
                || !ValidateEmail(appointmentSubmission.Email)
                || !ValidatePhoneNumber(appointmentSubmission.Phone)
                || !ValidateBookingDate(appointmentSubmission.StartTime)
                || !ValidateDateOfBirth(appointmentSubmission.DOB)
                || appointmentSubmission.HasAllergies
                || appointmentSubmission.HasHadEyeProblems4Weeks
                || !appointmentSubmission.IsWavierAcknowledged
                || !appointmentSubmission.Services.Any())
            {
                return false;
            }

            return true;
        }

        public static bool Validate(this UserAdminAddDto dto)
        {
            if (!ValidateFirstName(dto.FirstName)
                || !ValidateEmail(dto.Email)
                || !ValidatePhoneNumber(dto.Phone)
                || !ValidateDateOfBirth(dto.DOB)
                || dto.HasAllergies
                || dto.HasHadEyeProblems4Weeks
                || !dto.IsWaiverAcknowledged)
            {
                return false;
            }
            return true;
        }



        public static bool ValuesEquals(this UpdateAppointmentSubmissionDto submissionDto, Appointment finalizationDto)
        {
            if (submissionDto.FirstName.Equals(finalizationDto.User.FirstName)
                && submissionDto.LastName.Equals(finalizationDto.User.LastName)
                && submissionDto.StartTime == finalizationDto.StartTime
                && submissionDto.Email.Equals(finalizationDto.User.Email)
                && submissionDto.Phone.Equals(finalizationDto.User.Phone)
                && submissionDto.DOB.Equals(finalizationDto.User.DOB)
                && submissionDto.HasAllergies == finalizationDto.User.HasAllergies
                && submissionDto.HasHadEyeProblems4Weeks == finalizationDto.User.HasHadEyeProblems4Weeks
                && submissionDto.HasSensitiveSkin == finalizationDto.User.HasSensitiveSkin)
            {
                return true;
            }

            return false;
        }


        private static bool ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) { return false; }

            if (firstName.Length > 20) { return false; }

            return true;
        }

        private static bool ValidatePhoneNumber(string phoneNumber)
        {
            var stripedPhoneNumber = phoneNumber.Replace(" ", "");

            if (!stripedPhoneNumber.StartsWith("04") && !stripedPhoneNumber.StartsWith("+614"))
            {
                return false;
            }

            if (stripedPhoneNumber.StartsWith("04"))
            {
                stripedPhoneNumber = stripedPhoneNumber.Remove(0, 2);
            }

            if (stripedPhoneNumber.StartsWith("+614"))
            {
                stripedPhoneNumber.Remove(0, 4);
            }

            var stripedPhoneNumberLength = stripedPhoneNumber.Length;

            if (stripedPhoneNumberLength != 8)
            {
                return false;
            }

            if (!int.TryParse(stripedPhoneNumber, NumberStyles.Integer, new CultureInfo("en-AU"), out int number))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateEmail(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }

            var splitEmail = email.Split("@");

            if (splitEmail.Length != 2)
            {
                return false;
            }

            if (splitEmail.Any(a => a.Contains("@")))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateIndemnityAnswers(AppointmentFinalizationDto appointment)
        {
            if (appointment.HasAllergies || appointment.HasHadEyeProblems4Weeks)
            {
                return false;
            }

            return true;
        }

        private static bool ValidateBookingDate(DateTime? startTime)
        {
            if (startTime != null)
            {
                if (startTime < DateTime.UtcNow)
                {
                    return false;
                }

                if (startTime?.Minute != 00)
                {
                    return false;
                }

                return true;
            }
            return false;
        }

        private static bool ValidateDateOfBirth(DateOnly DOB)
        {
            if (DOB > DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-18)))
            {
                return false;
            }

            return true;
        }
    }

}
