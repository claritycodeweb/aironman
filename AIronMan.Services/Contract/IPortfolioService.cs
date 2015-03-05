using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.Services {
    public interface IPortfolioService {
        PortfolioHeader CreatePortfolio(PortfolioHeader entity,  ref ErrorCode.PortfolioServiceStatus status);
        PortfolioHeader UpdatePortfolio(PortfolioHeader entity,  ref ErrorCode.PortfolioServiceStatus status);
        PortfolioNode CreatePortfolioStep(PortfolioNode entity, IEnumerable<string> category, int userId, ref ErrorCode.PortfolioServiceStatus status);
        PortfolioNode UpdatePortfolioStep(PortfolioNode entity, IEnumerable<string> category, int userId, ref ErrorCode.PortfolioServiceStatus status);
        IQueryable<PortfolioHeader> GetPortfolioWithNode();
        IQueryable<PortfolioNode> GetPortfolioNode(int portfolioHeaderId);
        IQueryable<PortfolioNode> GetPortfolioNode(string portfolioHeaderName);
        IQueryable<PortfolioHeader> GetPortfolioWithoutNode();
        IQueryable<PortfolioHeader> GetPortfolioInSiteWithoutNode();
        PortfolioHeader GetPortfolioHeaderById(int id);
        PortfolioNode GetPortfolioNodeById(int id);

        IQueryable<PortfolioNode> GetPortfolioNodeVisible(string portfolioName, string category, string search);
        IQueryable<Domain.PortfolioNode> GetAllPortfolioNode();

        int DeletePortfolioNode(int id, ref ErrorCode.PortfolioServiceStatus status);


        #region Client optimalization query        
        Domain.PortfolioHeader GetPortfolioForClientLayout(int portfolioId, int takeCount);
        PortfolioHeader GetPortfolioWithCategoryForClientLayout(int portfolioId, int takeCount); 
        #endregion
    }
}
