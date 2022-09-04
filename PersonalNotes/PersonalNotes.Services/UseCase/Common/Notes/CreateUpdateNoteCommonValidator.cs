using PersonalNotes.Interfaces.Services.Request.Notes;

namespace PersonalNotes.Services.UseCase.Common.Notes
{
    internal static class CreateUpdateNoteCommonValidator
    {
        public static List<string> Validate(CreateNotesRequest request)
        {
            List<string> errors = new();

            if (!IsDateValid(request))
            {
                errors.Add("End date must be greater than Start date");
            }

            if (!IsSubjectValid(request))
            {
                errors.Add("Subject is obligatory");
            }

            if (!IsDescriptionValid(request))
            {
                errors.Add("Description is obligatory");
            }

            return errors;
        }

        private static bool IsDateValid(CreateNotesRequest request)
        {
            return request.StartDate < request.EndDate;
        }
        
        private static bool IsSubjectValid(CreateNotesRequest request)
        {
            return request.Subject != null;
        }

        private static bool IsDescriptionValid(CreateNotesRequest request)
        {
            return request.Description != null;
        }
    }
}
