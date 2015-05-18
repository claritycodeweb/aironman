using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class UserRepository : Repository<User>, IUserRepository {
        public UserRepository(DB context) : base(context) { }
    }
}
