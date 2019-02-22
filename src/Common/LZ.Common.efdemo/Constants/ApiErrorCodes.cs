using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Common.efdemo.Constants
{
    public static class ApiErrorCodes
    {
        public const string AccountBlocked = "account_blocked";

        public const string BadRequest = "bad_request";

        //public const string InvalidRequest = "invalid_request"; obsolete.
        public const string CustomerNotFound = "customer_not_found";

        public const string QuestionNotFound = "question_not_found";
        public const string ThirdParyNotFound = "thirdparty_not_found";
        public const string CustomerNotExists = "customer_not_exists";
        public const string InternalServiceError = "internal_service_error";
        public const string NotAuthorized = "not_authorized";
        public const string CurrentPassswordReq = "current_password_required";
        public const string CurrentPasswordInvalid = "current_password_invalid";
        public const string InvalidLogin = "invalid_login";
        public const string UsernameUnavailable = "username_unavailable";
        public const string SecurityQuestionsNotFound = "security_question_not_found";
        public const string UserLocked = "user_locked";
        public const string UserNameNotFound = "username_not_found";
        public const string ForgotLoginPartialSucess = "forgot_login_partial_success";
        public const string InvalidFields = "invalid_fields";
        public const string TooManySearchResults = "too_many_search_results";
        public const string ExpiredToken = "expired_token";
        public const string NotFound = "not_found";
        public const string CustomerExists = "customer_exists";
        public const string RequestPasswordError = "request_password_error";
        public const string InvalidIPAddress = "invalid_ip_address";
        public const string IncorrectPassword = "incorrect_password";
        public const string TokenNotFound = "token_not_found";

        //Customer
        public const string InvalidEmail = "invalid_email";

        public const string EmailExsits = "email_exists";
        public const string InvalidPassword = "invalid_password";
        public const string CreateCustomerError = "create_customer_error";
        public const string EmailCannotBeEmpty = "email_cannot_be_empty";
        public const string PasswordCannotBeEmpty = "password_cannot_be_empty";
        public const string HistoryNotFound = "history_not_found";

        //Customer Contact
        public const string ContactNotFound = "contact_not_found";

        public const string ContactRequestIsInvalid = "contact_request_invalid";
        public const string ContactNotBelongToCustomer = "contact_not_belong_to_customer";
        public const string UserSecurityQuestionExists = "user_security_question_exists";
        public const string PrimaryContactCannotBeChangeed = "primary_contact_connot_be_changed";

        //Third Party User
        public const string ThirdPartyUserExists = "third_party_user_exists";

        public const string UnknownError = "unknown_error";
    }
}
