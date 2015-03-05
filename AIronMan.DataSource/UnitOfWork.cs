﻿using System;

namespace AIronMan.DataSource
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DB _context = new DB();
        private IBlogRepository blogRepository;
        private IPostRepository postRepository;
        private IUserRepository userRepository;
        private ITagRepository tagRepository;
        private ISettingRepository settingRepository;
        private IPageRepository pageRepository;
        private ISiteRepository siteRepository;
        private ICommentRepository commentRepository;
        private IPageTemplateRepository pageTemplateRepository;
        private ISliderHeaderRepository sliderHeaderRepository;
        private ISliderStepRepository sliderStepRepository;
        private ILayoutRepository layoutRepository;
        private IPortfolioHeaderRepository portfolioHeaderRepository;
        private IPortfolioNodeRepository portfolioNodeRepository;
        //private ICategoryPortfolioRepository categoryPortfolioRepository;
        private ILangRepository langRepository;

        public IBlogRepository BlogRepository
        {
            get
            {

                if (this.blogRepository == null)
                {
                    this.blogRepository = new BlogRepository(_context);
                }
                return blogRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {

                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(_context);
                }
                return postRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {

                if (this.tagRepository == null)
                {
                    this.tagRepository = new TagRepository(_context);
                }
                return tagRepository;
            }
        }

        public ISettingRepository SettingRepository
        {
            get
            {

                if (this.settingRepository == null)
                {
                    this.settingRepository = new SettingRepository(_context);
                }
                return settingRepository;
            }
        }

        public IPageRepository PageRepository
        {
            get
            {
                if (this.pageRepository == null)
                {
                    this.pageRepository = new PageRepository(_context);
                }
                return pageRepository;
            }
        }

        public ISiteRepository SiteRepository
        {
            get
            {
                if (this.siteRepository == null)
                {
                    this.siteRepository = new SiteRepository(_context);
                }
                return siteRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new CommentRepository(_context);
                }
                return commentRepository;
            }
        }

        public IPageTemplateRepository PageTemplateRepository
        {
            get
            {
                if (this.pageTemplateRepository == null)
                {
                    this.pageTemplateRepository = new PageTemplateRepository(_context);
                }
                return pageTemplateRepository;
            }
        }

        public ISliderHeaderRepository SliderHeaderRepository
        {
            get
            {
                if (this.sliderHeaderRepository == null)
                {
                    this.sliderHeaderRepository = new SliderHeaderRepostiory(_context);
                }
                return sliderHeaderRepository;
            }
        }

        public ISliderStepRepository SliderStepRepository
        {
            get
            {
                if (this.sliderStepRepository == null)
                {
                    this.sliderStepRepository = new SliderStepRepository(_context);
                }
                return sliderStepRepository;
            }
        }

        public ILayoutRepository LayoutRepository
        {
            get
            {
                if (this.layoutRepository == null)
                {
                    this.layoutRepository = new LayoutRepository(_context);
                }
                return layoutRepository;
            }
        }

        public IPortfolioHeaderRepository PortfolioHeaderRepository
        {
            get
            {
                if (this.portfolioHeaderRepository == null)
                {
                    this.portfolioHeaderRepository = new PortfolioHeaderRepository(_context);
                }
                return portfolioHeaderRepository;
            }
        }

        public IPortfolioNodeRepository PortfolioNodeRepository
        {
            get
            {
                if (this.portfolioNodeRepository == null)
                {
                    this.portfolioNodeRepository = new PortfolioNodeRepository(_context);
                }
                return portfolioNodeRepository;
            }
        }

        //public ICategoryPortfolioRepository CategoryPortfolioRepository {
        //    get {
        //        if (this.categoryPortfolioRepository == null) {
        //            this.categoryPortfolioRepository = new CategoryPortfolioRepository(context);
        //        }
        //        return categoryPortfolioRepository;
        //    }
        //}

        public ILangRepository LangRepository
        {
            get
            {

                if (this.langRepository == null)
                {
                    this.langRepository = new LangRepository(_context);
                }
                return langRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
