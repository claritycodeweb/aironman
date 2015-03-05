using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIronMan.Services {
    public class ErrorCode {
        public enum UserServiceStatus {
            Success = 1,
            DuplicateUserName = 2,
            DuplicateEmail = 3,
            InvalidPassword = 4,
            InvalidUserName = 5,
            InvalidEmail = 6,
            UnknownError = 99
        }

        public enum PostServiceStatus {
            Success = 1,
            TitleIsRequired = 2,
            ContentIsRequired = 3,
            TitleMustBeUniquePerBlog = 4,
            BlockCommentYouUseSpamWords = 5,
            InvalidDownloadFilePath = 6,
            UnknownError = 99
        }

        public enum CommentServiceStatus {
            Success = 1,
            BlockCommentYouUseSpamWords = 2,
            UnknownError = 99
        }

        public enum AccountServiceStatus {
            Success = 1,
            InvalidUserNameOrEmail = 2,
            InvalidPassword = 3,
            InputNameAndPassPlease = 4,
            UnknownError = 99
        }

        public enum ConfigServiceStatus {
            Success = 1,
            UnknownError = 99
        }

        public enum BlogServiceStatus {
            Success = 1,
            NameRequired = 2,
            NameAlreadyExists = 3,
            UnknownError = 99
        }

        public enum PageServiceStatus {
            Success = 1,
            NameAlreadyExists = 2,
            UrlAlreadyExists = 3,
            SliderIdIsRequiredForSelectedLayout = 4,
            PortfolioIdIsRequiredForSelectedLayout = 5,
            BlogIdIsRequiredForSelectedLayout = 6,
            UnknownError = 99
        }

        public enum FileServiceStatus {
            Success = 1,
            FolderNameAlreadyExists = 2,
            UnknownError = 99
        }

        public enum SettingServiceStatus {
            Success = 1,
            UnknownError = 99
        }

        public enum SiteServiceStatus {
            Success = 1,
            UrlAlreadyDefine = 2,
            UnknownError = 99
        }

        public enum PageTemplateServiceStatus {
            Success = 1,
            NameRequired = 2,
            ContentRequired = 3,
            NameAlreadyExists = 4,
            UnknownError = 99
        }

        public enum SliderServiceStatus {
            Success = 1,
            NameRequired = 2,
            NameAlreadyExists = 3,
            ImageLocalOrUrlPathIsRequired = 4,
            InvalidImageLocalPath = 5,
            StepNotExists = 6,
            UnknownError = 99
        }

        public enum PortfolioServiceStatus {
            Success = 1,
            NameRequired = 2,
            NameAlreadyExists = 3,
            TitleForNodeAlreadyExists = 4,
            ImageProjectThumbUrlPathIsRequired = 5,
            ImageProjectUrlPathIsRequired = 6,
            InvalidImageProjectThumbLocalPath = 7,
            InvalidImageProjectLocalPath = 8,
            PortfolioHeaderIsRequiredForNode = 9,
            //ImageLocalOrUrlPathIsRequired = 4,
            //InvalidImageLocalPath = 5,
            UnknownError = 99
        }
    }
}
