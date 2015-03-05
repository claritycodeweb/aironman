using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections;
using System.Web;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class SliderService : ServiceBase, ISliderService
    {

        public SliderService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public SliderHeader CreateSlider(SliderHeader entity, ref ErrorCode.SliderServiceStatus status)
        {
            User crUser = User;

            var sliders = Context.SliderHeaderRepository.Filter(m => m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()));

            if (sliders.Any())
            {
                status = ErrorCode.SliderServiceStatus.NameAlreadyExists;
                return entity;
            }

            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;

            Context.SliderHeaderRepository.Create(entity);
            Context.Save();

            return entity;
        }


        public IQueryable<SliderHeader> GetSliderWithStep()
        {
            return Context.SliderHeaderRepository.All().Include(m => m.SliderSteps).OrderByDescending(x => x.CrDate);
        }


        public IQueryable<SliderStep> GetSliderStep(int sliderHeaderId)
        {
            var query = Context.SliderStepRepository.Filter(m => m.SliderId == sliderHeaderId);

            return query;
        }

        public IQueryable<SliderStep> GetSliderStep(string sliderHeaderName)
        {
            var query = Context.SliderStepRepository.Filter(m => m.SliderHeader.Name.ToLower().Equals(sliderHeaderName));

            return query;
        }

        public IQueryable<SliderHeader> GetSliderWithoutStep()
        {
            return Context.SliderHeaderRepository.All();
        }

        public SliderHeader GetSliderHeaderById(int id)
        {
            throw new NotImplementedException();
        }


        public SliderStep CreateSliderStep(SliderStep entity, ref ErrorCode.SliderServiceStatus status)
        {
            User crUser = User;

            var sliders = Context.SliderStepRepository.Filter(m => m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) && m.SliderId == entity.SliderId);

            if (sliders.Any())
            {
                status = ErrorCode.SliderServiceStatus.NameAlreadyExists;
                return entity;
            }


            //server.MapPath(entity.ImageLocalPath);

            if (String.IsNullOrEmpty(entity.ImageLocalPath) && String.IsNullOrEmpty(entity.ImageUrlPath) && String.IsNullOrEmpty(entity.ImageBackground))
            {
                status = ErrorCode.SliderServiceStatus.ImageLocalOrUrlPathIsRequired;
                return entity;
            }

            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;

            Context.SliderStepRepository.Create(entity);
            Context.Save();

            return entity;
        }


        public SliderHeader GetSliderById(int id)
        {
            return Context.SliderHeaderRepository.Find(id);
        }


        public SliderHeader UpdateSlider(SliderHeader entity, ref ErrorCode.SliderServiceStatus status)
        {
            var sliders = Context.SliderHeaderRepository.Filter(m => m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) && m.Id != entity.Id);

            if (sliders.Any())
            {
                status = ErrorCode.SliderServiceStatus.NameAlreadyExists;
                return entity;
            }


            User crUser = User;
            SliderHeader entityFromDb = Context.SliderHeaderRepository.Find(entity.Id);
            entityFromDb.Name = entity.Name;
            entityFromDb.Speed = entity.Speed;
            entityFromDb.Pause = entity.Pause;
            entityFromDb.Transition = entity.Transition;
            entityFromDb.Description = entity.Description;

            entityFromDb.LmUser = crUser;
            entityFromDb.LmDate = DateTime.Now;

            Context.SliderHeaderRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }


        public SliderStep GetSliderStepById(int id)
        {
            return Context.SliderStepRepository.Find(id);
        }


        public SliderStep UpdateSliderStep(SliderStep entity, ref ErrorCode.SliderServiceStatus status)
        {
            var sliders = Context.SliderStepRepository.Filter(m =>
                m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) &&
                m.SliderId == entity.SliderId &&
                m.Id != entity.Id);

            if (sliders.Any())
            {
                status = ErrorCode.SliderServiceStatus.NameAlreadyExists;
                return entity;
            }

            if (String.IsNullOrEmpty(entity.ImageLocalPath) && String.IsNullOrEmpty(entity.ImageUrlPath) && String.IsNullOrEmpty(entity.ImageBackground))
            {
                status = ErrorCode.SliderServiceStatus.ImageLocalOrUrlPathIsRequired;
                return entity;
            }

            User crUser = User;
            SliderStep entityFromDb = Context.SliderStepRepository.Find(entity.Id);
            entityFromDb.Name = entity.Name;
            entityFromDb.Title = entity.Title;
            entityFromDb.Content = entity.Content;
            entityFromDb.LinkTo = entity.LinkTo;
            entityFromDb.ImageUrlPath = entity.ImageUrlPath;
            entityFromDb.ImageLocalPath = entity.ImageLocalPath;
            entityFromDb.ImageBackground = entity.ImageBackground;
            entityFromDb.IsActive = entity.IsActive;
            entityFromDb.SliderId = entity.SliderId;

            //entityFromDb.CrUser = crUser;
            entityFromDb.LmUser = crUser;
            //entityFromDb.CrDate = DateTime.Now;
            entityFromDb.LmDate = DateTime.Now;

            Context.SliderStepRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }


        public int DeleteStep(int id, ref ErrorCode.SliderServiceStatus status)
        {
            if (id == 0)
            {
                status = ErrorCode.SliderServiceStatus.StepNotExists;
                return 1;
            }

            SliderStep step = Context.SliderStepRepository.Find(id);

            int rtn = Context.SliderStepRepository.Delete(step);
            Context.Save();
            return rtn;
        }


        public SliderHeader GetSliderForClientLayout(int sliderId, int takeCount)
        {
            var sliderStep = Context.SliderStepRepository.All().Where(m => m.SliderId == sliderId && m.IsActive == true);

            var nodes = sliderStep.OrderByDescending(m => m.CrDate).Select(m => new
            {
                Id = m.Id,
                Content = m.Content,
                Title = m.Title,
                ImageBackground = m.ImageBackground,
                ImageLocalPath = m.ImageLocalPath,
                ImageUrlPath = m.ImageUrlPath,
                //CrDate = m.CrDate,
                LinkTo = m.LinkTo
            }).Take(takeCount).ToList()
           .Select(m => new SliderStep()
           {
               Id = m.Id,
               Content = m.Content,
               Title = m.Title,
               ImageBackground = m.ImageBackground,
               ImageLocalPath = m.ImageLocalPath,
               ImageUrlPath = m.ImageUrlPath,
               //CrDate = m.CrDate,
               LinkTo = m.LinkTo
           }).ToList();

            SliderHeader model = GetSliderById(sliderId);
            model.SliderSteps = nodes;
            model.Id = sliderId;

            return model;
        }
    }
}
