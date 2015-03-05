using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AIronMan.Services {
    public static class ErrorCodeString {
        public static string UserServiceStatusString(ErrorCode.UserServiceStatus status) {
            switch (status) {
                case ErrorCode.UserServiceStatus.Success:
                    return "Success";
                case ErrorCode.UserServiceStatus.DuplicateUserName:
                    return "Duplicate UserName";
                case ErrorCode.UserServiceStatus.DuplicateEmail:
                    return "Duplicate Email";
                case ErrorCode.UserServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string ConfigServiceStatusString(ErrorCode.ConfigServiceStatus status) {
            switch (status) {
                case ErrorCode.ConfigServiceStatus.Success:
                    return "Success";
                case ErrorCode.ConfigServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string BlogServiceStatusString(ErrorCode.BlogServiceStatus status) {
            switch (status) {
                case ErrorCode.BlogServiceStatus.Success:
                    return "Success";
                case ErrorCode.BlogServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string PostServiceStatusString(ErrorCode.PostServiceStatus status) {
            switch (status) {
                case ErrorCode.PostServiceStatus.Success:
                    return "Success";
                case ErrorCode.PostServiceStatus.TitleMustBeUniquePerBlog:
                    return "Title Must Be Unique Per Blog";
                case ErrorCode.PostServiceStatus.BlockCommentYouUseSpamWords:
                    return "Block Comment You Use Spam Words";
                case ErrorCode.PostServiceStatus.InvalidDownloadFilePath:
                    return "Invalid download file path";
                case ErrorCode.PostServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string PageServiceStatusString(ErrorCode.PageServiceStatus status) {
            switch (status) {
                case ErrorCode.PageServiceStatus.Success:
                    return "Success";
                case ErrorCode.PageServiceStatus.NameAlreadyExists:
                    return "Name already exists";
                case ErrorCode.PageServiceStatus.UrlAlreadyExists:
                    return "Url already exists";
                case ErrorCode.PageServiceStatus.SliderIdIsRequiredForSelectedLayout:
                    return "SliderId Is Required For Selected Layout";
                case ErrorCode.PageServiceStatus.PortfolioIdIsRequiredForSelectedLayout:
                    return "PortfolioId Is Required For Selected Layout";
                case ErrorCode.PageServiceStatus.BlogIdIsRequiredForSelectedLayout:
                    return "BlogId Is Required For Selected Layout";
                case ErrorCode.PageServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string SettingServiceStatus(ErrorCode.SettingServiceStatus status) {
            switch (status) {
                case ErrorCode.SettingServiceStatus.Success:
                    return "Success";
                case ErrorCode.SettingServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string FileServiceStatus(ErrorCode.FileServiceStatus status) {
            switch (status) {
                case ErrorCode.FileServiceStatus.Success:
                    return "Success";
                case ErrorCode.FileServiceStatus.FolderNameAlreadyExists:
                    return "Folder Name Already Exists";
                case ErrorCode.FileServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string SiteServiceStatusString(ErrorCode.SiteServiceStatus status) {
            switch (status) {
                case ErrorCode.SiteServiceStatus.Success:
                    return "Success";
                case ErrorCode.SiteServiceStatus.UrlAlreadyDefine:
                    return "Url already define";
                case ErrorCode.SiteServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string PageTemplateServiceStatus(ErrorCode.PageTemplateServiceStatus status) {
            switch (status) {
                case ErrorCode.PageTemplateServiceStatus.Success:
                    return "Success";
                case ErrorCode.PageTemplateServiceStatus.NameRequired:
                    return "NameRequired";
                case ErrorCode.PageTemplateServiceStatus.ContentRequired:
                    return "ContentRequired";
                case ErrorCode.PageTemplateServiceStatus.NameAlreadyExists:
                    return "NameAlreadyExists";
                case ErrorCode.PageTemplateServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string SliderServiceStatusString(ErrorCode.SliderServiceStatus status) {
            switch (status) {
                case ErrorCode.SliderServiceStatus.Success:
                    return "Success";
                case ErrorCode.SliderServiceStatus.NameRequired:
                    return "Name Required";
                case ErrorCode.SliderServiceStatus.NameAlreadyExists:
                    return "Name Already Exists";
                case ErrorCode.SliderServiceStatus.ImageLocalOrUrlPathIsRequired:
                    return "ImageLocalOrUrlPathIsRequired";
                case ErrorCode.SliderServiceStatus.InvalidImageLocalPath:
                    return "Invalid LocalUrlPath, file don't exists";
                case ErrorCode.SliderServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }
        public static string PortfolioServiceStatusString(ErrorCode.PortfolioServiceStatus status) {
            switch (status) {
                case ErrorCode.PortfolioServiceStatus.Success:
                    return "Success";
                case ErrorCode.PortfolioServiceStatus.NameRequired:
                    return "Name Required";
                case ErrorCode.PortfolioServiceStatus.NameAlreadyExists:
                    return "Name Already Exists";
                case ErrorCode.PortfolioServiceStatus.TitleForNodeAlreadyExists:
                     return "Title For Node Already Exists";
                case ErrorCode.PortfolioServiceStatus.ImageProjectThumbUrlPathIsRequired:
                    return "Image Project Thumb Url Path Is Required";
                case ErrorCode.PortfolioServiceStatus.ImageProjectUrlPathIsRequired:
                    return "Image Project Url Path Is Required";
                case ErrorCode.PortfolioServiceStatus.InvalidImageProjectThumbLocalPath:
                    return "Invalid Image Project Thumb Local Path";
                case ErrorCode.PortfolioServiceStatus.InvalidImageProjectLocalPath:
                    return "Invalid Image Project Local Path";
                case ErrorCode.PortfolioServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string CommetsServiceStatusString(ErrorCode.CommentServiceStatus status) {

            switch (status) {
                case ErrorCode.CommentServiceStatus.Success:
                    return "Success";
                case ErrorCode.CommentServiceStatus.BlockCommentYouUseSpamWords:
                    return "BlockCommentYouUseSpamWords";
                case ErrorCode.CommentServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }

        public static string AccountServiceStatusString(ErrorCode.AccountServiceStatus status) {
            switch (status) {
                case ErrorCode.AccountServiceStatus.Success:
                    return "Success";
                case ErrorCode.AccountServiceStatus.InvalidUserNameOrEmail:
                    return "InvalidUserNameOrEmail";
                case ErrorCode.AccountServiceStatus.InvalidPassword:
                    return "InvalidPassword";
                case ErrorCode.AccountServiceStatus.InputNameAndPassPlease:
                    return "InputNameAndPassPlease";
                case ErrorCode.AccountServiceStatus.UnknownError:
                    return "UnknownError";
                default:
                    return "UnknownError";
            }
        }
    }
}
