using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class UserRepository : Repository<User>, IUserRepository {
        public UserRepository(DB context) : base(context) { }
    }
}
