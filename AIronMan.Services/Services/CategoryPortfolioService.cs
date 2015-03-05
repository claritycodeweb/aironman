using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;

namespace AIronMan.Services {
    //public class CategoryPortfolioService : ICategoryPortfolioService {
    //    private UnitOfWork context;

    //    public CategoryPortfolioService(UnitOfWork dal) {
    //        context = dal;
    //    }

    //    public IQueryable<Domain.CategoryPortfolio> GetCategroyByPortfolioName(string portfolioName) {
    //        var query = context.CategoryPortfolioRepository.All().Where(m => m.PortfolioNodes.Where(x => x.PortfolioHeader.NameUrl == portfolioName && x.IsVisible == true).Count() > 0).Distinct();
    //        return query;
    //    }

    //    public IQueryable<Domain.CategoryPortfolio> GetCategroyByPortfolioName(int id) {
    //        var query = context.CategoryPortfolioRepository.All().Where(m => m.PortfolioNodes.Where(x => x.PortfolioHeader.Id == id && x.IsVisible == true).Count() > 0).Distinct();
    //        return query;
    //    }
    //}
}
