using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.Services
{
    public interface ISliderService
    {
        SliderHeader CreateSlider(SliderHeader entity, ref ErrorCode.SliderServiceStatus status);
        SliderHeader UpdateSlider(SliderHeader entity, ref ErrorCode.SliderServiceStatus status);
        SliderStep CreateSliderStep(SliderStep entity, ref ErrorCode.SliderServiceStatus status);
        SliderStep UpdateSliderStep(SliderStep entity, ref ErrorCode.SliderServiceStatus status);
        IQueryable<SliderHeader> GetSliderWithStep();
        IQueryable<SliderStep> GetSliderStep(int sliderHeaderId);
        IQueryable<SliderStep> GetSliderStep(string sliderHeaderName);
        IQueryable<SliderHeader> GetSliderWithoutStep();
        SliderHeader GetSliderHeaderById(int id);
        SliderHeader GetSliderById(int id);
        SliderStep GetSliderStepById(int id);

        int DeleteStep(int id, ref ErrorCode.SliderServiceStatus status);

        #region Client optimalization query
        SliderHeader GetSliderForClientLayout(int sliderId, int takeCount);
        //PortfolioHeader GetPortfolioWithCategoryForClientLayout(int portfolioId, int takeCount);
        #endregion
    }
}
