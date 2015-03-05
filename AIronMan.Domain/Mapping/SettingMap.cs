﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AIronMan.Domain.Mapping
{
    public class SettingMap
    {
        [DisplayName("File Upload Path")]
        [StringLength(300)]
        [DefaultValue("~/files")]
        [Description("Files you upload for blog posts will be stored here. Use ~/XYZ to indicate a file path under the website root.")]
        [SettingStorage(StorageLocation.Database, "upload-path")]
        public string UploadPath { get; set; }

        [DisplayName("File Storage Provider")]
        [StringLength(20)]
        [DefaultValue("Filesystem")]
        [Description("The storage provider")]
        [SettingStorage(StorageLocation.Database, "storage-provider")]
        public string StorageProvider { get; set; }

        [DisplayName("Akismet API Key")]
        [StringLength(30)]
        [DefaultValue("37726b9324fe")]
        [Description("If you have your own API key for Akismet, place it here.")]
        [SettingStorage(StorageLocation.Database, "akismet-api-key")]
        public string AkismetApiKey { get; set; }

        [DisplayName("Title")]
        [StringLength(200)]
        [Description("The title shown at the top in the browser")]
        [DefaultValue("Rafał Pisarczyk - home website")]
        [SettingStorage(StorageLocation.Database, "ui-title")]
        public string SiteTitle { get; set; }

        [DisplayName("Introduction")]
        [AllowHtml]
        [StringLength(5000)]
        [DataType("Markdown")]
        [Description("The welcome text that is shown on the home page. You can use markdown.")]
        [DefaultValue("Welcome to your my page.")]
        [SettingStorage(StorageLocation.Database, "ui-introduction")]
        public string Introduction { get; set; }

        //[DisplayName("Main Links")]
        //[StringLength(5000)]
        //[DataType("HTML")]
        //[Description("A list of links shown at the top of each page. Use HTML for this.")]
        //[DefaultValue("<li><a href=\"/about\">About</a></li>")]
        //[SettingStorage(StorageLocation.Database, "ui-links")]
        //public string MainLinks { get; set; }

        [DisplayName("Footer")]
        [AllowHtml]
        [StringLength(3000)]
        [DataType("HTML")]
        [DefaultValue("<p>Powered by <a href=\"http://www.claritycode.com\">ClarityCode</a>, the blog engine of real developers.</p>")]
        [Description("This will appear at the bottom of the page - use it to add copyright information, links to any web hosts, people or technologies that helped you to build the site, and so on.")]
        [SettingStorage(StorageLocation.Database, "ui-footer")]
        public string Footer { get; set; }

        [DisplayName("Default Page")]
        [Description("When users visit the root (/) of your site, it will be equivalent to visiting the page you specify here.")]
        [DefaultValue("home")]
        [StringLength(100)]
        [SettingStorage(StorageLocation.Database, "default-page")]
        public string DefaultPage { get; set; }

        [DisplayName("Author")]
        [StringLength(100)]
        [Description("Your name. Rendered as a meta tag.")]
        [DefaultValue("Rafał Pisarczyk")]
        [SettingStorage(StorageLocation.Database, "search-author")]
        public string Author { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Meta-Description")]
        [StringLength(150)]
        [Description("The description shown to search engines in the meta description tag.")]
        [DefaultValue("My website.")]
        [SettingStorage(StorageLocation.Database, "search-description")]
        public string SearchDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Meta-Keywords")]
        [StringLength(100)]
        [Description("Keywords shown to search engines in the meta-keywords tag (comma-separated text).")]
        [DefaultValue(".net, c#, test")]
        [SettingStorage(StorageLocation.Database, "search-keywords")]
        public string SearchKeywords { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Spam blacklist")]
        [StringLength(500)]
        [DefaultValue("casino")]
        [Description("Comments with these words (case-insensitive) will automatically be marked as spam, in addition to Akismet. Seperate using spaces or newlines.")]
        [SettingStorage(StorageLocation.Database, "spam-blacklist")]
        public string SpamWords { get; set; }

        [DisplayName("Disable comments after")]
        [DefaultValue(0)]
        [Description("If a post is older than this many days, comments will be disabled. Use 0 to allow comments indefinitely.")]
        [SettingStorage(StorageLocation.Database, "spam-comment-disable")]
        public int DisableCommentsOlderThan { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [DisplayName("HTML Head")]
        [StringLength(2000)]
        [DefaultValue("")]
        [Description("Custom HTML that will appear just before the &lt;/head&gt; tag")]
        [SettingStorage(StorageLocation.Database, "ui-html-head")]
        public string HtmlHead { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [DisplayName("HTML Footer")]
        [StringLength(2000)]
        [DefaultValue("")]
        [Description("Custom HTML that will appear just before the &lt;/body&gt; tag")]
        [SettingStorage(StorageLocation.Database, "ui-html-foot")]
        public string HtmlFooter { get; set; }

        [DisplayName("Theme")]
        [StringLength(100)]
        [DefaultValue("ShadeTheme")]
        [Description("The theme which will be used for this website.")]
        [SettingStorage(StorageLocation.Database, "ui-theme")]
        public string Theme { get; set; }

        [DisplayName("Server")]
        [StringLength(100)]
        [DefaultValue("smtp.live.com")]
        [Description("The server name for your SMTP server.")]
        [SettingStorage(StorageLocation.Database, "smtp-server")]
        public string SmtpServer { get; set; }

        [DisplayName("Port")]
        [DefaultValue("587")]
        [Description("The port that your SMTP server listens on.")]
        [SettingStorage(StorageLocation.Database, "smtp-port")]
        public int SmtpPort { get; set; }

        [DisplayName("From")]
        [StringLength(200)]
        [DefaultValue("from@your-site.com")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\\.)+([A-Za-z0-9]{2,4}|museum)$", ErrorMessage = "Please enter a valid email address")]
        [Description("The email address from which emails will be sent.")]
        [SettingStorage(StorageLocation.Database, "smtp-from")]
        public string SmtpFromEmailAddress { get; set; }

        [DisplayName("Username")]
        [StringLength(100)]
        [DefaultValue("")]
        [Description("If your SMTP server requires authentication, enter your username here, or leave it empty.")]
        [SettingStorage(StorageLocation.Database, "smtp-auth-username")]
        public string SmtpUsername { get; set; }

        [DisplayName("Password")]
        [StringLength(100)]
        [DefaultValue("")]
        [Description("If your SMTP server requires authentication, enter your password here, or leave it empty.")]
        [SettingStorage(StorageLocation.Database, "smtp-auth-password")]
        public string SmtpPassword { get; set; }

        [DisplayName("To")]
        [StringLength(200)]
        [DefaultValue("you@your-site.com")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\\.)+([A-Za-z0-9]{2,4}|museum)$", ErrorMessage = "Please enter a valid email address")]
        [Description("The email address you want comment notification emails to be sent to.")]
        [SettingStorage(StorageLocation.Database, "smtp-to")]
        public string SmtpToEmailAddress { get; set; }

        [DisplayName("Use SSL")]
        [DefaultValue(false)]
        [Description("Whether SSL should be used when sending emails")]
        [SettingStorage(StorageLocation.Database, "smtp-ssl")]
        public bool SmtpUseSsl { get; set; }

        [DisplayName("Notify me")]
        [DefaultValue(true)]
        [Description("Notify me when comments are posted")]
        [SettingStorage(StorageLocation.Database, "smtp-comments-on")]
        public bool CommentNotification { get; set; }

        //[DisplayName("Facebook Like")]
        //[DefaultValue(true)]
        //[Description("Show a Facebook 'Like' button under each page")]
        //[SettingStorage(StorageLocation.Database, "facebook-like")]
        //public bool FacebookLike { get; set; }

        [DisplayName("Public History")]
        [DefaultValue(true)]
        [Description("Allow public users to see the 'history' links and view past revisions of your posts.")]
        [SettingStorage(StorageLocation.Database, "show-public-history")]
        public bool EnablePublicHistory { get; set; }

        [DisplayName("Home page")]
        [DefaultValue("blog")]
        [Description("Enter the name of a page to use as your custom home page. Use 'blog' to show a list of recent posts.")]
        [SettingStorage(StorageLocation.Database, "home-page")]
        public string CustomHomePage { get; set; }

        [DisplayName("Enable Disqus commenting")]
        [DefaultValue(false)]
        [Description("Enable the Disqus commenting system. Note - this will still require the theme to also use Disqus.")]
        [SettingStorage(StorageLocation.Database, "enable-disqus-comments")]
        public bool EnableDisqusCommenting { get; set; }

        [DisplayName("Shortname for Disqus")]
        [DefaultValue("")]
        [Description("The shortname of your Disqus comments, configured on the Disqus website.")]
        [SettingStorage(StorageLocation.Database, "disqus-shortname")]
        public string DisqusShortname { get; set; }

        [DisplayName("Blob Storage Connection String")]
        [Description("The connection string to use for blob storage.")]
        [SettingStorage(StorageLocation.Database, "blob-storage-connection-string")]
        public string StorageConnectionString { get; set; }

        [DisplayName("Blob Container Name")]
        [Description("The container to store blobs in.")]
        [SettingStorage(StorageLocation.Database, "blob-storage-container")]
        [DefaultValue("")]
        public string BlobContainerName { get; set; }

        [DisplayName("Logo")]
        [Description("Logo.")]
        [SettingStorage(StorageLocation.Database, "logo")]
        [DefaultValue("logo.png")]
        public string Logo { get; set; }


        [DisplayName("Backend Color")]
        [Description("Kolor tła.")]
        [SettingStorage(StorageLocation.Database, "backendcolor")]
        [DefaultValue("#185EA2")]
        public string BackEndColor { get; set; }

        [DisplayName("Shortcut Icon")]
        [Description("Shortcut icon")]
        [SettingStorage(StorageLocation.Database, "shortcuticon")]
        [DefaultValue("icon/clarity.png")]
        public string ShortcutIcon { get; set; }

        [DisplayName("Default culture")]
        [Description("Default culture")]
        [SettingStorage(StorageLocation.Database, "defaultculture")]
        [DefaultValue("en")]
        public string DefaultCulture { get; set; }

        [DisplayName("Company name")]
        [Description("Company name")]
        [SettingStorage(StorageLocation.Database, "companyname")]
        [DefaultValue("ClarityCode")]
        public string CompanyName { get; set; }

        [DisplayName("Company city")]
        [Description("Company city")]
        [SettingStorage(StorageLocation.Database, "companycity")]
        [DefaultValue("Cracow")]
        public string CompanyCity { get; set; }

        [DisplayName("Company street")]
        [Description("Company street")]
        [SettingStorage(StorageLocation.Database, "companystreet")]
        [DefaultValue("Noname Street")]
        public string CompanyStreet { get; set; }

        [DisplayName("Company latitude")]
        [Description("Company latitude")]
        [SettingStorage(StorageLocation.Database, "companylatitude")]
        [DefaultValue("50.034906")]
        public string CompanyLatitude { get; set; }

        [DisplayName("Company longitude")]
        [Description("Company longitude")]
        [SettingStorage(StorageLocation.Database, "companylongitude")]
        [DefaultValue("19.9315149")]
        public string CompanyLongitude { get; set; }

        [DisplayName("Under Construction")]
        [DefaultValue(false)]
        [Description("Page is under construction for no login users. Text Description")]
        [SettingStorage(StorageLocation.Database, "under-construction")]
        public bool UnderConstruction { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Under Construction Description")]
        [DefaultValue("Sorry the website is under construction, we come back soon.")]
        [Description("Page is under construction, display text description.")]
        [SettingStorage(StorageLocation.Database, "under-construction-text")]
        public string UnderConstructionText { get; set; }
    }
}
